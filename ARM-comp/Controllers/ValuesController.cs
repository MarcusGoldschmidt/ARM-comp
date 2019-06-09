using ARM_comp.Helpers.NotEval;
using ARM_comp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARM_comp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "sd";
        }

        // POST api/values
        [HttpPost]
        public DataCell Post([FromForm] ZeroFuncao value)
        {
            DataCell cell = new DataCell(value.Funcao);
            
            return cell;
        }
    }
}