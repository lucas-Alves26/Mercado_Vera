using dllDao;
using Mercado_Vera.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoFechamento
    {
        Conexao conexao = new Conexao();

        public void Fechamento(Fechamento fechamento)
        {
            SqlConnection con = new SqlConnection(conexao.StrConexao());
            SqlCommand cmd1 = con.CreateCommand();

            string date = fechamento.Date.ToString("yyyy-MM-dd");

            cmd1.CommandText = "INSERT INTO TBL_FECHAMENTO (FECH_DEBITO, FECH_CREDITO, FECH_DINHEIRO, FECH_CREDIARIO, FECH_TOTAL, FECH_HORA , FECH_DATA)"
            + " VALUES (@DEBITO, @CREDITO, @DINHEIRO, @CREDIARIO, @TOTAL, @HORA, @DATA) ";

            cmd1.Parameters.Add(new SqlParameter("@DEBITO",fechamento.Debito));
            cmd1.Parameters.Add(new SqlParameter("@CREDITO",fechamento.Credito));
            cmd1.Parameters.Add(new SqlParameter("@DINHEIRO",fechamento.Dinheito));
            cmd1.Parameters.Add(new SqlParameter("@CREDIARIO",fechamento.Crediario));
            cmd1.Parameters.Add(new SqlParameter("@TOTAL",fechamento.Total));
            cmd1.Parameters.Add(new SqlParameter("@HORA",fechamento.Time));
            cmd1.Parameters.Add(new SqlParameter("@DATA",date));

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
    }
}
