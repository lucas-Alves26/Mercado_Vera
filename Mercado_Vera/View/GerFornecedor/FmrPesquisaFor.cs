﻿using Mercado_Vera.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerFornecedor
{
    public partial class FmrPesquisaFor : Form
    {
        string nome = "";
        DaoFornecedor fornecedor = new DaoFornecedor();

        public FmrPesquisaFor()
        {
            InitializeComponent();
        }

        private void FmrPesquisa_Load(object sender, EventArgs e)
        {          
            DgPesqForn.DataSource = fornecedor.SelectFornCompl(nome);
        }

        private void txtNomePes_KeyDown(object sender, KeyEventArgs e)
        {
            DgPesqForn.DataSource = fornecedor.SelectFornCompl(txtNomePes.Text);
        }

        private void txtNomePes_KeyPress(object sender, KeyPressEventArgs e)
        {
            DgPesqForn.DataSource = fornecedor.SelectFornCompl(txtNomePes.Text);
        }

        private void txtNomePes_KeyUp(object sender, KeyEventArgs e)
        {
            DgPesqForn.DataSource = fornecedor.SelectFornCompl(txtNomePes.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DgPesqForn.DataSource = fornecedor.SelectFornCompl(nome ="");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            FmrFornecedor fornecedor = new FmrFornecedor();
            fornecedor.ShowDialog();

            this.Visible = true;
        }
    }
}