
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnv;
        public SampleDataController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost]
        public void Save(IList<IFormFile> UploadFiles)
        {
            long size = 0;
            try
            {
                foreach (var file in UploadFiles)
                {
                    var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                    filename = hostingEnv.ContentRootPath + $@"\{filename}";
                    size += (int)file.Length;
                    if (!System.IO.File.Exists(filename))
                    {
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }

        [HttpPost]
        public void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                var filename = hostingEnv.ContentRootPath + $@"\{UploadFiles[0].FileName}";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}
