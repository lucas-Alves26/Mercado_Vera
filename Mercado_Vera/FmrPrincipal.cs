using Mercado_Vera.View.GerCliente;
using Mercado_Vera.View.GerFornecedor;
using Mercado_Vera.View.GerProduto;
using Mercado_Vera.View.GerVenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera
{
    public partial class FmrPrincipal : Form
    {
        public FmrPrincipal()
        {
            InitializeComponent();
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
   

        }

        private void caixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrCaixa caixa = new FmrCaixa();
            caixa.ShowDialog();
            this.Visible = true;
        }

        private void aberturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrAbertura abertura = new FmrAbertura();
            abertura.ShowDialog();
            this.Visible = true;
        }

        private void consultarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrPesquisa fmrPesquisa = new FmrPesquisa();
            fmrPesquisa.ShowDialog();
            this.Visible = true;
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrCliente fmrCliente = new FmrCliente();
            fmrCliente.ShowDialog();

            this.Visible = true;
        }

        private void cadastroProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrProduto fmrProduto = new FmrProduto();
            fmrProduto.ShowDialog();
            this.Visible = true;
        }

        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            PesqCliente pesqCliente = new PesqCliente();
            pesqCliente.ShowDialog();
            this.Visible = true;
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pesquisaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrPesquisaFor fmrPesquisa = new FmrPesquisaFor();
            fmrPesquisa.ShowDialog();
            this.Visible = true;
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrFornecedor fmrFornecedor = new FmrFornecedor();
            fmrFornecedor.ShowDialog();
            this.Visible = true;
        }

        private void aberturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrAbertura fmrAbertura = new FmrAbertura();
            fmrAbertura.ShowDialog();
            this.Visible = true;
        }

        private void caixaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrCaixa fmrCaixa = new FmrCaixa();
            fmrCaixa.ShowDialog();
            this.Visible = true;
        }
    }
}
