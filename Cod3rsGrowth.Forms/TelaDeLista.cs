using Cod3rsGrowth.Dominio.Filtros;
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

        private void AoClicarNoMarcaDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            var quantidadeDeLinhasSelecionadas = marcaDataGridView.SelectedRows.Count;
            const int vazio = 0;
            const int colunaId = 0;
            string mensagemDeErro = "Selecione apenas uma marca.";
            try
            {
                var idMarca = (int)marcaDataGridView.Rows[e.RowIndex].Cells[colunaId].Value;
                tenisDataGridView.DataSource = _servicoTenis.ObterTodos(new FiltrosTenis
                {
                    IdsMarcas = new List<int> { idMarca },
                });
            }
            catch (Exception)
            {
                MensagensErroOuSucesso.MostrarMensagemDeErro(mensagemDeErro);
            }
        }

        private void AoAlterarTextBoxBuscaMarca(object sender, EventArgs e)
        {
            _filtrosMarca.Nome = textBoxBuscaMarca.Text;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(new FiltrosMarca { Nome = _filtrosMarca.Nome });
            tenisDataGridView.DataSource = null;
        }

        private void AoAlterarDateTimePickerInicio(object sender, EventArgs e)
        {
            _filtrosMarca.DataDeInicio = dateTimePickerInicio.Value;
            _filtrosMarca.DataDeFim = dateTimePickerFim.Value;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(_filtrosMarca);
        }

        private void AoAlterarDateTimePickerFim(object sender, EventArgs e)
        {
            _filtrosMarca.DataDeInicio = dateTimePickerInicio.Value;
            _filtrosMarca.DataDeFim = dateTimePickerFim.Value;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(_filtrosMarca);
        }

        private void AoClicarNoBotaoLimparFiltros(object sender, EventArgs e)
        {
            textBoxBuscaMarca.Clear();
            dateTimePickerFim.Value = DateTime.Today.Date;
            dateTimePickerInicio.Value = DateTime.Today.Date;
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas(null);
            tenisDataGridView.DataSource = null;
        }

        private void AoClicarNoBotaoAdicionarMarca(object sender, EventArgs e)
        {
            TelaDeCadastroMarca formularioCadastro = new TelaDeCadastroMarca(_servicoMarca, _servicoTenis);
            formularioCadastro.ShowDialog();
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas();
        }

        private void AoClicarNoBotaoAdicionarTenis(object sender, EventArgs e)
        {
            TelaDeCadastroTenis formularioCadastro = new TelaDeCadastroTenis(_servicoMarca, _servicoTenis);
            formularioCadastro.ShowDialog();
            tenisDataGridView.DataSource = _servicoTenis.ObterTodos();
        }
    }
}

