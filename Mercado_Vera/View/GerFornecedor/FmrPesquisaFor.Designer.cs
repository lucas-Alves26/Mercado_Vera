namespace Mercado_Vera.View.GerFornecedor
{
    partial class FmrPesquisaFor
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
            this.txtNomePes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DgPesqForn = new System.Windows.Forms.DataGridView();
            this.FOR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOR_NOME_FANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOR_CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL_CELULAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL_FIXO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_BAIRRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_RUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgPesqForn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomePes
            // 
            this.txtNomePes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePes.Location = new System.Drawing.Point(9, 33);
            this.txtNomePes.MaxLength = 50;
            this.txtNomePes.Name = "txtNomePes";
            this.txtNomePes.Size = new System.Drawing.Size(375, 24);
            this.txtNomePes.TabIndex = 28;
            this.txtNomePes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyDown);
            this.txtNomePes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomePes_KeyPress);
            this.txtNomePes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nome do fornecedor:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 94);
            this.panel1.TabIndex = 29;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtNomePes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 70);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Controls.Add(this.btnNovo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 84);
            this.panel2.TabIndex = 30;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(24, 22);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.DgPesqForn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 350);
            this.panel3.TabIndex = 31;
            // 
            // DgPesqForn
            // 
            this.DgPesqForn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPesqForn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FOR_ID,
            this.FOR_NOME_FANT,
            this.FOR_CNPJ,
            this.TEL_CELULAR,
            this.TEL_FIXO,
            this.END_BAIRRO,
            this.END_RUA,
            this.END_NUMERO});
            this.DgPesqForn.Location = new System.Drawing.Point(13, 25);
            this.DgPesqForn.Name = "DgPesqForn";
            this.DgPesqForn.RowHeadersWidth = 30;
            this.DgPesqForn.Size = new System.Drawing.Size(799, 319);
            this.DgPesqForn.TabIndex = 0;
            this.DgPesqForn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPesqForn_CellContentClick);
            this.DgPesqForn.DoubleClick += new System.EventHandler(this.DgPesqForn_DoubleClick);
            // 
            // FOR_ID
            // 
            this.FOR_ID.DataPropertyName = "FOR_ID";
            this.FOR_ID.HeaderText = "ID";
            this.FOR_ID.Name = "FOR_ID";
            this.FOR_ID.Width = 30;
            // 
            // FOR_NOME_FANT
            // 
            this.FOR_NOME_FANT.DataPropertyName = "FOR_NOME_FANT";
            this.FOR_NOME_FANT.HeaderText = "Fornecedor";
            this.FOR_NOME_FANT.Name = "FOR_NOME_FANT";
            this.FOR_NOME_FANT.Width = 180;
            // 
            // FOR_CNPJ
            // 
            this.FOR_CNPJ.DataPropertyName = "FOR_CNPJ";
            this.FOR_CNPJ.HeaderText = "CNPJ";
            this.FOR_CNPJ.Name = "FOR_CNPJ";
            // 
            // TEL_CELULAR
            // 
            this.TEL_CELULAR.DataPropertyName = "TEL_CELULAR";
            this.TEL_CELULAR.HeaderText = "Celular";
            this.TEL_CELULAR.Name = "TEL_CELULAR";
            this.TEL_CELULAR.Width = 70;
            // 
            // TEL_FIXO
            // 
            this.TEL_FIXO.DataPropertyName = "TEL_FIXO";
            this.TEL_FIXO.HeaderText = "Tel.Fixo";
            this.TEL_FIXO.Name = "TEL_FIXO";
            this.TEL_FIXO.Width = 70;
            // 
            // END_BAIRRO
            // 
            this.END_BAIRRO.DataPropertyName = "END_BAIRRO";
            this.END_BAIRRO.HeaderText = "Bairro";
            this.END_BAIRRO.Name = "END_BAIRRO";
            this.END_BAIRRO.Width = 87;
            // 
            // END_RUA
            // 
            this.END_RUA.DataPropertyName = "END_RUA";
            this.END_RUA.HeaderText = "Rua";
            this.END_RUA.Name = "END_RUA";
            this.END_RUA.Width = 180;
            // 
            // END_NUMERO
            // 
            this.END_NUMERO.DataPropertyName = "END_NUMERO";
            this.END_NUMERO.HeaderText = "Nº";
            this.END_NUMERO.Name = "END_NUMERO";
            this.END_NUMERO.Width = 50;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(115, 22);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FmrPesquisaFor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 528);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FmrPesquisaFor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa fornecedor";
            this.Load += new System.EventHandler(this.FmrPesquisa_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgPesqForn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomePes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DgPesqForn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOR_NOME_FANT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOR_CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL_CELULAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL_FIXO;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_BAIRRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_RUA;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_NUMERO;
        private System.Windows.Forms.Button btnEditar;
    }
}