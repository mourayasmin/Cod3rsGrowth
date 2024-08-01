﻿using Cod3rsGrowth.Dominio.Filtros;
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
        private readonly DBCod3rsGrowth _db;

        public MarcaController(ServicoMarca servicoMarca, DBCod3rsGrowth db)
        {
            _servicoMarca = servicoMarca;
            _db = db;
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
        public void Atualizar([FromBody] Marca marca)
        {
            _servicoMarca.Atualizar(marca);
        }
    }
}