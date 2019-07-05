using System;
using ARM_comp.Helpers.NotEval;
using ARM_comp.Models;
using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "sd";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] ZeroFuncaoDto value)
        {
            try
            {
                var aux = new ZeroFuncao(value);
                return aux.Bissecao().ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}