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

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        MLModel.ModelInput input = new MLModel.ModelInput();
        MLModel.ModelOutput output = new MLModel.ModelOutput();
        private IHostingEnvironment _environment;
        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public string Upload { get; set; }
        public void OnGet()
        {

        }
        public async Task OnPostAsync()
        {
            input.ImageSource = Upload;
        }
    }
}
