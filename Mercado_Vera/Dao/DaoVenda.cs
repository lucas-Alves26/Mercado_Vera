using dllDao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoVenda
    {
        Conect conexao = new Conect();

        public void RegistraVenda(Venda venda)
        {
            string data = venda.Date.ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(conexao.StrConexao());
            SqlCommand cmd1 = con.CreateCommand();

            cmd1.CommandText = "INSERT INTO TBL_VENDA(CLI_ID, VEN_PAGAMENTO, VEN_PARCELA, VEN_BANDEIRA, VEN_QTD, VEN_TOTAL, VEN_DATE) VALUES(@CLIID, @PAGAMENTO, @PARCELA, @BANDEIRA, @QTD, @TOTAL, @DATE)";

            cmd1.Parameters.Add(new SqlParameter("@CLIID", venda.CliId));
            cmd1.Parameters.Add(new SqlParameter("@PAGAMENTO", venda.TipoPagamento));

            if(venda.Parcelas!=0)
                cmd1.Parameters.Add(new SqlParameter("@PARCELA", venda.Parcelas));
            else
                cmd1.Parameters.Add(new SqlParameter("@PARCELA", DBNull.Value));

            if(venda.Bandeira!=null)
                cmd1.Parameters.Add(new SqlParameter("@BANDEIRA", venda.Bandeira));
            else
                cmd1.Parameters.Add(new SqlParameter("@BANDEIRA", DBNull.Value));

            cmd1.Parameters.Add(new SqlParameter("@QTD", venda.Qtd));
            cmd1.Parameters.Add(new SqlParameter("@TOTAL", venda.ValorTotal));
            cmd1.Parameters.Add(new SqlParameter("@DATE", data));

            con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    cmd1.Transaction = tran;
                    cmd1.ExecuteNonQuery();                 
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
        public void RegistrarItemVenda(int idProd, decimal valor, int qtd)
        {
            string query = "SELECT MAX(VEN_ID) FROM TBL_VENDA";
            string idVenda = conexao.SelecioneId(query);
            query = "INSERT INTO TBL_ITEM_VENDA(PROD_ID, VEN_ID, ITEM_VALOR, ITEM_QTD) VALUES("+idProd+","+idVenda+","+valor.ToString().Replace(',', '.') + ","+qtd+")";
            conexao.ExecutaInstrucaoNaBase(query);
        }
        public void ConsultaQuantidade(string cod, string qtd, string id)
        {
            if(id == null)
            {
                id = "null";
            }

            string query = "SELECT PROD_QTD FROM TBL_PRODUTO WHERE PROD_COD = '"+ cod+"' OR PROD_ID = " + id;
            SqlDataReader dr = conexao.CarregarVariosDados(query);

                if(int.Parse(dr["PROD_QTD"].ToString()) < int.Parse(qtd) || int.Parse(dr["PROD_QTD"].ToString()) <= 0)
                {
                    //CORTA O MÉTODO E ENVIA ESSA MENSAGEM AO USUÁRIO
                    throw new DomainExceptions("Estoque do produto "+ dr["PROD_QTD"].ToString() + " , não é possivel adicionar essa quantidade!");
                }          
        }
        public SqlDataReader RetornaProd(string cod, string id)
        {
            if (id == null)
            {
                id = "null";
            }

            string query = "SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME, P.PROD_VALOR_VENDA FROM  TBL_PRODUTO AS P WHERE P.PROD_COD = '" + cod +"' OR P.PROD_ID =" + id;
            return conexao.CarregarVariosDados(query);
        }
        public void UpdateEstoque(int id, int qtd)
        {
            string query = "UPDATE TBL_PRODUTO SET PROD_QTD = PROD_QTD -" + qtd+" WHERE PROD_ID = " + id;
            conexao.ExecutaInstrucaoNaBase(query);
        }
        public void UpdateCrediario(string id,  string valor)
        {
            string query = "UPDATE TBL_CLIENTE SET CLI_DIVIDA -= "+ valor.Replace(",", ".") + " WHERE CLI_ID = " + id;
            conexao.ExecutaInstrucaoNaBase(query);
        }
        public DataTable SelectVendaDia(string data)
        {            
            string query = "SELECT V.VEN_DATE, V.VEN_PAGAMENTO, V.VEN_PARCELA, V.VEN_TOTAL, V.VEN_ID, C.CLI_NOME FROM TBL_VENDA AS V "
                + "INNER JOIN TBL_CLIENTE AS C ON C.CLI_ID = V.CLI_ID WHERE VEN_DATE = '"+data+"'";
            return conexao.CarregarDados(query);
        }
        public SqlDataReader RetornaResumo(string pagamento, string date)
        {
            string query = "select sum(VEN_TOTAL) as VALOR from TBL_VENDA where VEN_PAGAMENTO = '"+pagamento+"' AND VEN_DATE = '"+date+"'";
            return conexao.CarregarVariosDados(query);
        }
        public SqlDataReader RetornaTotal(string date)
        {
            string query = "select sum(VEN_TOTAL) as TOTAL from TBL_VENDA where VEN_DATE = '" + date + "'";
            return conexao.CarregarVariosDados(query);
        }


      
    }
}
