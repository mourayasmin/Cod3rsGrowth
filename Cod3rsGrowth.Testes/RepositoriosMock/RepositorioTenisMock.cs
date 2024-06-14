﻿using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioTenisMock : IRepositorioTenis
    {
        public Tenis Criar(Tenis tenis)
        {
            SingletonTenis.tenis.Add(tenis);
            return tenis;
        }
        public Tenis ObterPorId(int Id)
        {
            return SingletonTenis.Instancia.FirstOrDefault(tenis => tenis.Id == Id);
        }
        public void Atualizar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public void Deletar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public List<Tenis> ObterTodos()
        {
            List<Tenis> _repositoriotenis = SingletonTenis.Instancia;
            return _repositoriotenis;
        }
    }
}
