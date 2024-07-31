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

        [HttpPost]
        public CreatedResult Criar([FromBody] Tenis tenis)
        {
            _servicoTenis.Criar(tenis);
            return Created(tenis.Id.ToString(), tenis);
        }
    }
}