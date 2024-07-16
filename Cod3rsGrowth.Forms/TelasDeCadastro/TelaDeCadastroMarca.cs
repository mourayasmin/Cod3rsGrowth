using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;


namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroMarca : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly DataGridView _marcaDataGridView;
        private readonly ValidacaoMarca _validacaoMarca;

        public TelaDeCadastroMarca(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
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
            catch (Exception excecao)
            {
                string mensagemErroInesperado = "Ocorreu um erro na aplicação.";
                MessageBox.Show(mensagemErroInesperado);
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
