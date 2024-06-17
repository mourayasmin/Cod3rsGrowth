﻿using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.InterfacesServicos
{
    public interface IServicoTenis
    {
        public List<Tenis> ObterTodos();
        public Tenis ObterPorId(int Id);
        public Tenis Criar(Tenis tenisCriado);
        public Tenis Atualizar(Tenis tenis, int Id);
    }
}
