using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaDeCadastroTenis : Form
    {

        private readonly ServicoMarca _servicoMarca;
        private readonly ServicoTenis _servicoTenis;
        private readonly DataGridView _tenisDataGridView;
        private readonly ValidacaoTenis _validacaoTenis;
        public TelaDeCadastroTenis(ServicoMarca servicoMarca, ServicoTenis servicoTenis)
        {
            _servicoMarca = servicoMarca;
            _servicoTenis = servicoTenis;
            InitializeComponent();
        }

        private void AoClicarNoBotaoSalvarCadastroTenis(object sender, EventArgs e)
        {

            try
            {
                Tenis tenisAdicionado = new Tenis
                {
                    Nome = textBoxNomeCadastroTenis.Text,
                    Linha = (LinhaEnum)comboBoxLinhaCadastroTenis.SelectedItem,
                    Preco = Double.Parse(textBoxPrecoCadastroTenis.Text),
                    Avaliacao = Decimal.Parse(textBoxAvaliacaoCadastroTenis.Text),
                    Idmarca = int.Parse(textBoxIdMarcaCadastroTenis.Text),
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
            comboBoxLinhaCadastroTenis.Items.Clear();
            textBoxPrecoCadastroTenis.Clear();
            textBoxAvaliacaoCadastroTenis.Clear();
            textBoxIdMarcaCadastroTenis.Clear();
            checkBoxDisponibilidadeCadastroTenis.Enabled = false;
            dateTimePickerLancamentoCadastroTenis.Value = DateTime.Today.Date;
            this.Close();
        }

        private void TelaDeCadastroTenis_Load(object sender, EventArgs e)
        {
            comboBoxLinhaCadastroTenis.DataSource = Enum.GetValues(typeof(LinhaEnum));
        }
    }
}
