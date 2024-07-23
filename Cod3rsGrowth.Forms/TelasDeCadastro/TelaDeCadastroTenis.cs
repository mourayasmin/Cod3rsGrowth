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
            var marcaSelecionada = _servicoMarca.ObterTodas(new FiltrosMarca
            {
                Nome = comboBoxNomeDaMarcaCadastroTenis.Text
            });
            const int indexDaMarcaSelecionada = 0;
            return marcaSelecionada[indexDaMarcaSelecionada].Id;
        }

        private void AoClicarNoBotaoSalvarCadastroTenis(object sender, EventArgs e)
        {
            const string vazio = "";
            try
            {
                Tenis tenisAdicionado = new Tenis
                {
                    Nome = textBoxNomeCadastroTenis.Text,
                    Linha = (LinhaEnum)comboBoxLinhaCadastroTenis.SelectedItem,
                    IdMarca = RetornaIdDaMarca(),
                    Preco = textBoxPrecoCadastroMarca.Text == vazio ? (double)decimal.Zero : Double.Parse(textBoxPrecoCadastroMarca.Text),
                    Avaliacao = numericUpDownAvaliacaoCadastroTenis.Value,
                    Disponibilidade = checkBoxDisponibilidadeCadastroTenis.Checked,
                    Lancamento = dateTimePickerLancamentoCadastroTenis.Value
                };
                _servicoTenis.Criar(tenisAdicionado);
                string mensagem = "Tenis cadastrado com sucesso.";
                Mensagens.MostrarMensagemDeSucesso(mensagem);
                this.Close();
            }
            catch (ValidationException excecoes)
            {
                string mensagemErro = "";

                foreach (var erro in excecoes.Errors)
                {
                    mensagemErro += erro.ErrorMessage + "\n";
                }
                Mensagens.MostrarMensagemDeErro(mensagemErro);
            }
            catch (Exception excecao)
            {
                string mensagem = "Ocorreu um erro na aplicação.";
                MessageBox.Show(mensagem);
            }
        }

        private void AoClicarNoBotaoCancelarCadastroTenis(object sender, EventArgs e)
        {
            textBoxNomeCadastroTenis.Clear();
            textBoxPrecoCadastroMarca.Clear();
            checkBoxDisponibilidadeCadastroTenis.Enabled = false;
            dateTimePickerLancamentoCadastroTenis.Value = DateTime.Today.Date;
            this.Close();
        }

        private void AoCarregarTelaDeCadastroTenis(object sender, EventArgs e)
        {
            comboBoxLinhaCadastroTenis.DataSource = Enum.GetValues(typeof(LinhaEnum));
            comboBoxNomeDaMarcaCadastroTenis.DataSource = _servicoMarca.ObterTodas().Select(x => x.Nome).ToList();
        }

        private void KeyPressTextBoxPrecoCadastroTenis(object sender, KeyPressEventArgs e)
        {
            const int backspace = 8;
            const int virgula = 44;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != backspace && e.KeyChar != virgula)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == virgula)
            {
                TextBox textBoxPrecoCadastroTenis = (TextBox)sender;
                if (textBoxPrecoCadastroTenis.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
