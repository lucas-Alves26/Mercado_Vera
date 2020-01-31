namespace Mercado_Vera.View.GerProduto
{
    partial class tstExcluir
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.DgExcluir = new System.Windows.Forms.DataGridView();
            this.PROD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_MARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNomeEx = new System.Windows.Forms.TextBox();
            this.txtCodigoEx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgExcluir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxMarca);
            this.panel1.Controls.Add(this.BtnExcluir);
            this.panel1.Controls.Add(this.DgExcluir);
            this.panel1.Controls.Add(this.txtNomeEx);
            this.panel1.Controls.Add(this.txtCodigoEx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 419);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Marca";
            // 
            // cbxMarca
            // 
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Items.AddRange(new object[] {
            "\"\""});
            this.cbxMarca.Location = new System.Drawing.Point(438, 42);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(140, 21);
            this.cbxMarca.TabIndex = 19;
            this.cbxMarca.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbxMarca.SelectionChangeCommitted += new System.EventHandler(this.cbxMarca_SelectionChangeCommitted);
            this.cbxMarca.Click += new System.EventHandler(this.comboBox1_Click);
            this.cbxMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxMarca_KeyDown);
            this.cbxMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxMarca_KeyPress);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(415, 372);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 18;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // DgExcluir
            // 
            this.DgExcluir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgExcluir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROD_ID,
            this.PROD_COD,
            this.PROD_NOME,
            this.PROD_VALOR,
            this.PROD_QTD,
            this.PROD_MARCA});
            this.DgExcluir.Location = new System.Drawing.Point(12, 90);
            this.DgExcluir.Name = "DgExcluir";
            this.DgExcluir.Size = new System.Drawing.Size(566, 265);
            this.DgExcluir.TabIndex = 17;
            this.DgExcluir.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgExcluir_CellContentClick);
            this.DgExcluir.DoubleClick += new System.EventHandler(this.DgExcluir_DoubleClick);
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
            this.PROD_COD.HeaderText = "Código";
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
            this.PROD_VALOR.HeaderText = "Preço";
            this.PROD_VALOR.Name = "PROD_VALOR";
            this.PROD_VALOR.Width = 70;
            // 
            // PROD_QTD
            // 
            this.PROD_QTD.DataPropertyName = "PROD_QTD";
            this.PROD_QTD.HeaderText = "Qtd.";
            this.PROD_QTD.Name = "PROD_QTD";
            this.PROD_QTD.Width = 38;
            // 
            // PROD_MARCA
            // 
            this.PROD_MARCA.DataPropertyName = "PROD_MARCA";
            this.PROD_MARCA.HeaderText = "Marca";
            this.PROD_MARCA.Name = "PROD_MARCA";
            this.PROD_MARCA.Width = 103;
            // 
            // txtNomeEx
            // 
            this.txtNomeEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeEx.Location = new System.Drawing.Point(162, 42);
            this.txtNomeEx.MaxLength = 50;
            this.txtNomeEx.Name = "txtNomeEx";
            this.txtNomeEx.Size = new System.Drawing.Size(259, 24);
            this.txtNomeEx.TabIndex = 16;
            this.txtNomeEx.TextChanged += new System.EventHandler(this.txtNomeEx_TextChanged);
            // 
            // txtCodigoEx
            // 
            this.txtCodigoEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoEx.Location = new System.Drawing.Point(12, 42);
            this.txtCodigoEx.MaxLength = 12;
            this.txtCodigoEx.Name = "txtCodigoEx";
            this.txtCodigoEx.Size = new System.Drawing.Size(134, 24);
            this.txtCodigoEx.TabIndex = 15;
            this.txtCodigoEx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome do produto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cód. Barra:";
            // 
            // tstExcluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 504);
            this.Controls.Add(this.panel1);
            this.Name = "tstExcluir";
            this.Text = "tstExcluir";
            this.Load += new System.EventHandler(this.tstExcluir_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgExcluir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgExcluir;
        private System.Windows.Forms.TextBox txtNomeEx;
        private System.Windows.Forms.TextBox txtCodigoEx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_MARCA;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMarca;
    }
}