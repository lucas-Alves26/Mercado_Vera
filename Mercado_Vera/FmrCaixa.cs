using Mercado_Vera.Dao;
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

namespace Mercado_Vera
{
    public partial class FmrCaixa : Form
    {
        DaoVenda daoVenda = new DaoVenda();
        string qtd = "1";
        static decimal totalprod;

        public FmrCaixa()
        {
            InitializeComponent();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FmrCaixa_Load(object sender, EventArgs e)
        {

        }

        private void button4_Leave(object sender, EventArgs e)
        {
            try
            {
                daoVenda.ConsultaQuantidade(txtBarra.Text, qtd);
                SqlDataReader dr = daoVenda.RetornaProd(txtBarra.Text);
                lblValorUni.Text = dr["PROD_VALOR_VENDA"].ToString();
                lblPod.Text = dr["PROD_NOME"].ToString();
                totalprod = (int.Parse(txtQtd.Text) * int.Parse(lblValorUni.Text));
                lblTotaltem.Text = totalprod.ToString();
            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQld_Click(object sender, EventArgs e)
        {
            txtQtd.Focus();
        }

        private void txtBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    daoVenda.ConsultaQuantidade(txtBarra.Text, qtd);
                    SqlDataReader dr = daoVenda.RetornaProd(txtBarra.Text);
                    lblValorUni.Text = dr["PROD_VALOR_VENDA"].ToString();
                    lblPod.Text = dr["PROD_NOME"].ToString();
                    totalprod = (int.Parse(qtd) * decimal.Parse(lblValorUni.Text));
                    lblTotaltem.Text = totalprod.ToString();
                }
                catch (DomainExceptions ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

                
        }

        private void txtBarra_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    daoVenda.ConsultaQuantidade(txtBarra.Text, qtd);
            //}
            //catch (DomainExceptions ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    daoVenda.ConsultaQuantidade(txtBarra.Text, txtQtd.Text);
                    SqlDataReader dr = daoVenda.RetornaProd(txtBarra.Text);
                    lblValorUni.Text = dr["PROD_VALOR_VENDA"].ToString();
                    totalprod = (int.Parse(txtQtd.Text) * decimal.Parse(lblValorUni.Text));
                    lblTotaltem.Text = totalprod.ToString();
                }
                catch (DomainExceptions ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
