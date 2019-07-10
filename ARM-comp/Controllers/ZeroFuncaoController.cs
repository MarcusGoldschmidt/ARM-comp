using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/funcao-zera")]
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
        [HttpPost("bissecao")]
        public ActionResult<double> Test([FromBody] ZeroFuncaoDto value)
        {
            return new ZeroFuncao(value).Bissecao();
        }
    }
}