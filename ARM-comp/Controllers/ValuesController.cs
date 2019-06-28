using ARM_comp.Helpers.NotEval;
using ARM_comp.Models;
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
        public string Post([FromForm] ZeroFuncao value)
        {
            var node = new Node(value.Funcao);
            return JsonConvert.SerializeObject(node);
        }
    }
}