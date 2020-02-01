using Mercado_Vera.Dao;
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

namespace Mercado_Vera.View.GerProduto
{
    public partial class FmrPesquisa : Form
    {
        DaoProduto daoProd = new DaoProduto();

        string busca="";
        string id;

        public FmrPesquisa()
        {
            InitializeComponent();
        }

        private void FmrPesquisa_Load(object sender, EventArgs e)
        {            
            DgPesquisa.DataSource = daoProd.SelectProdCompleto(busca);
        }

        private void cbxMarcaPes_Click(object sender, EventArgs e)
        {
            //preenche o cbxMarca com as marcas que estão no banco
            cbxMarcaPes.ValueMember = "PROD_MARCA";
            cbxMarcaPes.DisplayMember = "PROD_MARCA";
            cbxMarcaPes.DataSource = daoProd.SelectMarca();// carrega a coluna EST_STR_MARCA dentro cbx
            busca = cbxMarcaPes.SelectedValue.ToString();
        }

        private void cbxMarcaPes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //traz todos os produtos que estão relacionado com essa marca
            busca = cbxMarcaPes.SelectedValue.ToString();
            DgPesquisa.DataSource = daoProd.SelectProdCompleto(busca);
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
            else
            {
                busca = txtCodigoPes.Text;
                DgPesquisa.DataSource = daoProd.SelectProdCodCompl(busca);
            }
        }

        private void txtCodigoPes_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtCodigoPes.Text;
            DgPesquisa.DataSource = daoProd.SelectProdCodCompl(busca);
        }

        private void txtCodigoPes_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtCodigoPes.Text;
            DgPesquisa.DataSource = daoProd.SelectProdCodCompl(busca);
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
            else
            {
                busca = txtNomePes.Text;
                DgPesquisa.DataSource = daoProd.SelectProdNomeCompl(busca);
            }
        }

        private void txtNomePes_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtNomePes.Text;
            DgPesquisa.DataSource = daoProd.SelectProdNomeCompl(busca);
        }

        private void txtNomePes_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtNomePes.Text;
            DgPesquisa.DataSource = daoProd.SelectProdNomeCompl(busca);
        }

        private void FmrPesquisa_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void DgPesquisa_DoubleClick(object sender, EventArgs e)
        {
            //ao clicar duas vezes passa codigo, nome e id para os txtbox
            this.txtCodigoPes.Text = Convert.ToString(this.DgPesquisa.CurrentRow.Cells["PROD_COD"].Value);
            this.txtNomePes.Text = Convert.ToString(this.DgPesquisa.CurrentRow.Cells["PROD_NOME"].Value);
            id = Convert.ToString(this.DgPesquisa.CurrentRow.Cells["PROD_ID"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                FmrEditar editar = new FmrEditar();
                editar.GetId(id);
                editar.Show();
            }
        }
    }
}
