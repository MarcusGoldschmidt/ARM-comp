using ARM_comp.Helpers.NotEval;
using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/funcao-zera")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET Metodo para brincar e ver a arvore que vai gerar
        [HttpPost]
        public ActionResult<string> Post([FromBody] ZeroFuncaoDto value)
        {
            return JsonConvert.SerializeObject(new Node(value.funcao));
        }
        
        [HttpPost("bissecao")]
        public ActionResult<string> Test([FromBody] ZeroFuncaoDto value)
        {
            var json = new
            {
                result = new ZeroFuncao(value).Bissecao()
            };
            return JsonConvert.SerializeObject(json);
        }
    }
}