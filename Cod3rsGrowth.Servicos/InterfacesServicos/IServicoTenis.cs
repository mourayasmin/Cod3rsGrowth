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
        public int ObterPorId(int Id);
    }
}
