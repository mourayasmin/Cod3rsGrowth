using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;
using LinqToDB.Common;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroTenis : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly DataGridView _tenisDataGridView;
        private readonly ValidacaoTenis _validacaoTenis;
        private readonly FiltrosMarca _filtrosMarca = new FiltrosMarca();
        private readonly Tenis _tenis;

        public TelaDeCadastroTenis(ServicoMarca servicoMarca, ServicoTenis servicoTenis, Tenis? tenis)
        {
            _tenis = tenis;
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
            if(_tenis != null)
            {
                PreencherDadosDoTenisAutomaticamente();
            }
        }

        private void AoClicarNoBotaoSalvarCadastroTenis(object sender, EventArgs e)
        {
            const string vazio = "";
            try
            {
                if (_tenis == null)
                {
                    Tenis tenisAdicionado = new Tenis
                    {
                        Nome = textBoxNomeCadastroTenis.Text,
                        Linha = (LinhaEnum)comboBoxLinhaCadastroTenis.SelectedItem,
                        IdMarca = RetornaIdDaMarca(),
                        Preco = textBoxPrecoCadastroTenis.Text == vazio ? (double)decimal.Zero : Double.Parse(textBoxPrecoCadastroTenis.Text),
                        Avaliacao = numericUpDownAvaliacaoCadastroTenis.Value,
                        Disponibilidade = checkBoxDisponibilidadeCadastroTenis.Checked,
                        Lancamento = dateTimePickerLancamentoCadastroTenis.Value
                    };

                    _servicoTenis.Criar(tenisAdicionado);
                    string mensagem = "Tenis cadastrado com sucesso.";
                    Mensagens.MostrarMensagemDeSucesso(mensagem);
                    this.Close();
                }
                else
                {
                    textBoxNomeCadastroTenis.Enabled = false;
                    _tenis.Preco = textBoxPrecoCadastroTenis.Text == vazio ? (double)decimal.Zero : Double.Parse(textBoxPrecoCadastroTenis.Text);
                    _tenis.Avaliacao = numericUpDownAvaliacaoCadastroTenis.Value;
                    _tenis.Disponibilidade = checkBoxDisponibilidadeCadastroTenis.Checked;
                    _tenis.Lancamento = dateTimePickerLancamentoCadastroTenis.Value;

                    _servicoTenis.Atualizar(_tenis);
                    string mensagem = "Tênis atualizado com sucesso.";
                    Mensagens.MostrarMensagemDeSucesso(mensagem);
                    this.Close();
                }
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
            catch (Exception)
            {
                string mensagem = "Ocorreu um erro na aplicação.";
                MessageBox.Show(mensagem);
            }
        }

        private void AoClicarNoBotaoCancelarCadastroTenis(object sender, EventArgs e)
        {
            textBoxNomeCadastroTenis.Clear();
            textBoxPrecoCadastroTenis.Clear();
            checkBoxDisponibilidadeCadastroTenis.Enabled = false;
            dateTimePickerLancamentoCadastroTenis.Value = DateTime.Today.Date;
            this.Close();
        }

        private void AoCarregarTelaDeCadastroTenis(object sender, EventArgs e)
        {
            if (_tenis == null)
            {
                comboBoxLinhaCadastroTenis.DataSource = Enum.GetValues(typeof(LinhaEnum));
                comboBoxNomeDaMarcaCadastroTenis.DataSource = _servicoMarca.ObterTodas().Select(x => x.Nome).ToList();
            }
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

        private int RetornaIdDaMarca()
        {
            var marcaSelecionada = _servicoMarca.ObterTodas(new FiltrosMarca
            {
                Nome = comboBoxNomeDaMarcaCadastroTenis.Text
            });
            const int indexDaMarcaSelecionada = 0;

            return marcaSelecionada[indexDaMarcaSelecionada].Id;
        }

        private Enum RetornaLinhaDoTenis()
        {
            var tenisSelecionado = _servicoTenis.ObterPorId(_tenis.Id);

            return tenisSelecionado.Linha;
        }

        private string RetornaNomeDaMarca()
         {
            var marcaSelecionada = _servicoMarca.ObterPorId(_tenis.IdMarca);

            return marcaSelecionada.Nome;
        }

        private void PreencherDadosDoTenisAutomaticamente()
        {
            textBoxNomeCadastroTenis.Text = _tenis.Nome;
            comboBoxNomeDaMarcaCadastroTenis.Text = RetornaNomeDaMarca();
            textBoxPrecoCadastroTenis.Text = _tenis.Preco.ToString();
            comboBoxLinhaCadastroTenis.Text = RetornaLinhaDoTenis().ToString();
            numericUpDownAvaliacaoCadastroTenis.Value = _tenis.Avaliacao.Value;
            checkBoxDisponibilidadeCadastroTenis.Checked = _tenis.Disponibilidade;
            dateTimePickerLancamentoCadastroTenis.Value = _tenis.Lancamento;
        }
    }
}
