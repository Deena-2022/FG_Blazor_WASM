
using FG_Blazor_WASM.Server.Services;
using FG_Blazor_WASM.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class LeadsController : ControllerBase
{
        private readonly ILeadServices services;

        public LeadsController(ILeadServices services)
        {
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
        {
            var products = await services.GetProducts(productParameters);
            
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Leads user = services.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }


        [HttpPost]
        public void Post(Leads user)
        {
            services.Add(user);
        }
        [HttpPut]
        public void Put(Leads user)
        {
            services.Update(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            services.Delete(id);
            return Ok();
        }
    }
}
