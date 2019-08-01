using ARM_comp.Helpers;
using ARM_comp.Models.PontoZero;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/math")]
    [ApiController]
    public class MathController : ControllerBase
    {
        // GET Metodo para brincar e ver a arvore que vai gerar
        [HttpPost]
        public ActionResult<string> Post([FromBody] ZeroFuncaoDto value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new MathExpression(value.Funcao).F(value.X)
            });
        }
    }
}