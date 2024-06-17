﻿using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.InterfacesServicos
{
    public interface IServicoMarca
    {
        public List<Marca> ObterTodas();
        public Marca ObterPorId(int Id);
        public Marca Criar(Marca marcaCriada);
        public Marca Atualizar(Marca marcaEditada);
    }
}
