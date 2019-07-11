using ARM_comp.Models.Interpolacao.Metodos;
using ARM_comp.Models.Metodos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/interpolacao")]
    [ApiController]
    public class InterpolacaoController : ControllerBase
    {
        [HttpPost("lagrange")]
        public ActionResult<string> Bissecao([FromBody] LagrangeDto value)
        {
            
            var lagrange = new Lagrange(value);
            
            var json = new
            {
                result = lagrange.Interpolacao()
            };
            return JsonConvert.SerializeObject(json);
        }
    }
}