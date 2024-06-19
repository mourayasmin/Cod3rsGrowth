﻿using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioTenis
    {
        public Tenis Criar(Tenis tenis);
        public Tenis ObterPorId(int id); 
        public Tenis Atualizar(Tenis tenis);
        public void Deletar(int id);
        public List<Tenis> ObterTodos();
    }
}
