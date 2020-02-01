namespace Mercado_Vera.View.GerProduto
{
    partial class FmrPesquisa
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMarcaPes = new System.Windows.Forms.ComboBox();
            this.txtNomePes = new System.Windows.Forms.TextBox();
            this.txtCodigoPes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgPesquisa = new System.Windows.Forms.DataGridView();
            this.PROD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_VALOR_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTD_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_MARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOR_NOME_FANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgPesquisa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Marca";
            // 
            // cbxMarcaPes
            // 
            this.cbxMarcaPes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarcaPes.FormattingEnabled = true;
            this.cbxMarcaPes.Items.AddRange(new object[] {
            "\"\""});
            this.cbxMarcaPes.Location = new System.Drawing.Point(530, 34);
            this.cbxMarcaPes.Name = "cbxMarcaPes";
            this.cbxMarcaPes.Size = new System.Drawing.Size(140, 21);
            this.cbxMarcaPes.TabIndex = 25;
            this.cbxMarcaPes.SelectedIndexChanged += new System.EventHandler(this.cbxMarcaPes_SelectedIndexChanged);
            this.cbxMarcaPes.Click += new System.EventHandler(this.cbxMarcaPes_Click);
            // 
            // txtNomePes
            // 
            this.txtNomePes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePes.Location = new System.Drawing.Point(163, 34);
            this.txtNomePes.MaxLength = 50;
            this.txtNomePes.Name = "txtNomePes";
            this.txtNomePes.Size = new System.Drawing.Size(349, 24);
            this.txtNomePes.TabIndex = 24;
            this.txtNomePes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyDown);
            this.txtNomePes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomePes_KeyPress);
            this.txtNomePes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyUp);
            // 
            // txtCodigoPes
            // 
            this.txtCodigoPes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPes.Location = new System.Drawing.Point(13, 34);
            this.txtCodigoPes.MaxLength = 12;
            this.txtCodigoPes.Name = "txtCodigoPes";
            this.txtCodigoPes.Size = new System.Drawing.Size(134, 24);
            this.txtCodigoPes.TabIndex = 23;
            this.txtCodigoPes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoPes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPes_KeyDown);
            this.txtCodigoPes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPes_KeyPress);
            this.txtCodigoPes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPes_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nome do produto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cód. Barra:";
            // 
            // DgPesquisa
            // 
            this.DgPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROD_ID,
            this.PROD_COD,
            this.PROD_NOME,
            this.PROD_VALOR,
            this.PROD_VALOR_VENDA,
            this.PROD_QTD,
            this.PROD_QTD_MIN,
            this.PROD_MARCA,
            this.FOR_NOME_FANT});
            this.DgPesquisa.Location = new System.Drawing.Point(15, 87);
            this.DgPesquisa.Name = "DgPesquisa";
            this.DgPesquisa.Size = new System.Drawing.Size(797, 308);
            this.DgPesquisa.TabIndex = 27;
            this.DgPesquisa.DoubleClick += new System.EventHandler(this.DgPesquisa_DoubleClick);
            // 
            // PROD_ID
            // 
            this.PROD_ID.DataPropertyName = "PROD_ID";
            this.PROD_ID.HeaderText = "ID";
            this.PROD_ID.Name = "PROD_ID";
            this.PROD_ID.Width = 32;
            // 
            // PROD_COD
            // 
            this.PROD_COD.DataPropertyName = "PROD_COD";
            this.PROD_COD.HeaderText = "Cód.Barra";
            this.PROD_COD.Name = "PROD_COD";
            // 
            // PROD_NOME
            // 
            this.PROD_NOME.DataPropertyName = "PROD_NOME";
            this.PROD_NOME.HeaderText = "Nome";
            this.PROD_NOME.Name = "PROD_NOME";
            this.PROD_NOME.Width = 180;
            // 
            // PROD_VALOR
            // 
            this.PROD_VALOR.DataPropertyName = "PROD_VALOR";
            this.PROD_VALOR.HeaderText = "P.Cusco";
            this.PROD_VALOR.Name = "PROD_VALOR";
            this.PROD_VALOR.Width = 60;
            // 
            // PROD_VALOR_VENDA
            // 
            this.PROD_VALOR_VENDA.DataPropertyName = "PROD_VALOR_VENDA";
            this.PROD_VALOR_VENDA.HeaderText = "P.Venda";
            this.PROD_VALOR_VENDA.Name = "PROD_VALOR_VENDA";
            this.PROD_VALOR_VENDA.Width = 60;
            // 
            // PROD_QTD
            // 
            this.PROD_QTD.DataPropertyName = "PROD_QTD";
            this.PROD_QTD.HeaderText = "Qtd.Total";
            this.PROD_QTD.Name = "PROD_QTD";
            this.PROD_QTD.Width = 55;
            // 
            // PROD_QTD_MIN
            // 
            this.PROD_QTD_MIN.DataPropertyName = "PROD_QTD_MIN";
            this.PROD_QTD_MIN.HeaderText = "Qtd.Minima";
            this.PROD_QTD_MIN.Name = "PROD_QTD_MIN";
            this.PROD_QTD_MIN.Width = 65;
            // 
            // PROD_MARCA
            // 
            this.PROD_MARCA.DataPropertyName = "PROD_MARCA";
            this.PROD_MARCA.HeaderText = "Marca";
            this.PROD_MARCA.Name = "PROD_MARCA";
            // 
            // FOR_NOME_FANT
            // 
            this.FOR_NOME_FANT.DataPropertyName = "FOR_NOME_FANT";
            this.FOR_NOME_FANT.HeaderText = "Fornecedor";
            this.FOR_NOME_FANT.Name = "FOR_NOME_FANT";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNomePes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxMarcaPes);
            this.groupBox1.Controls.Add(this.txtCodigoPes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 69);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(736, 415);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(75, 23);
            this.BtnEditar.TabIndex = 29;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            // 
            // FmrPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgPesquisa);
            this.Name = "FmrPesquisa";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FmrPesquisa_Load);
            this.DoubleClick += new System.EventHandler(this.FmrPesquisa_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.DgPesquisa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMarcaPes;
        private System.Windows.Forms.TextBox txtNomePes;
        private System.Windows.Forms.TextBox txtCodigoPes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgPesquisa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_VALOR_VENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTD_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_MARCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOR_NOME_FANT;
    }
}