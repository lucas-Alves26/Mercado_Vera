using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using Mercado_Vera.View.GerCliente;
using Mercado_Vera.View.GerVenda;
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

        static string statusCaixa = "Fechado";
        public void GetStatusCaixa(string status)
        {
            statusCaixa = status;
        }

        string statusVenda ="Fechada";
        string parcelas;
        string bandeira;
        string pagamento;
        string dataHora = DateTime.Now.ToString();
        public static string qtd = "1";
        static decimal totalprod;
        byte[] foto = new Byte[0];
        public static string cliId { get; set; }
        public static string nomeCli { get; set; }
        public static string idProd { get; set; }
        public static string nomeProd { get; set; }


        public FmrCaixa()
        {
            InitializeComponent();
            panelFinalizar.Visible = false;
            panelCredito.Visible = false;
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
                daoVenda.ConsultaQuantidade(txtBarra.Text, qtd, idProd);
                SqlDataReader dr = daoVenda.RetornaProd(txtBarra.Text, idProd);
                txtBarra.Text = dr["PROD_COD"].ToString();
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
                qtd = "1";
            }


            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtBarra.Clear();
                 lblSubTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[total.Name].Value ?? 0)).ToString("##0.00");
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
            lblRsDinheiro.Visible = false;
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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnQld_Click(object sender, EventArgs e)
        {
            txtQtd.BackColor = System.Drawing.Color.LightSteelBlue;
            txtBarra.BackColor = System.Drawing.Color.SteelBlue;
            txtBarra.Enabled = false;
            txtQtd.Enabled = true;
            txtQtd.Focus();
        }

        private void txtBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Back))
                e.Handled = true;

            if (e.KeyChar == 13 && txtBarra.Text !="")
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
            if(statusCaixa == "Fechado")
            {
                MessageBox.Show("Faça a abertura do caixa!", "Abertura de caixa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (statusCaixa == "Aberto")
            {
                txtBarra.Enabled = true;
                btnQld.Enabled = true;
                btnDel.Enabled = true;
                btnFin.Enabled = true;
                txtBarra.BackColor = System.Drawing.Color.LightSteelBlue;
                txtBarra.Focus();
                BtnVenda.Enabled = false;
                statusVenda = "Aberta";
            }
        }

        //Botão de finalizar venda da primeira tela, leva para tela de pagamento
        private void btnFin_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 1)
            {
                MessageBox.Show("Lista de produtos está vazia !", "Lista de produtos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtBarra.BackColor = System.Drawing.Color.SteelBlue;
                txtBarra.Enabled = false;
                lblTotal2.Text = lblSubTotal.Text;
                panelFinalizar.Visible = true;
                BtnVenda.Enabled = false;

                TravarBotoes();
            }         
        }
        //Botão para deletar produto da lista
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Excluir produto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    lblSubTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[total.Name].Value ?? 0)).ToString("##00.00");
                }
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
        //botão para abrir a busca de clientes para pagamento em crediário
        private void button6_Click(object sender, EventArgs e)
        {
            LimparDados();

            BuscaCliente buscaCli = new BuscaCliente();
            buscaCli.ShowDialog();

            lblId.Text = buscaCli.id;
            lblNomeCli.Text = buscaCli.nome;
            lblPagamento.Text = "CREDIÁRIO";
            pagamento = "Crediário";

        }
        public void LimparDados()
        {
            lblId.Text = "1";
            cliId = null;
            lblNomeCli.Text = "CLIENTE - 1";
            lblCredito.Text = "0,00";
            lblDebito.Text = "0,00";
            lblTroco.Text = "0,00";
            lblValorDebito.Text = "0,00";
            lblValorCred.Text = "0,00";
            lblValorParcela.Text = "0,00";
            lblTotalRec.Text = "0,00";
            txtDinheiro.Text = "";
            txtParcela.Text = "";
            parcelas = null;
            bandeira = null;
            pagamento = "";
            cbxBandCred.Text = null;
            cbxBandeira.Text = null;
            panelCredito.Height = 10;
            panelDebito.Height = 10;
            lblRsDinheiro.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        //botão para finalizar a venda
        private void btnFinal_Click(object sender, EventArgs e)
        {
            if(pagamento == "Crédito" && bandeira == null || parcelas =="0" || parcelas == "")
            {
                MessageBox.Show("Preencha os campos de crédito corretamente!", "Opção crédito invalida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(pagamento == "Debito" && cbxBandeira.Text == null)
            {
                MessageBox.Show("Preencha os campos de débito corretamente!", "Opção débito invalida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (pagamento != null && pagamento != "")

            {

                if (cliId == null)
                {
                    cliId = "1";
                }

                string qtdTotal = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[quantidade.Name].Value ?? 0)).ToString("##");
                Venda venda = new Venda(cliId, qtdTotal, lblSubTotal.Text, dataHora, pagamento, bandeira, parcelas);
                daoVenda.RegistraVenda(venda);
                try
                {
                    foreach (ItemVenda V in listaItens)
                    {
                        daoVenda.RegistrarItemVenda(V.ProdId, V.ValorTotal, V.Qtd);
                        daoVenda.UpdateEstoque(V.ProdId, V.Qtd);
                    }

                    //Acrecenta valor negativo aos clientes de crediário
                    daoVenda.UpdateCrediario(lblId.Text, lblSubTotal.Text);

                    MessageBox.Show("Venda Finalizada !");
                }
                catch (DomainExceptions ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    qtd = "1";
                    txtQtd.Text = "";
                    txtIdB.Text = "1";
                    lblPod.Text = "";
                    lblTotaltem.Text = "0,00";
                    lblSubTotal.Text = "0,00";
                    panelFinalizar.Visible = false;
                    lblRsDinheiro.Visible = false;
                    BtnVenda.Enabled = true;
                    pictureBox1.Image = null;
                    lblTotaltem.Text = "0,00";
                    lblValorUni.Text = "0,00";
                    panelDebito.Height = 10;
                    lblPagamento.Text = "CAIXA";
                    txtDinheiro.Text = "";


                    dataGridView2.Rows.Clear();//limpa o datagrid e mantem o header
                    statusVenda = "Fechada";
                }
            }
            else
            {
                MessageBox.Show("Selecione a forma de pagamento!", "Forma de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimparDados();
            lblPagamento.Text = "CAIXA";
            pagamento = "Dinheiro";
            txtDinheiro.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtDinheiro.Focus();
            lblRsDinheiro.Visible = true;
        }

        //botão crédito
        private void button7_Click(object sender, EventArgs e)
        {
            LimparDados();

            txtParcela.BackColor = System.Drawing.Color.LightSteelBlue;
            panelCredito.Visible = true;
            panelCredito.Height = 400;
            txtDinheiro.BackColor = System.Drawing.Color.Green;
            bandeira = cbxBandCred.Text;
            pagamento = "Crédito";
            lblPagamento.Text = "CRÉDITO"; 
            lblValorCred.Text = lblSubTotal.Text;
            lblCredito.Text = lblSubTotal.Text;
            txtParcela.Focus();
        }
        //botão débito
        private void button8_Click(object sender, EventArgs e)
        {
            LimparDados();

            panelDebito.Height = 400;     
            lblDebito.Text = lblSubTotal.Text;
            lblValorDebito.Text = lblSubTotal.Text;
            bandeira = cbxBandeira.Text;
            pagamento = "Débito";
            lblPagamento.Text = "DÉBITO";
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
                decimal subt = decimal.Parse(txtDinheiro.Text) - decimal.Parse(lblSubTotal.Text);
                txtDinheiro.Text = txtDinheiro.Text;
                lblTotalRec.Text = txtDinheiro.Text;
                lblTroco.Text = subt.ToString();              
            }
        }
        //botão ok débito
        private void button2_Click(object sender, EventArgs e)
        {
            bandeira = cbxBandeira.Text;

            if (bandeira != "")
            {
                panelDebito.Height = 10;
            }
            else
            {
                MessageBox.Show("Selecione a bandeira do cartão de Débito!");
            }          
        }
        //botão EscDebito
        private void button1_Click_1(object sender, EventArgs e)
        {
            panelDebito.Height = 10;
            lblValorDebito.Text = "0,00";
            panelCredito.Height = 10;
            cbxBandeira.Text = null; 
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void txtParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Back))
                e.Handled = true;

            if (e.KeyChar == 13 && txtParcela.Text!= "")
            {
                parcelas = txtParcela.Text;                  
                decimal valor = decimal.Parse(lblSubTotal.Text) / decimal.Parse(parcelas);
                lblValorParcela.Text = valor.ToString();
            }
           
        }
        //botão ok crédito
        private void btnOkCredito_Click(object sender, EventArgs e)
        {

            bandeira = cbxBandCred.Text;

            if (txtParcela.Text == "" || txtParcela.Text == "0")
            {
                MessageBox.Show("Coloque um valor maior que zero na parcela !");
            }

            else if (bandeira == "")
            {
                MessageBox.Show("Selecione a bandeira do cartão de crédito !");
            }
      
            else
            {
                panelCredito.Height = 10;
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Cancelar venda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (confirm.ToString().ToUpper() == "YES")
            {
                LimparDados();

                qtd = "1";
                txtQtd.Text = "";
                txtIdB.Text = "1";
                lblPod.Text = "";
                lblTotaltem.Text = "0,00";
                lblSubTotal.Text = "0,00";
                panelFinalizar.Visible = false;
                BtnVenda.Enabled = true;
                pictureBox1.Image = null;
                lblTotaltem.Text = "0,00";
                lblValorUni.Text = "0,00";
                panelFinalizar.Visible = false;
                lblPagamento.Text = "CAIXA";
                dataGridView2.Rows.Clear();//limpa o datagrid e mantem o header
                statusVenda = "Fechada";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 1)
            {
                MessageBox.Show("A venda está em aberto! Para poder sair cancele a venda na tela de pagamento.", "Venda em aberto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Sair venda.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    Close();
                    statusVenda = "Fechada";
                }
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FmrPesqProd pesqPrd = new FmrPesqProd();
            pesqPrd.ShowDialog();

            if (statusVenda == "Aberta")
            {
                idProd = pesqPrd.id;
                if (idProd != null)
                {
                    PrencheProduto();
                    txtQtd.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtParcela.Text = "";
            lblValorCred.Text = "0,00";
            lblValorParcela.Text = "0,00";
            panelCredito.Height = 10;
        }
    }
}
