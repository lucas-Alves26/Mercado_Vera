using dllDao;
using Mercado_Vera.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoProduto
    {
        public Produto produto { get; set;}

        public Conexao conexao = new Conexao();

        //metodo para cadastrar o produto
        public void CadastroProd()
        {
            SqlConnection con = new SqlConnection(conexao.StrConexao());
            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();

            cmd1.CommandText = "INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)"
                + " VALUES (@CODBARRA,@NOME,@MARCA,@QTD,@QTDMIN,@PRECO,@PRECOVENDA,@CAT_ID)";

            cmd1.Parameters.Add(new SqlParameter("@CODBARRA",produto.Cod));
            cmd1.Parameters.Add(new SqlParameter("@NOME", produto.Nome));
            cmd1.Parameters.Add(new SqlParameter("@MARCA", produto.Marca));
            cmd1.Parameters.Add(new SqlParameter("@QTD", produto.Qtd));
            cmd1.Parameters.Add(new SqlParameter("@QTDMIN", produto.QtdMin));
            cmd1.Parameters.Add(new SqlParameter("@PRECO", produto.Preco));
            cmd1.Parameters.Add(new SqlParameter("@PRECOVENDA", produto.PrecoVenda));
            cmd1.Parameters.Add(new SqlParameter("@CAT_ID", produto.SubCate));

            con.Open();

            SqlTransaction tran = con.BeginTransaction();

            try
            {
                cmd1.Transaction = tran;
                cmd1.ExecuteNonQuery();
                //cmd2.Transaction = tran;
                //cmd2.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                con.Close();
            }

        }
        //METODO PARA PREENCHER O COMBOX CATEGORIA
        public DataTable SelectCategoria()
        {
            string query = "SELECT SUB_CAT_ID, SUB_CAT_TIPO FROM TBL_SUB_CATEGORIA ";
            return conexao.CarregarDados(query);
        }
    }
}
