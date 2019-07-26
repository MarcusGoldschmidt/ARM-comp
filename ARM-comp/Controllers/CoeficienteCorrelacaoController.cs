using System.Collections.Generic;
using ARM_comp.Models.Correlacao;
using ARM_comp.Models.Interpolacao;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/correlacao")]
    [ApiController]
    public class CoeficienteCorrelacaoController : ControllerBase
    {
        [HttpPost("person")]
        public ActionResult<string> Pesron([FromBody] List<PontoCartesiano> value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new CoeficienteCorrelacao(value).CorrelacaoPerson()
            });
        }
        
        [HttpPost("spearman")]
        public ActionResult<string> Spearman([FromBody] List<PontoCartesiano> value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new CoeficienteCorrelacao(value).CorrelacaoSperman()
            });
        }
        
        [HttpPost("kendall")]
        public ActionResult<string> Kendall([FromBody] List<PontoCartesiano> value)
        {
            return JsonConvert.SerializeObject(new
            {
                result = new CoeficienteCorrelacao(value).CorrelacaoKendall()
            });
        }
        
    }
}