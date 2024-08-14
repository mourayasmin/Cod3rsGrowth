using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.TenisWeb.TenisController
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
        public IActionResult ObterTodos([FromQuery] FiltrosTenis filtros)
        {
            var tenis = _servicoTenis.ObterTodos(filtros);
            return Ok(tenis);
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int id)
        {
            var tenis = _servicoTenis.ObterPorId(id);
            return Ok(tenis);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Tenis tenis)
        {
            _servicoTenis.Criar(tenis);
            return Created(tenis.Id.ToString(), tenis);
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] Tenis tenis)
        {
            _servicoTenis.Atualizar(tenis);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int id)
        {
            _servicoTenis.Deletar(id);
            return Ok();
        }
    }
}