using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class Form1 : Form
    {
        private readonly ServicoMarca _servicoMarca;

        public Form1(ServicoMarca servicoMarca)
        {
            _servicoMarca = servicoMarca;
            InitializeComponent();
            dataGridView1.DataSource = _servicoMarca.ObterTodas(null);
        }
    }
}
