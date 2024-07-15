using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroTenis : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly DataGridView _tenisDataGridView;
        private readonly ValidacaoTenis _validacaoTenis;
        private readonly FiltrosMarca _filtrosMarca = new FiltrosMarca();

        public TelaDeCadastroTenis(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
        }

        private int RetornaIdDaMarca()
        {
            var marcaSelecionada = _servicoMarca.ObterTodas(new FiltrosMarca {
                Nome = comboBoxNomeDaMarcaCadastroTenis.Text
            });
            const int indexDaMarcaSelecionada = 0;
            return marcaSelecionada[indexDaMarcaSelecionada].Id;
        }

        private void AoClicarNoBotaoSalvarCadastroTenis(object sender, EventArgs e)
        {
            try
            {
                Tenis tenisAdicionado = new Tenis
                {
                    Nome = textBoxNomeCadastroTenis.Text,
                    Linha = (LinhaEnum)comboBoxLinhaCadastroTenis.SelectedItem,
                    IdMarca = RetornaIdDaMarca(),
                    Preco = Double.Parse(textBoxPrecoCadastroTenis.Text),
                    Avaliacao = textBoxAvaliacaoCadastroTenis.Text == "" ? 0 : Decimal.Parse(textBoxAvaliacaoCadastroTenis.Text),
                    Disponibilidade = checkBoxDisponibilidadeCadastroTenis.Checked,
                    Lancamento = dateTimePickerLancamentoCadastroTenis.Value
                };
                _servicoTenis.Criar(tenisAdicionado);
                string mensagem = "Tenis cadastrado com sucesso.";
                MensagensErroOuSucesso.MostrarMensagemDeSucesso(mensagem);
                this.Close();
            }
            catch (ValidationException excecoes)
            {
                string mensagemErro = "";

                foreach (var erro in excecoes.Errors)
                {
                    mensagemErro += erro.ErrorMessage + "\n";
                }
                MensagensErroOuSucesso.MostrarMensagemDeErro(mensagemErro);
            }
        }

        private void AoClicarNoBotaoCancelarCadastroTenis(object sender, EventArgs e)
        {
            textBoxNomeCadastroTenis.Clear();
            textBoxPrecoCadastroTenis.Clear();
            textBoxAvaliacaoCadastroTenis.Clear();
            checkBoxDisponibilidadeCadastroTenis.Enabled = false;
            dateTimePickerLancamentoCadastroTenis.Value = DateTime.Today.Date;
            this.Close();
        }

        private void AoCarregarTelaDeCadastroTenis(object sender, EventArgs e)
        {
            comboBoxLinhaCadastroTenis.DataSource = Enum.GetValues(typeof(LinhaEnum));
            comboBoxNomeDaMarcaCadastroTenis.DataSource = _servicoMarca.ObterTodas().Select(x => x.Nome).ToList();
        }
    }
}
