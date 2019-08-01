using ARM_comp.Interfaces;
using ARM_comp.Models.IntervaloConfianca;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARM_comp.Controllers
{
    [Route("api/confianca")]
    [ApiController]
    public class IntervaloConfiancaController
    {
        private readonly ITabelaIntervaloConfianca _tabelaIntervaloConfianca;
        
        public IntervaloConfiancaController(ITabelaIntervaloConfianca table)
        {
            _tabelaIntervaloConfianca = table;
        }

        [HttpPost("normal")]
        public ActionResult<string> Normal([FromBody] IntervaloConfiancaDto value)
        {
            var confianca = new IntervaloConfianca(_tabelaIntervaloConfianca, value);
            return JsonConvert.SerializeObject(confianca.DesvioPadraoConhecido());
        }
        
        [HttpPost("tstudent")]
        public ActionResult<string> TStudent([FromBody] IntervaloConfiancaDto value)
        {
            var confianca = new IntervaloConfianca(_tabelaIntervaloConfianca, value);
            return JsonConvert.SerializeObject(confianca.DesvioPadraoDesconhecido());
        }
        
        [HttpPost("proporcao/populacional")]
        public ActionResult<string> ProporcaoPopulacional([FromBody] IntervaloConfiancaDto value)
        {
            var confianca = new IntervaloConfiancaPopulacional(_tabelaIntervaloConfianca, value);
            return JsonConvert.SerializeObject(confianca.ProporcaoPopulacional());
        }
    }
}