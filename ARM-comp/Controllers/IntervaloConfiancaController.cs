using ARM_comp.Models.Interfaces;
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
        public ActionResult<string> Bissecao([FromBody] IntervaloConfiancaDto value)
        {
            var confianca = new IntervaloConfianca(_tabelaIntervaloConfianca, value);
            return JsonConvert.SerializeObject(confianca.DesvioPadraoConhecido());
        }
    }
}