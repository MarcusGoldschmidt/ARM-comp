using ARM_comp.Models.Interpolacao;
using ARM_comp.Models.Interpolacao.Metodos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/interpolacao")]
    [ApiController]
    public class InterpolacaoController : ControllerBase
    {
        [HttpPost("lagrange")]
        public ActionResult<string> Bissecao([FromBody] PontosDto value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new Lagrange(value).Interpolacao()
            });
        }
        
        [HttpPost("newton")]
        public ActionResult<string> Newton([FromBody] PontosDto value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new FormaNewton(value).Interpolacao()
            });
        }
        
        [HttpPost("linear")]
        public ActionResult<string> Linear([FromBody] PontosDto value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new Linear(value).Interpolacao()
            });
        }
        
        [HttpPost("trignometrica")]
        public ActionResult<string> Interpolacao([FromBody] PontosDto value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new Trignometrica(value).Interpolacao()
            });
        }
    }
}