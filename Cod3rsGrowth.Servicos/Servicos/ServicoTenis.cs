using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoTenis : IServicoTenis
    {
        private IRepositorioTenis _repositoriotenis;
        private IValidator<Tenis> _validator;
        public ServicoTenis(IRepositorioTenis RepositorioTenisMock, IValidator <Tenis> validator)
        {
            _repositoriotenis = RepositorioTenisMock;
            _validator = validator;
        }
        public List<Tenis> ObterTodos()
        {
            return _repositoriotenis.ObterTodos();
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
    }
}