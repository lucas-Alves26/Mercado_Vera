using dllDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoFoto
    {
        Conexao conexao = new Conexao();

        public byte[] RetornaImg(string id)
        {
            byte[] data;
            SqlConnection con = new SqlConnection(conexao.StrConexao());
            
            string query = "SELECT FOTO FROM TBL_PRODUTO WHERE PROD_ID = " + id;
            SqlDataReader dt = conexao.CarregarVariosDados(query);
            string foto = dt["FOTO"].ToString();

            if(foto == "")
            {
                data = null;
            }
            else
            {
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);

                con.Open();
                DataSet ds = new DataSet();
                cmd.Fill(ds, "mercado_01.tbl_produto");
                int cont = ds.Tables["mercado_01.tbl_produto"].Rows.Count;

                data = new Byte[0];
                data = (byte[])(ds.Tables["mercado_01.tbl_produto"].Rows[cont - 1]["FOTO"]);
            }
            return data;
        }
        
    }
}
