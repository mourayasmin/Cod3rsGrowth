﻿using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoMarca : IServicoMarca
    {
        private IRepositorioMarca _repositoriomarca;
        private IValidator<Marca> _validator;
        public ServicoMarca(IRepositorioMarca RepositorioMarcaMock, IValidator<Marca> validator)
        {
            _repositoriomarca = RepositorioMarcaMock;
            _validator = validator;
        }
        public List<Marca> ObterTodas()
        {
            return _repositoriomarca.ObterTodas();
        }
        public Marca ObterPorId(int Id)
        {
            return _repositoriomarca.ObterPorId(Id) ?? throw new ArgumentException("O Id informado é inválido.");
        }
        public Marca Criar(Marca marca)
        {
            _validator.ValidateAndThrow(marca);
            return _repositoriomarca.Criar(marca);
        }
        public Marca Atualizar(Marca marca, int Id)
        {
            _validator.ValidateAndThrow(marca);
            return _repositoriomarca.Atualizar(marca, Id);
        }
    }
}