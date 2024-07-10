﻿namespace Cod3rsGrowth.Forms
{
    partial class TelaDeCadastroMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            maskedTextBoxTelefoneCadastroMarca = new MaskedTextBox();
            maskedTextBoxCNPJCadastroMarca = new MaskedTextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerDataDeCriacaoCadastroMarca = new DateTimePicker();
            textBoxEmailCadastroMarca = new TextBox();
            textBoxNomeCadastroMarca = new TextBox();
            botaoSalvarCadastroMarca = new Button();
            botaoCancelarCadastroMarca = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(maskedTextBoxTelefoneCadastroMarca);
            groupBox1.Controls.Add(maskedTextBoxCNPJCadastroMarca);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePickerDataDeCriacaoCadastroMarca);
            groupBox1.Controls.Add(textBoxEmailCadastroMarca);
            groupBox1.Controls.Add(textBoxNomeCadastroMarca);
            groupBox1.Location = new Point(17, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 288);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informações Da Marca";
            // 
            // maskedTextBoxTelefoneCadastroMarca
            // 
            maskedTextBoxTelefoneCadastroMarca.Location = new Point(181, 165);
            maskedTextBoxTelefoneCadastroMarca.Mask = "(00)00000-0000";
            maskedTextBoxTelefoneCadastroMarca.Name = "maskedTextBoxTelefoneCadastroMarca";
            maskedTextBoxTelefoneCadastroMarca.Size = new Size(132, 23);
            maskedTextBoxTelefoneCadastroMarca.TabIndex = 11;
            // 
            // maskedTextBoxCNPJCadastroMarca
            // 
            maskedTextBoxCNPJCadastroMarca.Location = new Point(13, 165);
            maskedTextBoxCNPJCadastroMarca.Mask = "00,000,000/0000-00";
            maskedTextBoxCNPJCadastroMarca.Name = "maskedTextBoxCNPJCadastroMarca";
            maskedTextBoxCNPJCadastroMarca.Size = new Size(128, 23);
            maskedTextBoxCNPJCadastroMarca.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 201);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 9;
            label5.Text = "Data de criação";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 144);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 8;
            label4.Text = "Telefone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 144);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 6;
            label3.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 5;
            label2.Text = "E-mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // dateTimePickerDataDeCriacaoCadastroMarca
            // 
            dateTimePickerDataDeCriacaoCadastroMarca.Format = DateTimePickerFormat.Short;
            dateTimePickerDataDeCriacaoCadastroMarca.Location = new Point(13, 224);
            dateTimePickerDataDeCriacaoCadastroMarca.Name = "dateTimePickerDataDeCriacaoCadastroMarca";
            dateTimePickerDataDeCriacaoCadastroMarca.Size = new Size(128, 23);
            dateTimePickerDataDeCriacaoCadastroMarca.TabIndex = 3;
            // 
            // textBoxEmailCadastroMarca
            // 
            textBoxEmailCadastroMarca.Location = new Point(12, 104);
            textBoxEmailCadastroMarca.Name = "textBoxEmailCadastroMarca";
            textBoxEmailCadastroMarca.Size = new Size(301, 23);
            textBoxEmailCadastroMarca.TabIndex = 1;
            // 
            // textBoxNomeCadastroMarca
            // 
            textBoxNomeCadastroMarca.Location = new Point(11, 47);
            textBoxNomeCadastroMarca.Name = "textBoxNomeCadastroMarca";
            textBoxNomeCadastroMarca.Size = new Size(302, 23);
            textBoxNomeCadastroMarca.TabIndex = 0;
            textBoxNomeCadastroMarca.TextChanged += aoClicarNoBotaoSalvarCadastroMarca;
            // 
            // botaoSalvarCadastroMarca
            // 
            botaoSalvarCadastroMarca.Location = new Point(17, 331);
            botaoSalvarCadastroMarca.Name = "botaoSalvarCadastroMarca";
            botaoSalvarCadastroMarca.Size = new Size(75, 23);
            botaoSalvarCadastroMarca.TabIndex = 1;
            botaoSalvarCadastroMarca.Text = "Salvar";
            botaoSalvarCadastroMarca.UseVisualStyleBackColor = true;
            botaoSalvarCadastroMarca.Click += aoClicarNoBotaoSalvarCadastroMarca;
            // 
            // botaoCancelarCadastroMarca
            // 
            botaoCancelarCadastroMarca.Location = new Point(281, 331);
            botaoCancelarCadastroMarca.Name = "botaoCancelarCadastroMarca";
            botaoCancelarCadastroMarca.Size = new Size(75, 23);
            botaoCancelarCadastroMarca.TabIndex = 2;
            botaoCancelarCadastroMarca.Text = "Cancelar";
            botaoCancelarCadastroMarca.UseVisualStyleBackColor = true;
            botaoCancelarCadastroMarca.Click += aoClicarNoBotaoCancelarCadastroMarca;
            // 
            // TelaDeCadastroMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 376);
            Controls.Add(botaoCancelarCadastroMarca);
            Controls.Add(botaoSalvarCadastroMarca);
            Controls.Add(groupBox1);
            Name = "TelaDeCadastroMarca";
            Text = "Cadastrar Marca";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxNomeCadastroMarca;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerDataDeCriacaoCadastroMarca;
        private TextBox textBoxEmailCadastroMarca;
        private Label label5;
        private Button botaoSalvarCadastroMarca;
        private Button botaoCancelarCadastroMarca;
        private MaskedTextBox maskedTextBoxTelefoneCadastroMarca;
        private MaskedTextBox maskedTextBoxCNPJCadastroMarca;
    }
}