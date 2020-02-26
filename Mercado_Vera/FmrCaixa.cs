﻿using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera
{
    public partial class FmrCaixa : Form
    {
        DaoVenda daoVenda = new DaoVenda();
        DaoFoto daoFoto = new DaoFoto();
        ObservableCollection<ItemVenda> listaItens = new ObservableCollection<ItemVenda>();


        string qtd = "1";
        static decimal totalprod;
        byte[] foto = new Byte[0];
   

        public FmrCaixa()
        {
            InitializeComponent();
        }
        //Metodo que prenche o txtbox com o produto do BD
        public void PrencheProduto()
        {
            if (txtQtd.Text != "")
            {
                qtd = txtQtd.Text;
            }
            
                txtIdB.Enabled = false;
                txtQtd.Enabled = false;
            try
            {
                daoVenda.ConsultaQuantidade(txtBarra.Text, qtd);
                SqlDataReader dr = daoVenda.RetornaProd(txtBarra.Text);
                lblValorUni.Text = dr["PROD_VALOR_VENDA"].ToString();
                lblPod.Text = dr["PROD_NOME"].ToString();
                txtIdB.Text = dr["PROD_ID"].ToString();
                totalprod = (int.Parse(qtd) * decimal.Parse(lblValorUni.Text));
                lblTotaltem.Text = totalprod.ToString();

                foto = daoFoto.RetornaImg(txtIdB.Text);

                if (foto == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream(foto);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromStream(stream);
                }
                GetProdDg();
                PrencheDg();
            }

            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtBarra.Clear();
                 lblSubTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[total.Name].Value ?? 0)).ToString("##.00");
            }
        }

        //preenche datagridview com as informações do produto
        public void PrencheDg()
        {
            dataGridView2.Rows.Add(txtIdB.Text, txtBarra.Text, lblPod.Text, lblValorUni.Text, qtd, lblTotaltem.Text);
        }
        //pega o ID e a qantidade do produto para armazenar em uma lista
        public void GetProdDg()
        {
            ItemVenda itemVenda = new ItemVenda(txtIdB.Text, lblTotaltem.Text, qtd);
            listaItens.Add(itemVenda);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FmrCaixa_Load(object sender, EventArgs e)
        {
            TravarBotoes();
        }

        private void TravarBotoes()
        {
            txtBarra.Enabled = false;
            txtIdB.Enabled = false;
            txtQtd.Enabled = false;
            btnQld.Enabled = false;
            btnDel.Enabled = false;
            btnFin.Enabled = false;
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            PrencheProduto();           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQld_Click(object sender, EventArgs e)
        {
            txtQtd.BackColor = System.Drawing.Color.LightSteelBlue;
            txtQtd.Focus();
            txtBarra.BackColor = System.Drawing.Color.SteelBlue;
            txtBarra.Enabled = false;
            txtQtd.Enabled = true;
        }

        private void txtBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PrencheProduto();
            }
        }

        private void txtBarra_Leave(object sender, EventArgs e)
        {

        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtd.Enabled = false;
                txtQtd.BackColor = System.Drawing.Color.SteelBlue;
                txtBarra.BackColor = System.Drawing.Color.LightSteelBlue;
                txtBarra.Enabled = true;
                txtBarra.Focus();
            }
        }

        private void BtnVenda_Click(object sender, EventArgs e)
        {
            txtBarra.Enabled = true;
            btnQld.Enabled = true;
            btnDel.Enabled = true;
            btnFin.Enabled = true;
            txtBarra.BackColor = System.Drawing.Color.LightSteelBlue;
            txtBarra.Focus();
            BtnVenda.Enabled = false;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ItemVenda V in listaItens)
                {
                    daoVenda.UpdateEstoque(V.ProdId, V.Qtd);
                }

                MessageBox.Show("Venda Finalizada");
            }
            catch (DomainExceptions ex)
            {               
                MessageBox.Show(ex.Message);
            }

            finally
            {
                txtQtd.Clear();
                txtIdB.Clear();
                lblPod.Text = "R$ 0,00";
                lblTotaltem.Text = "R$ 0,00";
                lblSubTotal.Text = "R$ 0,00";
            }

            BtnVenda.Enabled = true;
         
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                lblSubTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[total.Name].Value ?? 0)).ToString("##00.00");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
