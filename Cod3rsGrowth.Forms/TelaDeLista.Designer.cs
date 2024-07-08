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
            marcaDataGridView = new DataGridView();
            marcaBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tenisDataGridView = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            idmarcaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            linhaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            avaliacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disponibilidadeDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tenisBindingSource = new BindingSource(components);
            textBoxBuscaMarca = new TextBox();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFim = new DateTimePicker();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cnpjDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataDeCriacao = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)marcaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)marcaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tenisDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tenisBindingSource).BeginInit();
            SuspendLayout();
            // 
            // marcaDataGridView
            // 
            marcaDataGridView.AutoGenerateColumns = false;
            marcaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            marcaDataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, cnpjDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, DataDeCriacao });
            marcaDataGridView.DataSource = marcaBindingSource;
            marcaDataGridView.Location = new Point(25, 77);
            marcaDataGridView.Name = "marcaDataGridView";
            marcaDataGridView.RowTemplate.Height = 25;
            marcaDataGridView.Size = new Size(544, 319);
            marcaDataGridView.TabIndex = 0;
            marcaDataGridView.CellClick += marcaDataGridView_CellContentClick;
            marcaDataGridView.CellContentClick += marcaDataGridView_CellContentClick;
            marcaDataGridView.DragDrop += marcaDataGridView_CellContentClick;
            // 
            // marcaBindingSource
            // 
            marcaBindingSource.DataSource = typeof(Marca);
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(25, 424);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(130, 424);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(231, 424);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // tenisDataGridView
            // 
            tenisDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tenisDataGridView.AutoGenerateColumns = false;
            tenisDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tenisDataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, idmarcaDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn1, linhaDataGridViewTextBoxColumn, precoDataGridViewTextBoxColumn, avaliacaoDataGridViewTextBoxColumn, disponibilidadeDataGridViewCheckBoxColumn, lancamentoDataGridViewTextBoxColumn });
            tenisDataGridView.DataSource = tenisBindingSource;
            tenisDataGridView.Location = new Point(595, 77);
            tenisDataGridView.Name = "tenisDataGridView";
            tenisDataGridView.RowTemplate.Height = 25;
            tenisDataGridView.Size = new Size(483, 319);
            tenisDataGridView.TabIndex = 4;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // idmarcaDataGridViewTextBoxColumn
            // 
            idmarcaDataGridViewTextBoxColumn.DataPropertyName = "Idmarca";
            idmarcaDataGridViewTextBoxColumn.HeaderText = "Idmarca";
            idmarcaDataGridViewTextBoxColumn.Name = "idmarcaDataGridViewTextBoxColumn";
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
            precoDataGridViewTextBoxColumn.HeaderText = "Preco";
            precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            // 
            // avaliacaoDataGridViewTextBoxColumn
            // 
            avaliacaoDataGridViewTextBoxColumn.DataPropertyName = "Avaliacao";
            avaliacaoDataGridViewTextBoxColumn.HeaderText = "Avaliacao";
            avaliacaoDataGridViewTextBoxColumn.Name = "avaliacaoDataGridViewTextBoxColumn";
            // 
            // disponibilidadeDataGridViewCheckBoxColumn
            // 
            disponibilidadeDataGridViewCheckBoxColumn.DataPropertyName = "Disponibilidade";
            disponibilidadeDataGridViewCheckBoxColumn.HeaderText = "Disponibilidade";
            disponibilidadeDataGridViewCheckBoxColumn.Name = "disponibilidadeDataGridViewCheckBoxColumn";
            // 
            // lancamentoDataGridViewTextBoxColumn
            // 
            lancamentoDataGridViewTextBoxColumn.DataPropertyName = "Lancamento";
            lancamentoDataGridViewTextBoxColumn.HeaderText = "Lancamento";
            lancamentoDataGridViewTextBoxColumn.Name = "lancamentoDataGridViewTextBoxColumn";
            // 
            // tenisBindingSource
            // 
            tenisBindingSource.DataSource = typeof(Tenis);
            // 
            // textBoxBuscaMarca
            // 
            textBoxBuscaMarca.Location = new Point(25, 33);
            textBoxBuscaMarca.Name = "textBoxBuscaMarca";
            textBoxBuscaMarca.PlaceholderText = "Buscar Por Nome";
            textBoxBuscaMarca.Size = new Size(243, 23);
            textBoxBuscaMarca.TabIndex = 7;
            textBoxBuscaMarca.TextChanged += textBoxBuscaMarca_TextChanged;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(289, 4);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(256, 23);
            dateTimePickerInicio.TabIndex = 8;
            dateTimePickerInicio.ValueChanged += dateTimePickerInicio_ValueChanged;
            // 
            // dateTimePickerFim
            // 
            dateTimePickerFim.Location = new Point(289, 33);
            dateTimePickerFim.Name = "dateTimePickerFim";
            dateTimePickerFim.Size = new Size(256, 23);
            dateTimePickerFim.TabIndex = 9;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // cnpjDataGridViewTextBoxColumn
            // 
            cnpjDataGridViewTextBoxColumn.DataPropertyName = "Cnpj";
            cnpjDataGridViewTextBoxColumn.HeaderText = "Cnpj";
            cnpjDataGridViewTextBoxColumn.Name = "cnpjDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            // 
            // DataDeCriacao
            // 
            DataDeCriacao.DataPropertyName = "DataDeCriacao";
            DataDeCriacao.HeaderText = "DataDeCriacao";
            DataDeCriacao.Name = "DataDeCriacao";
            // 
            // TelaDeLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 459);
            Controls.Add(dateTimePickerFim);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(textBoxBuscaMarca);
            Controls.Add(tenisDataGridView);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(marcaDataGridView);
            Name = "TelaDeLista";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)marcaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)marcaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tenisDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tenisBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView marcaDataGridView;
        private Button button1;
        private Button button2;
        private Button button3;
        private BindingSource marcaBindingSource;
        private DataGridView tenisDataGridView;
        private BindingSource tenisBindingSource;
        private TextBox textBoxBuscaMarca;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idmarcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn linhaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn avaliacaoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn disponibilidadeDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn lancamentoDataGridViewTextBoxColumn;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFim;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cnpjDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DataDeCriacao;
    }
}