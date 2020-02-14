using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
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
    public partial class FmrCliente : Form
    {
        DaoCliente cliente = new DaoCliente();
        
        public FmrCliente()
        {
            InitializeComponent();
        }

        private void txtFixo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                Telefone tel = new Telefone(txtDdd.Text, cbxOpe.Text, txtFixo.Text, txtCel.Text);
                Endereco end = new Endereco(txtBairro.Text, txtRua.Text, txtNum.Text, txtCep.Text, txtComp.Text);
                Cliente cli = new Cliente(txtNome.Text, tel, end);

                cliente.CadastroCliente(cli);
                MessageBox.Show("Cliente cadastrado com sucesso!!");

            }
            catch (DomainExceptions ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
