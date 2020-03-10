using Mercado_Vera.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerCliente
{
    public partial class PesqCliente : Form
    {
        DaoCliente daoCliente = new DaoCliente();
        string busca = "";

        public PesqCliente()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PesqCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = daoCliente.PesqCliente("", "");


            //DateTime data1 = DateTime.Parse(textBox1.Text);
            //DateTime fim = DateTime.Now;

            //TimeSpan ts = fim.Subtract(inicio);
            //DateTime periodo = new DateTime(ts.Ticks);


        }

        private void txtNomePes_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtNomePes.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente("", busca);
        }

        private void txtNomePes_KeyPress(object sender, KeyPressEventArgs e)
        {
            busca = txtNomePes.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente("", busca);
        }

        private void txtNomePes_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtNomePes.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente("", busca);
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtId.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente(busca,"");
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            busca = txtId.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente(busca, "");
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtId.Text;
            dataGridView1.DataSource = daoCliente.PesqCliente(busca, "");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FmrCliente fmrCliente = new FmrCliente();
            fmrCliente.ShowDialog();
        }
    }
}
