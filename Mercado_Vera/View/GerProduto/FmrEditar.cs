using Mercado_Vera.Dao;
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
            SqlDataReader dt;

            dt = daoProd.SelectProdCompletoId(id);
            txtCodigo.Text = dt["PROD_COD"].ToString();
            txtNome.Text = dt["PROD_NOME"].ToString();
            txtPreco.Text = dt["PROD_VALOR"].ToString();
            txtVenda.Text= dt["PROD_VALOR_VENDA"].ToString();
            txtQtd.Text= dt["PROD_QTD"].ToString();
            txtQtdMin.Text= dt["PROD_QTD_MIN"].ToString();
            cbxCategoria.Text= dt["SUB_CAT_TIPO"].ToString();
            cbxMarca.Text= dt["PROD_MARCA"].ToString();
            cbxFornecedor.Text= dt["FOR_NOME_FANT"].ToString();
            
        }

        private void cbxMarca_Click(object sender, EventArgs e)
        {
            cbxMarca.ValueMember = "PROD_MARCA";
            cbxMarca.DisplayMember = "PROD_MARCA";
            cbxMarca.DataSource = daoProd.SelectMarca();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void cbxCategoria_Click(object sender, EventArgs e)
        {
            cbxCategoria.ValueMember = "SUB_CAT_ID";
            cbxCategoria.DisplayMember = "SUB_CAT_TIPO";
            cbxCategoria.DataSource = daoProd.SelectCategoria();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void cbxFornecedor_Click(object sender, EventArgs e)
        {
            cbxFornecedor.ValueMember = "FOR_ID";
            cbxFornecedor.DisplayMember = "FOR_NOME_FANT";
            cbxFornecedor.DataSource = daoForn.SelectForne();
        }
    }
}
