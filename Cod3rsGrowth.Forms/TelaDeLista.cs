using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeLista : Form
    {
        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly FiltrosMarca _filtrosMarca = new FiltrosMarca();


        public TelaDeLista(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void marcaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBoxBuscaMarca_TextChanged(object sender, EventArgs e)
        {
            _filtrosMarca.Nome = textBoxBuscaMarca.Text;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(_filtrosMarca);
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            _filtrosMarca.DataDeInicio = dateTimePickerInicio.Value;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(_filtrosMarca);
        }
        private void dateTimePickerFim_ValueChanged(object sender, EventArgs e)
        {
            _filtrosMarca.DataDeFim = dateTimePickerFim.Value;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(_filtrosMarca);
        }
    }
}
