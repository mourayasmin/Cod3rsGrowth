using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoMarca
    {
        private IRepositorioMarca _repositoriomarca;
        private IValidator<Marca> _validator;
        public ServicoMarca(IRepositorioMarca RepositorioMarcaMock, IValidator<Marca> validator)
        {
            _repositoriomarca = RepositorioMarcaMock;
            _validator = validator;
        }

        public List<Marca> ObterTodas(FiltrosMarca filtros)
        {
            return _repositoriomarca.ObterTodas(null);
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

        public Marca Atualizar(Marca marca)
        {
            if (marca == null)
            {
                throw new Exception("A marca não foi informada.");
            }
            _validator.ValidateAndThrow(marca);
            return _repositoriomarca.Atualizar(marca);
        }

        public void Deletar(int id)
        {
            _repositoriomarca.Deletar(id);
        }
    }
}