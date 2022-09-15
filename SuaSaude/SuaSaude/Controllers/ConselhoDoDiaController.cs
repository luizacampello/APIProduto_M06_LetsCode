using Microsoft.AspNetCore.Mvc;
using SuaSaude.Core.Interface;

namespace SuaSaude.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConselhoDoDiaController : ControllerBase
    {
        public IComunicaAdviceClient _comunicaAdviceClient;
        public ConselhoDoDiaController(IComunicaAdviceClient comunicaAdviceClient)
        {
            _comunicaAdviceClient = comunicaAdviceClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _comunicaAdviceClient.BuscarConselhoAsync());
        }
    }
}
