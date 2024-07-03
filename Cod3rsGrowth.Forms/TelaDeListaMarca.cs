using Cod3rsGrowth.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeListaMarca : Form
    {
        private readonly ServicoMarca _servicoMarca;

        public TelaDeListaMarca(ServicoMarca servicoMarca)
        {
            _servicoMarca = servicoMarca;
            InitializeComponent();
            dataGridView1.DataSource = _servicoMarca.ObterTodas(null);
        }
    }
}
