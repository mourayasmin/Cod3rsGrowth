using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly ServicoMarca _servicoMarca;

        public MarcaController(ServicoMarca servicoMarca)
        {
            _servicoMarca = servicoMarca;
        }

        [HttpGet]
        public IActionResult ObterTodas([FromQuery] FiltrosMarca filtros)
        {
            var marcas = _servicoMarca.ObterTodas(filtros);
            return Ok(marcas);
        }
    }
}