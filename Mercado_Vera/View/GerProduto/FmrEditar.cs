using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerProduto
{
    public partial class FmrEditar : Form
    {
        DaoProduto daoProd = new DaoProduto();
        DaoFornecedor daoForn = new DaoFornecedor();


        string id;
        string catId;
        string fornId;
        public void GetId(string id)
        {
            this.id = id;
        }

        public FmrEditar()


        {
            InitializeComponent();

        }



        private void FmrEditar_Load(object sender, EventArgs e)
        {
            
            PopularCategoria();
            PopularFornecedor();
            SqlDataReader dt;

            dt = daoProd.SelectProdCompletoId(id);
            txtCodigo.Text = dt["PROD_COD"].ToString();
            txtNome.Text = dt["PROD_NOME"].ToString();
            txtPreco.Text = dt["PROD_VALOR"].ToString();
            txtVenda.Text= dt["PROD_VALOR_VENDA"].ToString();
            txtQtd.Text= dt["PROD_QTD"].ToString();
            txtQtdMin.Text= dt["PROD_QTD_MIN"].ToString();
            cbxCategoria.Text= dt["SUB_CAT_TIPO"].ToString();
            cbxMarca.Text = dt["PROD_MARCA"].ToString();
            cbxFornecedor.Text= dt["FOR_NOME_FANT"].ToString();
            catId = dt["SUB_CAT_ID"].ToString();
            fornId = dt["FOR_ID"].ToString();
        }

        private void cbxMarca_Click(object sender, EventArgs e)
        {
            PopularMarca();
            cbxMarca.DataSource = daoProd.SelectMarca();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void cbxCategoria_Click(object sender, EventArgs e)
        {     
            PopularCategoria();
        }

        private void cbxFornecedor_Click(object sender, EventArgs e)
        {
            PopularFornecedor();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {           

            try
            {

                catId = cbxCategoria.SelectedValue.ToString();

                if (cbxFornecedor.Text != "")
                {
                    fornId = cbxFornecedor.SelectedValue.ToString();
                }

                daoProd.produto = new Produto(id,txtCodigo.Text, txtNome.Text, txtPreco.Text, txtVenda.Text, txtQtd.Text, txtQtdMin.Text, cbxMarca.Text, catId, fornId);
                daoProd.EditarProd(id);
                MessageBox.Show("Produto atualizado com sucesso!");

            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void PopularCategoria()
        {
            cbxCategoria.ValueMember = "SUB_CAT_ID";
            cbxCategoria.DisplayMember = "SUB_CAT_TIPO";
            cbxCategoria.DataSource = daoProd.SelectCategoria();
        }
        public void PopularFornecedor()
        {
            cbxFornecedor.ValueMember = "FOR_ID";
            cbxFornecedor.DisplayMember = "FOR_NOME_FANT";
            cbxFornecedor.DataSource = daoForn.SelectForne();
        }
        public void PopularMarca()
        {
            cbxMarca.ValueMember = "PROD_MARCA";
            cbxMarca.DisplayMember = "PROD_MARCA";
        }
    }
}
