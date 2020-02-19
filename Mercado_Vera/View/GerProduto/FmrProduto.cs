using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera
{
    public partial class FmrProduto : Form
    {
        //instancioando classe DaoProduto para ter acesso aos metodos
        DaoProduto DaoProd = new DaoProduto();
        DaoFornecedor DaoForn = new DaoFornecedor();
        

        public FmrProduto()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PnlProd.Height == 0)
            {
                PnlProd.Height = 419;
            }


        }  
        

        private void FmrProduto_Load(object sender, EventArgs e)
        {
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string fornId = "";

            try
            {
                string categId = cbxCategoria.SelectedValue.ToString();

                if (cbxFornecedor.Text != "")
                {
                    fornId = cbxFornecedor.SelectedValue.ToString();
                }

                DaoProd.produto = new Produto(txtCodigo.Text, txtNome.Text, txtPreco.Text, txtVenda.Text, txtQtd.Text, txtQtdMin.Text, cbxMarca.Text, categId,fornId, ConverterParaBitArray());
                DaoProd.CadastroProd();
                MessageBox.Show("Produto cadastrado com sucesso!");
                Limpar();
            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);                
            }       
        }

        public void Limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtPreco.Text = "";
            txtVenda.Text = "";
            txtQtd.Text = "";
            txtQtdMin.Text = "";
            cbxMarca.Text = "";
            cbxCategoria.Text = "";
            cbxFornecedor.Text = "";           
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbxCategoria_Click(object sender, EventArgs e)
        {
            cbxCategoria.ValueMember = "SUB_CAT_ID";
            cbxCategoria.DisplayMember = "SUB_CAT_TIPO";
            cbxCategoria.DataSource = DaoProd.SelectCategoria();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void cbxMarca_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtQtdMin_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtVenda_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cbxMarca_Click(object sender, EventArgs e)
        {
            cbxMarca.ValueMember = "PROD_MARCA";
            cbxMarca.DisplayMember = "PROD_MARCA";
            cbxMarca.DataSource = DaoProd.SelectMarca();// carrega a coluna EST_STR_NOME dentro cbx
        }

        private void cbxFornecedor_Click(object sender, EventArgs e)
        {
            cbxFornecedor.ValueMember = "FOR_ID";
            cbxFornecedor.DisplayMember = "FOR_NOME_FANT";
            cbxFornecedor.DataSource = DaoForn.SelectForne();
        }

        private void cbxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Converte a imagem para byte
        private byte[] ConverterParaBitArray()
        {
            MemoryStream stream = new MemoryStream();
            byte[] bArray = null;

             if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);

                bArray = new byte[stream.Length];
                stream.Read(bArray, 0, Convert.ToInt32(stream.Length));
            }
        
            return bArray;
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrir.Filter = "Image Files (*.bmp, *.jpg, *.png, *.jpeg)| *.bmp; *.jpg; *.png; *.jpeg";
            abrir.Multiselect = false;

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(abrir.FileName);
            }
        }
    }
}
