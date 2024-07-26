using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenisController : ControllerBase
    {
        private readonly ServicoTenis _servicoTenis;

        public TenisController(ServicoTenis servicoTenis) 
        {
            _servicoTenis = servicoTenis;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltrosTenis filtro)
        {
            return Ok(_servicoTenis.ObterTodos(filtro));
        }
    }
}