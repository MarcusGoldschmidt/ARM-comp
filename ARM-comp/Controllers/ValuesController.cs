using ARM_comp.Helpers.NotEval;
using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] ZeroFuncaoDto value)
        {
            var aux = new ZeroFuncao(value);
            //return aux.Bissecao().ToString();
            return JsonConvert.SerializeObject(aux);
        }
        
        // POST api/values
        [HttpPost("test")]
        public ActionResult<string> Test([FromBody] ZeroFuncaoDto value)
        {
            return JsonConvert.SerializeObject(new Node(value.funcao));
        }
    }
}