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

namespace Mercado_Vera.View.GerProduto
{
    public partial class tstExcluir : Form
    {
        string id;
        string busca = "";

        DaoProduto daoProd = new DaoProduto();
        public tstExcluir()
        {
           
            InitializeComponent();

            DgExcluir.DataSource = daoProd.SelectProdDel(busca);
        }

        private void tstExcluir_Load(object sender, EventArgs e)
        {     
        }

        private void DgExcluir_DoubleClick(object sender, EventArgs e)
        {         
            //ao clicar duas vezes passa codigo, nome e id para os txtbox
                this.txtCodigoEx.Text = Convert.ToString(this.DgExcluir.CurrentRow.Cells["PROD_COD"].Value);
                this.txtNomeEx.Text = Convert.ToString(this.DgExcluir.CurrentRow.Cells["PROD_NOME"].Value);
                id = Convert.ToString(this.DgExcluir.CurrentRow.Cells["PROD_ID"].Value); 
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                daoProd.produto = new Produto(id);
                DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Excluir Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    daoProd.DeleteProd();
                    DgExcluir.DataSource = daoProd.SelectProdDel(busca);
                    MessageBox.Show("Produto Excluido com sucesso!");
                }
            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //preenche o cbxMarca com as marcas que estão no banco
            cbxMarca.ValueMember = "PROD_MARCA";
            cbxMarca.DisplayMember = "PROD_MARCA";
            cbxMarca.DataSource = daoProd.SelectMarca();// carrega a coluna EST_STR_MARCA dentro cbx
            busca = cbxMarca.SelectedValue.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //traz todos os produtos que estão relacionado com essa marca
            busca = cbxMarca.SelectedValue.ToString();
            DgExcluir.DataSource = daoProd.SelectProdDel(busca);
        }

        private void DgExcluir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNomeEx_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void cbxMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxMarca.Text == null)
                busca = "";
            DgExcluir.DataSource = daoProd.SelectProdDel(busca);
        }

        private void cbxMarca_KeyDown(object sender, KeyEventArgs e)
        {
   
        }

        private void txtNomeEx_KeyPress(object sender, KeyPressEventArgs e)
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
                busca = txtNomeEx.Text;
                DgExcluir.DataSource = daoProd.SelectProdNome(busca);
            }           
        }

        private void txtNomeEx_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtNomeEx.Text;
            DgExcluir.DataSource = daoProd.SelectProdNome(busca);
        }

        private void txtNomeEx_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtNomeEx.Text;
            DgExcluir.DataSource = daoProd.SelectProdNome(busca);
        }

        private void txtCodigoEx_KeyPress(object sender, KeyPressEventArgs e)
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
                busca = txtCodigoEx.Text;
                DgExcluir.DataSource = daoProd.SelectProdCod(busca);
            }
        }

        private void txtCodigoEx_KeyUp(object sender, KeyEventArgs e)
        {
            busca = txtCodigoEx.Text;
            DgExcluir.DataSource = daoProd.SelectProdCod(busca);
        }

        private void txtCodigoEx_KeyDown(object sender, KeyEventArgs e)
        {
            busca = txtCodigoEx.Text;
            DgExcluir.DataSource = daoProd.SelectProdCod(busca);
        }
    }
}
