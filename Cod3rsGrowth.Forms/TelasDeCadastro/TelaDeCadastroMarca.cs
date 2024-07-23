using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;


namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroMarca : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly DataGridView _marcaDataGridView;

        public TelaDeCadastroMarca(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            InitializeComponent();
        }

        private void AoClicarNoBotaoSalvarCadastroMarca(object sender, EventArgs e)
        {
            try
            {
                maskedTextBoxCNPJCadastroMarca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                maskedTextBoxTelefoneCadastroMarca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                Marca marcaAdicionada = new Marca
                {
                    Nome = textBoxNomeCadastroMarca.Text,
                    Cnpj = maskedTextBoxCNPJCadastroMarca.Text,
                    Email = textBoxEmailCadastroMarca.Text,
                    Telefone = maskedTextBoxTelefoneCadastroMarca.Text,
                    DataDeCriacao = dateTimePickerDataDeCriacaoCadastroMarca.Value
                };
                _servicoMarca.Criar(marcaAdicionada);
                string mensagem = "Marca cadastrada com sucesso.";
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
                string mensagemErroInesperado = "Ocorreu um erro na aplicação.";
                Mensagens.MostrarMensagemDeErro(mensagemErroInesperado);
            }
        }

        private void AoClicarNoBotaoCancelarCadastroMarca(object sender, EventArgs e)
        {
            textBoxNomeCadastroMarca.Clear();
            maskedTextBoxCNPJCadastroMarca.Clear();
            textBoxEmailCadastroMarca.Clear();
            maskedTextBoxTelefoneCadastroMarca.Clear();
            dateTimePickerDataDeCriacaoCadastroMarca.Value = DateTime.Today.Date;
            this.Close();
        }
    }
}
