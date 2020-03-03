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

namespace Mercado_Vera.View.Login
{
    public partial class FmrLogin : Form
    {
        public FmrLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void FmrLogin_Load(object sender, EventArgs e)
        {
            btnLogin.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginEnty log = new LoginEnty();
            log.acessar(txtLogin.Text, txtPass.Text);
            if (log.Mensagen.Equals(""))
            {
                if (log.tem)
                { 
                    FmrPrincipal principal = new FmrPrincipal();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Login não encontrado, verrifique login e senha!!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(log.Mensagen);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
