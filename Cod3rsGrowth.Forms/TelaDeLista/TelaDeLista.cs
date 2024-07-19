using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeLista : Form
    {
        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly FiltrosMarca _filtrosMarca = new FiltrosMarca();
        private readonly FiltrosTenis _filtrosTenis = new FiltrosTenis();

        public TelaDeLista(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
            marcaDataGridView.DataSource = _servicoMarca.ObterTodas();
        }

        private void AoClicarNoMarcaDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            const int colunaId = 0;
            string mensagemDeErroAplicacao = "Ocorreu um erro na aplicação.";

            try
            {
                var idMarca = (int)marcaDataGridView.Rows[e.RowIndex].Cells[colunaId].Value;
                tenisDataGridView.DataSource = _servicoTenis.ObterTodos(new FiltrosTenis
                {
                    IdMarca = idMarca,
                });
            }
            catch (Exception)
            {
                Mensagens.MostrarMensagemDeErro(mensagemDeErroAplicacao);
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
        }

        private void AoClicarNoBotaoRemoverMarca(object sender, EventArgs e)
        {
            const int colunaId = 0;
            string mensagemDeSucesso = "Marca removida com sucesso.";
            string mensagemDeConfirmacao = "Deseja remover a marca selecionada?";
            string tituloMensagemDeConfirmacao = "Confirmação";

            try
            {
                var idMarca = (int)marcaDataGridView.CurrentRow.Cells[colunaId].Value;
                if (MessageBox.Show(mensagemDeConfirmacao, tituloMensagemDeConfirmacao, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var tenis = _servicoTenis.ObterTodos(new FiltrosTenis { IdMarca = idMarca });
                    tenis.ForEach(tenis => _servicoTenis.Deletar(tenis.Id));
                    _servicoMarca.Deletar(idMarca);

                    Mensagens.MostrarMensagemDeSucesso(mensagemDeSucesso);
                    marcaDataGridView.DataSource = _servicoMarca.ObterTodas();

                    tenisDataGridView.DataSource = _servicoTenis.ObterTodos(new FiltrosTenis
                    {
                        IdMarca = idMarca,
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro na aplicação.");
            }
        }

        private void AoClicarNoBotaoRemoverTenis(object sender, EventArgs e)
        {
            const int colunaId = 0;
            string mensagemDeSucesso = "Tênis removido com sucesso.";
            string tituloMensagemDeConfirmacao = "Confirmação";
            string mensagemDeConfirmacao = "Deseja remover o tênis selecionado?";

            try
            {
                if (tenisDataGridView.CurrentRow != null)
                {
                    if (tenisDataGridView.CurrentRow.Cells[1] != null && tenisDataGridView.CurrentRow.Cells[1].Value != null)
                    {
                        var idTenisASerRemovido = (int)tenisDataGridView.CurrentRow.Cells[colunaId].Value;
                        if (MessageBox.Show(mensagemDeConfirmacao, tituloMensagemDeConfirmacao, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var idMarcaDoTenisRemovido = (int)tenisDataGridView.CurrentRow.Cells[1].Value;
                            _servicoTenis.Deletar(idTenisASerRemovido);
                            Mensagens.MostrarMensagemDeSucesso(mensagemDeSucesso);
                            tenisDataGridView.DataSource = _servicoTenis.ObterTodos(new FiltrosTenis
                            {
                                IdMarca = idMarcaDoTenisRemovido,
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escolha um tênis referente à marca para ser removido.");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma linha selecionada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na aplicação.");
            }
        }
    }
}

