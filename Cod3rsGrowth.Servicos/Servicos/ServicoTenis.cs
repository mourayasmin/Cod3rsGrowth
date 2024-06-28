using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoTenis
    {
        private IRepositorioTenis _repositoriotenis;
        private IValidator<Tenis> _validator;
        public ServicoTenis(IRepositorioTenis RepositorioTenisMock, IValidator<Tenis> validator)
        {
            _repositoriotenis = RepositorioTenisMock;
            _validator = validator;
        }

        public List<Tenis> ObterTodos(FiltrosTenis filtros)
        {
            return _repositoriotenis.ObterTodos(filtros);
        }

        public Tenis ObterPorId(int id)
        {
            return _repositoriotenis.ObterPorId(id) ?? throw new ArgumentException("O Id informado é inválido.");
        }

        public Tenis Criar(Tenis tenis)
        {
            _validator.ValidateAndThrow(tenis);
            return _repositoriotenis.Criar(tenis);
        }

        public Tenis Atualizar(Tenis tenis)
        {
            if (tenis == null)
            {
                throw new Exception("O tênis não foi informado.");
            }
            _validator.ValidateAndThrow(tenis);
            return _repositoriotenis.Atualizar(tenis);
        }

        public void Deletar(int id)
        {
            _repositoriotenis.Deletar(id);
        }
    }
}