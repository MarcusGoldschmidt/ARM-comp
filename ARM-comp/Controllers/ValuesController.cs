using System;
using ARM_comp.Helpers.NotEval;
using ARM_comp.Models;
using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;

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
        public ActionResult<string> Post([FromBody] ZeroFuncaoDto value)
        {
            var aux = new ZeroFuncao(value);
            return aux.Bissecao().ToString();
        }
    }
}