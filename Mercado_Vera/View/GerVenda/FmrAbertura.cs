using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
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

namespace Mercado_Vera.View.GerVenda
{
    public partial class FmrAbertura : Form
    {
        DaoVenda daoVenda = new DaoVenda();

        public static string status = "Fechado";
        string data = DateTime.Now.ToString("yyyy-MM-dd");
        string hora = DateTime.Now.ToString("HH:mm:ss");
        public FmrAbertura()
        {
            InitializeComponent();
        }

        private void FmrAbertura_Load(object sender, EventArgs e)
        {
            lblStatus.Text = status;
            if(lblStatus.Text == "Fechado")
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else if(lblStatus.Text == "Aberto")
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }


            dataGridView1.DataSource = daoVenda.SelectVendaDia(data);

            DateTime date = DateTime.Parse(datePick.Text);
            ResumoPorData(date);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void datePick_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void datePick_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void datePick_ValueChanged(object sender, EventArgs e)
        {
            DateTime data = DateTime.Parse(datePick.Text);
            dataGridView1.DataSource = daoVenda.SelectVendaDia(data.ToString("yyyy-MM-dd"));

            ResumoPorData(data);
     
        }

        private void ResumoPorData(DateTime date)
        {
            DateTime data = date;

            SqlDataReader dt;
            dt = daoVenda.RetornaResumo("dinheiro", data.ToString("yyyy-MM-dd"));
            txtDin.Text = dt["VALOR"].ToString();
            dt = daoVenda.RetornaResumo("Crédito", data.ToString("yyyy-MM-dd"));
            txtCred.Text = dt["VALOR"].ToString();
            dt = daoVenda.RetornaResumo("Débito", data.ToString("yyyy-MM-dd"));
            txtDeb.Text = dt["VALOR"].ToString();
            dt = daoVenda.RetornaResumo("Crediário", data.ToString("yyyy-MM-dd"));
            txtCredia.Text = dt["VALOR"].ToString();
            dt = daoVenda.RetornaTotal(data.ToString("yyyy-MM-dd"));
            txtTotal.Text = dt["TOTAL"].ToString();
        }

        private void btnAbrirC_Click(object sender, EventArgs e)
        {
            lblStatus.Text = status = "Aberto";
            lblStatus.ForeColor = System.Drawing.Color.Green;
            FmrCaixa caixa = new FmrCaixa();
            caixa.GetStatusCaixa(status);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = status = "Fechado";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            FmrCaixa caixa = new FmrCaixa();
            caixa.GetStatusCaixa(status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fechamento fechamento = new Fechamento(txtDeb.Text,txtCred.Text,txtDin.Text,txtCredia.Text,txtTotal.Text,data,hora);
            DaoFechamento daoFechamento = new DaoFechamento();

            daoFechamento.Fechamento(fechamento);
        }
    }
}
