using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeLista : Form
    {
        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;

        public TelaDeLista(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
            dataGridView1.DataSource = _servicoMarca.ObterTodas(null);
            dataGridView2.DataSource = _servicoTenis.ObterTodos(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
