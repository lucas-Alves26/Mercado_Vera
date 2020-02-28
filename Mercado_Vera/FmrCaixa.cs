using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using Mercado_Vera.View.GerCliente;
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

        string parcelas;
        string bandeira;
        string pagamento;
        string dataHora = DateTime.Now.ToString();
        string qtd = "1";
        static decimal totalprod;
        byte[] foto = new Byte[0];
        public static string cliId { get; set; }
        public static string nomeCli { get; set; } 
  

        public FmrCaixa()
        {
            InitializeComponent();
            panelFinalizar.Visible = false;

        }

        public void Atualiza()
        {
            if(cliId != null && nomeCli != null)
            {
                lblId.Text = cliId;
                lblNomeCli.Text = nomeCli;
            }
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
            Atualiza();
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
            lblTotal2.Text = lblSubTotal.Text;
            panelFinalizar.Visible = true;
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            BuscaCliente buscaCli = new BuscaCliente();
            buscaCli.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            bandeira = cbxBandeira.Text;
            if(cliId == null)
            {
                cliId = "1";
            }

            string qtdTotal =dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[quantidade.Name].Value ?? 0)).ToString("##");
            Venda venda = new Venda(cliId, qtdTotal, lblSubTotal.Text, dataHora, pagamento,bandeira, parcelas);
            daoVenda.RegistraVenda(venda);
            try
            {
                foreach (ItemVenda V in listaItens)
                {
                    daoVenda.RegistrarItemVenda(V.ProdId, V.ValorTotal, V.Qtd);
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
                panelFinalizar.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDinheiro.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtDinheiro.Focus();
            pagamento = "Dinheiro";
            lblPagamento.Text = "CAIXA";
            btnBuscaCli.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pagamento = "Crédito";
            btnBuscaCli.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblDebito.Text = lblSubTotal.Text;
            lblValorDebito.Text = lblSubTotal.Text;
            pagamento = "Débito";
            lblPagamento.Text = "DÉBITO";
            panelDebito.Height = 400;
            txtDinheiro.Text = "0,00";
            lblCredito.Text = "0,00";
            btnBuscaCli.Enabled = false;
        }

        private void txtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //este campo aceita somente uma virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }

            if (e.KeyChar == 13)
            {             
                txtDinheiro.BackColor = System.Drawing.Color.Green;
                btnFin.Focus();
                lblTotalRec.Text = txtDinheiro.Text;
                decimal soma = decimal.Parse(txtDinheiro.Text) - decimal.Parse(lblSubTotal.Text);
                //txtDinheiro.Text = "R$ " + txtDinheiro.Text;
                lblTroco.Text = soma.ToString();              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDebito.Height = 10;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelDebito.Height = 10;
            pagamento = "Dinehiro";
        }
    }
}
