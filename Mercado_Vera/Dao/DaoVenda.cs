using dllDao;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoVenda
    {
        Conexao conexao = new Conexao();
        

        public void ConsultaQuantidade(string cod, string qtd)
        {
            string query = "SELECT PROD_QTD FROM TBL_PRODUTO WHERE PROD_COD = '"+ cod+"'";
            SqlDataReader dr = conexao.CarregarVariosDados(query);

                if(int.Parse(dr["PROD_QTD"].ToString()) < int.Parse(qtd) || int.Parse(dr["PROD_QTD"].ToString()) <= 0)
                {
                    //CORTA O MÉTODO E ENVIA ESSA MENSAGEM AO USUÁRIO
                    throw new DomainExceptions("Estoque do produto "+ dr["PROD_QTD"].ToString() + " , não é possivel adicionar essa quantidade!");
                }
            
        }

        public SqlDataReader RetornaProd(string cod)
        {
            string query = "SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME, P.PROD_VALOR_VENDA FROM  TBL_PRODUTO AS P WHERE P.PROD_COD =" + cod;
            return conexao.CarregarVariosDados(query);
        }
    }
}
