using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MLModel_WebApi1;
using Web.Data;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        MLModel.ModelInput input = new MLModel.ModelInput();
        MLModel.ModelOutput output = new MLModel.ModelOutput();

        private readonly IHostEnvironment _environment;
        public IndexModel(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty(SupportsGet = true)]
        public CD cd { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public void OnGet()
        {
            cd.Name = output.Prediction;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images", Image.FileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var uploads = Path.Combine(_environment.ContentRootPath, "wwwroot/images");
            var filePath = Path.Combine(uploads, Image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create)) { 
                await Image.CopyToAsync(fileStream);
            }
            
            input.ImageSource = path;
            output = MLModel.Predict(input);
            using (StreamReader r = new StreamReader("data/rating.json"))
            {
                string json = r.ReadToEnd();
                List<CD> cdlist = JsonConvert.DeserializeObject<List<CD>>(json);
                cd = cdlist.Where(n => n.Name == output.Prediction).FirstOrDefault();
            }
           
            return Page();
        }
    }
}
