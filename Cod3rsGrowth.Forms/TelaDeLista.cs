using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Repositorios;
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
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void marcaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var marca = new Marca();

            if (marcaDataGridView.SelectedRows.Count != 0)
            {
                var idMarca = (int)marcaDataGridView.Rows[e.RowIndex].Cells[0].Value;
                tenisDataGridView.DataSource = _servicoTenis.ObterTodos(new FiltrosTenis
                {
                    IdsMarcas = new List<int> { idMarca },
                });
            }
        }

        private void marcaDataGridView_CellContentClick(object sender, DragEventArgs e)
        {

        }
    }
}
