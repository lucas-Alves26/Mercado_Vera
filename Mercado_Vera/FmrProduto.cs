using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
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
    public partial class FmrProduto : Form
    {
        //instancioando classe DaoProduto para ter acesso aos metodos
        DaoProduto DaoProd = new DaoProduto();

        public FmrProduto()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FmrProduto_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string categId = cbxCategoria.SelectedValue.ToString();
            DaoProd.produto = new Produto(txtCodigo.Text, txtNome.Text, txtPreco.Text, txtVenda.Text, txtQtd.Text, txtQtdMin.Text, cbxMarca.Text, categId);
            DaoProd.CadastroProd();
            MessageBox.Show("Produto cadastrado com sucesso!");
        }
        public void popularCategoria()
        {
            cbxCategoria.ValueMember = "SUB_CAT_ID";
            cbxCategoria.DisplayMember = "SUB_CAT_TIPO";
            cbxCategoria.DataSource = DaoProd.SelectCategoria();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            popularCategoria();
        }

        private void cbxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbxCategoria_Click(object sender, EventArgs e)
        {
            popularCategoria();
        }
    }
}
