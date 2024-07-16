namespace Cod3rsGrowth.Forms
{
    partial class TelaDeLista : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            marcaDataGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cnpjDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataDeCriacao = new DataGridViewTextBoxColumn();
            marcaBindingSource = new BindingSource(components);
            botaoAdicionar = new Button();
            botaoEditar = new Button();
            botaoRemover = new Button();
            tenisDataGridView = new DataGridView();
            tenisBindingSource = new BindingSource(components);
            textBoxBuscaMarca = new TextBox();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFim = new DateTimePicker();
            descricaoCalendarioMarca = new Label();
            dataInicioCalendario = new Label();
            dataFimCalendario = new Label();
            groupBox1 = new GroupBox();
            botaoLimparFiltros = new Button();
            labelTabelatenis = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            IdMarca = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            linhaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Disponibilidade = new DataGridViewCheckBoxColumn();
            avaliacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)marcaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)marcaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tenisDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tenisBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // marcaDataGridView
            // 
            marcaDataGridView.AutoGenerateColumns = false;
            marcaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            marcaDataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, cnpjDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, DataDeCriacao });
            marcaDataGridView.DataSource = marcaBindingSource;
            marcaDataGridView.Location = new Point(12, 175);
            marcaDataGridView.Name = "marcaDataGridView";
            marcaDataGridView.RowTemplate.Height = 25;
            marcaDataGridView.Size = new Size(641, 242);
            marcaDataGridView.TabIndex = 0;
            marcaDataGridView.CellClick += AoClicarNoMarcaDataGridView;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "ID";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cnpjDataGridViewTextBoxColumn
            // 
            cnpjDataGridViewTextBoxColumn.DataPropertyName = "Cnpj";
            cnpjDataGridViewTextBoxColumn.HeaderText = "CNPJ";
            cnpjDataGridViewTextBoxColumn.Name = "cnpjDataGridViewTextBoxColumn";
            cnpjDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DataDeCriacao
            // 
            DataDeCriacao.DataPropertyName = "DataDeCriacao";
            DataDeCriacao.HeaderText = "Data De Criação";
            DataDeCriacao.Name = "DataDeCriacao";
            DataDeCriacao.ReadOnly = true;
            // 
            // marcaBindingSource
            // 
            marcaBindingSource.DataSource = typeof(Marca);
            // 
            // botaoAdicionar
            // 
            botaoAdicionar.ForeColor = SystemColors.ControlText;
            botaoAdicionar.Location = new Point(25, 440);
            botaoAdicionar.Name = "botaoAdicionar";
            botaoAdicionar.Size = new Size(75, 23);
            botaoAdicionar.TabIndex = 1;
            botaoAdicionar.Text = "Adicionar";
            botaoAdicionar.UseVisualStyleBackColor = true;
            botaoAdicionar.Click += AoClicarNoBotaoAdicionarMarca;
            // 
            // botaoEditar
            // 
            botaoEditar.Location = new Point(129, 440);
            botaoEditar.Name = "botaoEditar";
            botaoEditar.Size = new Size(75, 23);
            botaoEditar.TabIndex = 2;
            botaoEditar.Text = "Editar";
            botaoEditar.UseVisualStyleBackColor = true;
            // 
            // botaoRemover
            // 
            botaoRemover.Location = new Point(236, 440);
            botaoRemover.Name = "botaoRemover";
            botaoRemover.Size = new Size(75, 23);
            botaoRemover.TabIndex = 3;
            botaoRemover.Text = "Remover";
            botaoRemover.UseVisualStyleBackColor = true;
            // 
            // tenisDataGridView
            // 
            tenisDataGridView.AllowUserToAddRows = false;
            tenisDataGridView.AllowUserToDeleteRows = false;
            tenisDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tenisDataGridView.AutoGenerateColumns = false;
            tenisDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tenisDataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, IdMarca, nomeDataGridViewTextBoxColumn1, linhaDataGridViewTextBoxColumn, precoDataGridViewTextBoxColumn, Disponibilidade, avaliacaoDataGridViewTextBoxColumn, lancamentoDataGridViewTextBoxColumn });
            tenisDataGridView.DataSource = tenisBindingSource;
            tenisDataGridView.Location = new Point(688, 31);
            tenisDataGridView.Name = "tenisDataGridView";
            tenisDataGridView.RowTemplate.Height = 25;
            tenisDataGridView.Size = new Size(427, 386);
            tenisDataGridView.TabIndex = 4;
            // 
            // tenisBindingSource
            // 
            tenisBindingSource.DataSource = typeof(Tenis);
            // 
            // textBoxBuscaMarca
            // 
            textBoxBuscaMarca.Location = new Point(6, 22);
            textBoxBuscaMarca.Name = "textBoxBuscaMarca";
            textBoxBuscaMarca.PlaceholderText = "Buscar Por Nome";
            textBoxBuscaMarca.Size = new Size(243, 23);
            textBoxBuscaMarca.TabIndex = 7;
            textBoxBuscaMarca.TextChanged += AoAlterarTextBoxBuscaMarca;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerInicio.Location = new Point(34, 84);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(97, 23);
            dateTimePickerInicio.TabIndex = 8;
            dateTimePickerInicio.Value = new DateTime(2024, 7, 9, 0, 0, 0, 0);
            dateTimePickerInicio.ValueChanged += AoAlterarDateTimePickerInicio;
            // 
            // dateTimePickerFim
            // 
            dateTimePickerFim.Format = DateTimePickerFormat.Short;
            dateTimePickerFim.Location = new Point(34, 117);
            dateTimePickerFim.Name = "dateTimePickerFim";
            dateTimePickerFim.Size = new Size(97, 23);
            dateTimePickerFim.TabIndex = 9;
            dateTimePickerFim.Value = new DateTime(2024, 7, 9, 0, 0, 0, 0);
            dateTimePickerFim.ValueChanged += AoAlterarDateTimePickerFim;
            // 
            // descricaoCalendarioMarca
            // 
            descricaoCalendarioMarca.AutoSize = true;
            descricaoCalendarioMarca.BackColor = SystemColors.ButtonFace;
            descricaoCalendarioMarca.Location = new Point(7, 60);
            descricaoCalendarioMarca.Name = "descricaoCalendarioMarca";
            descricaoCalendarioMarca.Size = new Size(111, 15);
            descricaoCalendarioMarca.TabIndex = 10;
            descricaoCalendarioMarca.Text = "Fundação da marca";
            // 
            // dataInicioCalendario
            // 
            dataInicioCalendario.AutoSize = true;
            dataInicioCalendario.Location = new Point(7, 84);
            dataInicioCalendario.Name = "dataInicioCalendario";
            dataInicioCalendario.Size = new Size(24, 15);
            dataInicioCalendario.TabIndex = 11;
            dataInicioCalendario.Text = "De:";
            // 
            // dataFimCalendario
            // 
            dataFimCalendario.AutoSize = true;
            dataFimCalendario.Location = new Point(6, 123);
            dataFimCalendario.Name = "dataFimCalendario";
            dataFimCalendario.Size = new Size(28, 15);
            dataFimCalendario.TabIndex = 12;
            dataFimCalendario.Text = "Até:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(botaoLimparFiltros);
            groupBox1.Controls.Add(textBoxBuscaMarca);
            groupBox1.Controls.Add(dataFimCalendario);
            groupBox1.Controls.Add(dateTimePickerInicio);
            groupBox1.Controls.Add(dataInicioCalendario);
            groupBox1.Controls.Add(dateTimePickerFim);
            groupBox1.Controls.Add(descricaoCalendarioMarca);
            groupBox1.Location = new Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(641, 151);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar marca";
            // 
            // botaoLimparFiltros
            // 
            botaoLimparFiltros.Location = new Point(525, 117);
            botaoLimparFiltros.Name = "botaoLimparFiltros";
            botaoLimparFiltros.Size = new Size(110, 23);
            botaoLimparFiltros.TabIndex = 13;
            botaoLimparFiltros.Text = "Limpar Filtros";
            botaoLimparFiltros.UseVisualStyleBackColor = true;
            botaoLimparFiltros.Click += AoClicarNoBotaoLimparFiltros;
            // 
            // labelTabelatenis
            // 
            labelTabelatenis.AutoSize = true;
            labelTabelatenis.Location = new Point(689, 7);
            labelTabelatenis.Name = "labelTabelatenis";
            labelTabelatenis.Size = new Size(151, 15);
            labelTabelatenis.TabIndex = 14;
            labelTabelatenis.Text = "Relação De Tênis Por Marca";
            // 
            // button1
            // 
            button1.Location = new Point(836, 440);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AoClicarNoBotaoAdicionarTenis;
            // 
            // button2
            // 
            button2.Location = new Point(940, 440);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 16;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1040, 440);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 17;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "ID";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // IdMarca
            // 
            IdMarca.DataPropertyName = "IdMarca";
            IdMarca.HeaderText = "IdMarca";
            IdMarca.Name = "IdMarca";
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            // 
            // linhaDataGridViewTextBoxColumn
            // 
            linhaDataGridViewTextBoxColumn.DataPropertyName = "Linha";
            linhaDataGridViewTextBoxColumn.HeaderText = "Linha";
            linhaDataGridViewTextBoxColumn.Name = "linhaDataGridViewTextBoxColumn";
            // 
            // precoDataGridViewTextBoxColumn
            // 
            precoDataGridViewTextBoxColumn.DataPropertyName = "Preco";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            precoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            precoDataGridViewTextBoxColumn.HeaderText = "Preço";
            precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            // 
            // Disponibilidade
            // 
            Disponibilidade.DataPropertyName = "Disponibilidade";
            Disponibilidade.HeaderText = "Disponível";
            Disponibilidade.Name = "Disponibilidade";
            // 
            // avaliacaoDataGridViewTextBoxColumn
            // 
            avaliacaoDataGridViewTextBoxColumn.DataPropertyName = "Avaliacao";
            avaliacaoDataGridViewTextBoxColumn.HeaderText = "Avaliação";
            avaliacaoDataGridViewTextBoxColumn.Name = "avaliacaoDataGridViewTextBoxColumn";
            // 
            // lancamentoDataGridViewTextBoxColumn
            // 
            lancamentoDataGridViewTextBoxColumn.DataPropertyName = "Lancamento";
            lancamentoDataGridViewTextBoxColumn.HeaderText = "Lançamento";
            lancamentoDataGridViewTextBoxColumn.Name = "lancamentoDataGridViewTextBoxColumn";
            // 
            // TelaDeLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 489);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelTabelatenis);
            Controls.Add(groupBox1);
            Controls.Add(tenisDataGridView);
            Controls.Add(botaoRemover);
            Controls.Add(botaoEditar);
            Controls.Add(botaoAdicionar);
            Controls.Add(marcaDataGridView);
            Name = "TelaDeLista";
            Text = "Formulário Comercial";
            ((System.ComponentModel.ISupportInitialize)marcaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)marcaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tenisDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tenisBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView marcaDataGridView;
        private Button botaoAdicionar;
        private Button botaoEditar;
        private Button botaoRemover;
        private BindingSource marcaBindingSource;
        private DataGridView tenisDataGridView;
        private BindingSource tenisBindingSource;
        private TextBox textBoxBuscaMarca;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFim;
        private Label descricaoCalendarioMarca;
        private Label dataInicioCalendario;
        private Label dataFimCalendario;
        private GroupBox groupBox1;
        private Button botaoLimparFiltros;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cnpjDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DataDeCriacao;
        private Label labelTabelatenis;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridViewCheckBoxColumn disponibilidadeDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idmarcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn linhaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn Disponibilidade;
        private DataGridViewTextBoxColumn avaliacaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lancamentoDataGridViewTextBoxColumn;
    }
}