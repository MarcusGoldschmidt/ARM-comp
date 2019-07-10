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
            return JsonConvert.SerializeObject(new Node(value.Funcao));
        }
        
        [HttpPost("bissecao")]
        public ActionResult<string> Bissecao([FromBody] ZeroFuncaoDto value)
        {
            var json = new
            {
                result = new ZeroFuncao(value).Bissecao()
            };
            return JsonConvert.SerializeObject(json);
        }
        
        [HttpPost("posicao-falsa")]
        public ActionResult<string> PosicaoFalsa([FromBody] ZeroFuncaoDto value)
        {
            var json = new
            {
                result = new ZeroFuncao(value).PosicaoFalsa()
            };
            return JsonConvert.SerializeObject(json);
        }
        
        [HttpPost("newton")]
        public ActionResult<string> NewtonRaphson([FromBody] ZeroFuncaoDto value)
        {
            var json = new
            {
                result = new ZeroFuncao(value).NewtonRaphson()
            };
            return JsonConvert.SerializeObject(json);
        }
    }
}