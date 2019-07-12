using System.Collections.Generic;
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
    }
}