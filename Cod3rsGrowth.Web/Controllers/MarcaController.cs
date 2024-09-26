using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra;
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

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int id)
        {
            var marca = _servicoMarca.ObterPorId(id);
            return Ok(marca);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Marca marca)
        {
            _servicoMarca.Criar(marca);
            return Created(marca.Id.ToString(), marca);
        }

        [HttpPatch]
        public NoContentResult Atualizar([FromBody] Marca marca)
        {
            _servicoMarca.Atualizar(marca);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public NoContentResult Deletar(int id)
        {
            _servicoMarca.Deletar(id);
            return NoContent();
        }
    }
}