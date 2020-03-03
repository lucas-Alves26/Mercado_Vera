namespace Mercado_Vera.View.GerVenda
{
    partial class FmrPesqProd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNomeProd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMarcaPes = new System.Windows.Forms.ComboBox();
            this.txtCodigoProd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.DgPesquisa = new System.Windows.Forms.DataGridView();
            this.PROD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_VALOR_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_MARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOR_NOME_FANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 89);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNomeProd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxMarcaPes);
            this.groupBox1.Controls.Add(this.txtCodigoProd);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 69);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // txtNomeProd
            // 
            this.txtNomeProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProd.Location = new System.Drawing.Point(163, 34);
            this.txtNomeProd.MaxLength = 50;
            this.txtNomeProd.Name = "txtNomeProd";
            this.txtNomeProd.Size = new System.Drawing.Size(349, 24);
            this.txtNomeProd.TabIndex = 24;
            this.txtNomeProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyDown);
            this.txtNomeProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomePes_KeyPress);
            this.txtNomeProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomePes_KeyUp);
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
            // txtCodigoProd
            // 
            this.txtCodigoProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProd.Location = new System.Drawing.Point(13, 34);
            this.txtCodigoProd.MaxLength = 12;
            this.txtCodigoProd.Name = "txtCodigoProd";
            this.txtCodigoProd.Size = new System.Drawing.Size(134, 24);
            this.txtCodigoProd.TabIndex = 23;
            this.txtCodigoProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPes_KeyDown);
            this.txtCodigoProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPes_KeyPress);
            this.txtCodigoProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPes_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.DgPesquisa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 353);
            this.panel2.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(734, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 30;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DgPesquisa
            // 
            this.DgPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROD_ID,
            this.PROD_COD,
            this.PROD_NOME,
            this.PROD_VALOR_VENDA,
            this.PROD_QTD,
            this.PROD_MARCA,
            this.FOR_NOME_FANT});
            this.DgPesquisa.Location = new System.Drawing.Point(10, 6);
            this.DgPesquisa.Name = "DgPesquisa";
            this.DgPesquisa.RowHeadersWidth = 30;
            this.DgPesquisa.Size = new System.Drawing.Size(799, 306);
            this.DgPesquisa.TabIndex = 29;
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
            this.PROD_NOME.Width = 250;
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
            // PROD_MARCA
            // 
            this.PROD_MARCA.DataPropertyName = "PROD_MARCA";
            this.PROD_MARCA.HeaderText = "Marca";
            this.PROD_MARCA.Name = "PROD_MARCA";
            this.PROD_MARCA.Width = 120;
            // 
            // FOR_NOME_FANT
            // 
            this.FOR_NOME_FANT.DataPropertyName = "FOR_NOME_FANT";
            this.FOR_NOME_FANT.HeaderText = "Fornecedor";
            this.FOR_NOME_FANT.Name = "FOR_NOME_FANT";
            this.FOR_NOME_FANT.Width = 150;
            // 
            // FmrPesqProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 442);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FmrPesqProd";
            this.Text = "FmrPesqProd";
            this.Load += new System.EventHandler(this.FmrPesqProd_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgPesquisa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgPesquisa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNomeProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMarcaPes;
        private System.Windows.Forms.TextBox txtCodigoProd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_VALOR_VENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_MARCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOR_NOME_FANT;
    }
}