using Microsoft.AspNetCore.Mvc;
using SuaSaude.Core.Dto;
using SuaSaude.Core.Interface;

namespace SuaSaude.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleDePesoController : ControllerBase
    {
        public IControleDePeso _controleDePeso;
        public ControleDePesoController(IControleDePeso controleDePeso)
        {
            _controleDePeso = controleDePeso;
        }

        [HttpGet("CalcularIMC")]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<double> CalcularIMC(double peso, double altura)
        {
            return Ok(_controleDePeso.CalcularIMC(peso, altura));
        }

        [HttpGet("ClassificarIMC")]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> ClassificarIMC(double imc)
        {
            return Ok(await _controleDePeso.ClassificarIMCAsync(imc));
        }

        [HttpGet("VerificarSaude")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DtoVerificarSaudeResponse>> VerificarSaude(double peso, double altura)
        {
            return Ok(await _controleDePeso.VerificarSaudeAsync(peso, altura));
        }
    }
}
