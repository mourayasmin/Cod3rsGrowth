﻿using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioMarca
    {
        public Marca Criar(Marca marca);
        public Marca ObterPorId(int Id);
        public Marca Atualizar(Marca marca, int Id);
        public void Deletar(Marca marca);
        public List<Marca> ObterTodas();
    }
}
