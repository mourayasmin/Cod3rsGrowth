using Cod3rsGrowth.Servicos.Servicos;


namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroMarca : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly DataGridView marcaDataGridView;

        public TelaDeCadastroMarca(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
        }

        private void aoClicarNoBotaoSalvarCadastroMarca(object sender, EventArgs e)
        {
            maskedTextBoxCNPJCadastroMarca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            maskedTextBoxTelefoneCadastroMarca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var mensagemDeSucesso = "Marca cadastrada com sucesso.";

            try
            {
                Marca marcaAdicionada = new Marca
                {
                    Nome = textBoxNomeCadastroMarca.Text,
                    Cnpj = maskedTextBoxCNPJCadastroMarca.Text,
                    Email = textBoxEmailCadastroMarca.Text,
                    Telefone = maskedTextBoxTelefoneCadastroMarca.Text,
                    DataDeCriacao = dateTimePickerDataDeCriacaoCadastroMarca.Value
                };
                _servicoMarca.Criar(marcaAdicionada);
                MessageBox.Show(mensagemDeSucesso);
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void aoClicarNoBotaoCancelarCadastroMarca(object sender, EventArgs e)
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
