using FG_Blazor_WASM.Server.Services;
using FG_Blazor_WASM.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices services;

        public LoginController(ILoginServices  services)
        {
            this.services = services;
        }
        [HttpPost]
        public string Post([FromBody] Login user)
        {
            var result=services.FindByCondition(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (result==null)
            {
                return "Login Failed....!";
            }
            return "Login Successfully...!";
        }
    }
}
