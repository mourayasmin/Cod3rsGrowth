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
    }
}