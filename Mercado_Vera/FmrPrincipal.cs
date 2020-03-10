using Mercado_Vera.View.GerVenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera
{
    public partial class FmrPrincipal : Form
    {
        public FmrPrincipal()
        {
            InitializeComponent();
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
   

        }

        private void caixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FmrCaixa caixa = new FmrCaixa();
            caixa.ShowDialog();
            this.Visible = true;
        }

        private void aberturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrAbertura abertura = new FmrAbertura();
            abertura.ShowDialog();
        }
    }
}
