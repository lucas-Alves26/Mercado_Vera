using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerProduto
{
    public partial class FmrEditar : Form
    {
        DaoProduto daoProd = new DaoProduto();
        DaoFornecedor daoForn = new DaoFornecedor();
        DaoFoto fotos = new DaoFoto();


        string id;
        string catId;
        string fornId;
        public void GetId(string id)
        {
            this.id = id;
        }

        public FmrEditar()


        {
            InitializeComponent();

        }



        private void FmrEditar_Load(object sender, EventArgs e)
        {
            
            PopularCategoria();
            PopularFornecedor();
            PopularMarca();
            SqlDataReader dt;
            byte[] foto = new Byte[0];

            dt = daoProd.SelectProdCompletoId(id);
            txtCodigo.Text = dt["PROD_COD"].ToString();
            txtNome.Text = dt["PROD_NOME"].ToString();
            txtPreco.Text = dt["PROD_VALOR"].ToString();
            txtVenda.Text= dt["PROD_VALOR_VENDA"].ToString();
            txtQtd.Text= dt["PROD_QTD"].ToString();
            txtQtdMin.Text= dt["PROD_QTD_MIN"].ToString();
            cbxCategoria.Text= dt["SUB_CAT_TIPO"].ToString();
            cbxMarca.Text = dt["PROD_MARCA"].ToString();
            cbxFornecedor.Text= dt["FOR_NOME_FANT"].ToString();
            catId = dt["SUB_CAT_ID"].ToString();
            fornId = dt["FOR_ID"].ToString();

            foto = fotos.RetornaImg(id);

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

            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtPreco.Enabled = false;
            txtVenda.Enabled = false;
            txtQtd.Enabled = false;
            txtQtdMin.Enabled = false;
            cbxCategoria.Enabled = false;
            cbxMarca.Enabled = false;
            cbxFornecedor.Enabled = false;
        }

        private void cbxMarca_Click(object sender, EventArgs e)
        {
            PopularMarca();
        }

        private void cbxCategoria_Click(object sender, EventArgs e)
        {     
            PopularCategoria();
        }

        private void cbxFornecedor_Click(object sender, EventArgs e)
        {
            PopularFornecedor();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {           
            try
            {
                catId = cbxCategoria.SelectedValue.ToString();

                if (cbxFornecedor.Text != "")
                {
                    fornId = cbxFornecedor.SelectedValue.ToString();
                }

                daoProd.produto = new Produto(id, txtCodigo.Text, txtNome.Text, txtPreco.Text, txtVenda.Text, txtQtd.Text, txtQtdMin.Text, cbxMarca.Text, catId, fornId, ConverterParaBitArray());
                daoProd.EditarProd(id);
                MessageBox.Show("Produto atualizado com sucesso!");
            }
            catch (DomainExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void HabilitarEdit()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtPreco.Enabled = true;
            txtVenda.Enabled = true;
            txtQtd.Enabled = true;
            txtQtdMin.Enabled = true;
            cbxCategoria.Enabled = true;
            cbxMarca.Enabled = true;
            cbxFornecedor.Enabled = true;
        }

        public void PopularCategoria()
        {
            cbxCategoria.ValueMember = "SUB_CAT_ID";
            cbxCategoria.DisplayMember = "SUB_CAT_TIPO";
            cbxCategoria.DataSource = daoProd.SelectCategoria();
        }
        public void PopularFornecedor()
        {
            cbxFornecedor.ValueMember = "FOR_ID";
            cbxFornecedor.DisplayMember = "FOR_NOME_FANT";
            cbxFornecedor.DataSource = daoForn.SelectForne();
        }
        public void PopularMarca()
        {
            cbxMarca.ValueMember = "PROD_MARCA";
            cbxMarca.DisplayMember = "PROD_MARCA";
            cbxMarca.DataSource = daoProd.SelectMarca();
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCadiado_Click(object sender, EventArgs e)
        {
            HabilitarEdit();
        }

        //Converte a imagem para byte
        private byte[] ConverterParaBitArray()
        {
            MemoryStream stream = new MemoryStream();
            byte[] bArray;

            if (pictureBox1.Image == null)
            {
                stream = null;
                bArray = new byte[0];
            }

            else if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
            }

            bArray = new byte[stream.Length];
            stream.Read(bArray, 0, Convert.ToInt32(stream.Length));
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
