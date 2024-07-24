using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;


namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroMarca : Form
    {
        private readonly ServicoMarca _servicoMarca;
        private readonly DataGridView _marcaDataGridView;
        private readonly Marca _marca;

        public TelaDeCadastroMarca(ServicoMarca servicoMarca, ServicoTenis servicoTenis, Marca? marca)
        {
            _servicoMarca = servicoMarca;
            _marca = marca;

            InitializeComponent();

            if (_marca != null)
            {
                PreencherDadosAutomaticamente();
            }
        }

        private void AoClicarNoBotaoSalvarCadastroMarca(object sender, EventArgs e)
        {

            try
            {
                if (_marca == null)
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
                else
                {
                    maskedTextBoxTelefoneCadastroMarca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    _marca.Email = textBoxEmailCadastroMarca.Text;
                    _marca.Telefone = maskedTextBoxTelefoneCadastroMarca.Text;

                    _servicoMarca.Atualizar(_marca);
                    string mensagem = "Marca atualizada com sucesso.";
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

        private void AoCarregarTelaDeCadastroMarcaParaEditar(object sender, EventArgs e)
        {
            if (_marca != null)
            {
                textBoxNomeCadastroMarca.Enabled = false;
                maskedTextBoxCNPJCadastroMarca.Enabled = false;
                dateTimePickerDataDeCriacaoCadastroMarca.Enabled = false;
            }
        }
         
        private void PreencherDadosAutomaticamente()
        {
            textBoxNomeCadastroMarca.Text = _marca.Nome;
            maskedTextBoxCNPJCadastroMarca.Text = _marca.Cnpj;
            textBoxEmailCadastroMarca.Text = _marca.Email;
            maskedTextBoxTelefoneCadastroMarca.Text = _marca.Telefone;
            dateTimePickerDataDeCriacaoCadastroMarca.Value = _marca.DataDeCriacao;
        }
    }
}