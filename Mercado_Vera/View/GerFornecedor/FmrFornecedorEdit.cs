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

namespace Mercado_Vera.View.GerFornecedor
{
    public partial class FmrFornecedorEdit : Form
    {
        DaoFornecedor daoForn = new DaoFornecedor();       

        string id;
        string telId;
        string endId;

        public void GetId(string id)
        {
            this.id = id;
        }

        public FmrFornecedorEdit()
        {
            InitializeComponent();
        }

        private void FmrFornecedorEdit_Load(object sender, EventArgs e)
        {
            SqlDataReader dt = daoForn.SelectFornId(id);
            txtForn.Text = dt["FOR_NOME_FANT"].ToString();
            txtCnpj.Text = dt["FOR_CNPJ"].ToString();
            txtFixo.Text = dt["TEL_FIXO"].ToString();
            txtCel.Text = dt["TEL_CELULAR"].ToString();
            txtDdd.Text = dt["TEL_DDD"].ToString();
            cbxOpe.Text = dt["TEL_OPERADORA"].ToString();
            txtBairro.Text = dt["END_BAIRRO"].ToString();
            txtRua.Text = dt["END_RUA"].ToString();
            txtNum.Text = dt["END_NUMERO"].ToString();
            txtCep.Text = dt["END_CEP"].ToString();
            txtComp.Text = dt["END_COMP"].ToString();
            telId = dt["TEL_ID"].ToString();
            endId = dt["END_ID"].ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Telefone tel = new Telefone(telId, txtDdd.Text, cbxOpe.Text, txtFixo.Text, txtCel.Text);
                Endereco end = new Endereco(endId, txtBairro.Text, txtRua.Text, txtNum.Text, txtCep.Text, txtComp.Text);
                Fornecedor forn = new Fornecedor(id, txtForn.Text, txtCnpj.Text, tel, end);
                daoForn.EditarForn(forn);
            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);               
            }


        }
    }
}
