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
    public partial class BuscaCliente : Form
    {

        DaoCliente daoCliente = new DaoCliente();

        public String id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string nome
        {
            get { return txtNomePes.Text; }
            set { txtNomePes.Text = value; }
        }


        public BuscaCliente()
        {
            InitializeComponent();

        }        

            private void BuscaCliente_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = daoCliente.SelectCliente();
        }

        private void txtCodigoPes_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = daoCliente.SelectCliiD(txtId.Text);
        }

        private void txtCodigoPes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //esse if é para aceitar, setas e apagar
            if (e.KeyChar == 8)
                return;
            //se for diferente de numeros aparece a menssagem
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero!");
            }
            dataGridView1.DataSource = daoCliente.SelectCliiD(txtId.Text);
        }

        private void txtCodigoPes_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = daoCliente.SelectCliiD(txtId.Text);
        }

        private void txtNomePes_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = daoCliente.SelectCliNome(txtNomePes.Text);
        }

        private void txtNomePes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //esse if é para aceitar, setas e apagar
            if (e.KeyChar == 8)
                return;

            //esse if não aceitar, os seguintes caracteres especiais
            string caracteresPermitidos = "!@#$¨&*()_-+ºª[]{}?/|\"'¬§<>.,:;°";

            if ((caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper())))
            {
                e.Handled = true;
                MessageBox.Show("Este campo não aceita caracteres especiais!");
            }

            //se for diferente de letras e espaço aparece a menssagem
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita letras e espaços!");
            }
            dataGridView1.DataSource = daoCliente.SelectCliNome(txtNomePes.Text);
        }

        private void txtNomePes_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = daoCliente.SelectCliNome(txtNomePes.Text);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //ao clicar duas vezes passa nome e id para os txtbox
            this.txtNomePes.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CLI_NOME"].Value);
            txtId.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CLI_ID"].Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            FmrCaixa.cliId = txtId.Text;
            FmrCaixa.nomeCli = txtNomePes.Text;

            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FmrCliente cliente = new FmrCliente();
            cliente.ShowDialog();
        }
    }
}
