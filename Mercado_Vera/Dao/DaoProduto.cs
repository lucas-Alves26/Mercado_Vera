﻿using dllDao;
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
    class DaoProduto
    {
        public Produto produto { get; set;}

        public Conexao conexao = new Conexao();

        //metodo para cadastrar o produto
        public void CadastroProd()
        {
            //VERIFICA SE NÃO EXISTE NEM PRODUTO COM ESSE COD OU NOME CADASTRADO.
            string query = "SELECT COUNT(*) AS NUMERO FROM TBL_PRODUTO WHERE PROD_COD = '"+produto.Cod+ "' OR PROD_NOME = '"+produto.Nome+"'";
            SqlDataReader dr = conexao.CarregarVariosDados(query);
            string numero = dr["NUMERO"].ToString();

            //SE O NUMERO FOR IGUAL A "1" É QUE JÁ EXISTE UM PRODUTO CADASTRADO COM ESSE NOME OU CÓDIGO
            if (int.Parse(numero) >= 1)
            {
                //CORTA O MÉTODO E ENVIA ESSA MENSAGEM AO USUÁRIO
                throw new DomainExceptions("Já existe um produto cadastrado com esse código ou nome");
            }
            else
            {
                SqlConnection con = new SqlConnection(conexao.StrConexao());
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.CommandText = "INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)"
                    + " VALUES (@CODBARRA,@NOME,@MARCA,@QTD,@QTDMIN,@PRECO,@PRECOVENDA,@CAT_ID)";

                cmd1.Parameters.Add(new SqlParameter("@CODBARRA", produto.Cod));
                cmd1.Parameters.Add(new SqlParameter("@NOME", produto.Nome));

                if(produto.Marca == "")
                    cmd1.Parameters.Add(new SqlParameter("@MARCA", DBNull.Value));                
                else               
                    cmd1.Parameters.Add(new SqlParameter("@MARCA", produto.Marca));
                
                cmd1.Parameters.Add(new SqlParameter("@QTD", produto.Qtd));

                if(produto.QtdMin == 0)
                    cmd1.Parameters.Add(new SqlParameter("@QTDMIN", DBNull.Value));
                else
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
                    //metodo que insere idprod e idforn na tabela Prod_Forn                    
                    tran.Commit();

                    RelaciIdProdForn();

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
        //METODO PARA PREENCHER O COMBOX CATEGORIA
        public DataTable SelectCategoria()
        {
            string query = "SELECT SUB_CAT_ID, SUB_CAT_TIPO FROM TBL_SUB_CATEGORIA ORDER BY SUB_CAT_TIPO ASC";
            return conexao.CarregarDados(query);
        }
        //METODO PARA EXCLUIR PRODUTO
        public void DeleteProd()
        {
         
            SqlConnection con = new SqlConnection(conexao.StrConexao());

            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
  
            cmd1.CommandText = "DELETE TBL_PROD_FORN WHERE PROD_ID =" + produto.Id.ToString();
            cmd2.CommandText = "DELETE TBL_PRODUTO WHERE PROD_ID = " + produto.Id.ToString();

           
            con.Open();

            SqlTransaction tran = con.BeginTransaction();

            try
            {
                cmd1.Transaction = tran;
                cmd1.ExecuteNonQuery();
                cmd2.Transaction = tran;
                cmd2.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();

                throw new DomainExceptions("Erro, ao excluir o produto");
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable SelectMarca()
        {
            string query = "SELECT DISTINCT PROD_MARCA FROM TBL_PRODUTO WHERE PROD_MARCA IS NOT NULL ORDER BY PROD_MARCA ASC";
            return conexao.CarregarDados(query);
        }
        public DataTable SelectProdDel(string busca)
        {
            string query="";

            if (busca == "")
            {
                query = "SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME,P.PROD_VALOR, P.PROD_QTD, P.PROD_MARCA FROM  TBL_PRODUTO AS P "
                     + "ORDER BY PROD_NOME ASC";
            }

            else if (busca != "")
            {
                query = "SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME, P.PROD_VALOR_VENDA, P.PROD_QTD, P.PROD_MARCA FROM  TBL_PRODUTO AS P " +
                "WHERE P.PROD_MARCA = '" + busca + "' ORDER BY PROD_NOME ASC";
            }
            return conexao.CarregarDados(query);
        }

        public DataTable SelectProdNome(string nome)
        {
            string query = "SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME,P.PROD_VALOR, P.PROD_QTD, P.PROD_MARCA FROM  TBL_PRODUTO AS P " +
                "WHERE P.PROD_NOME LIKE '"+nome+"%' ORDER BY PROD_NOME ASC";
            return conexao.CarregarDados(query);
        }




        public void RelaciIdProdForn()
        {
            //Traz o ultimo ID do produto para fazer o relacionamento
            string SQLquery = "SELECT MAX(PROD_ID) AS ID FROM TBL_PRODUTO";
            //Armazena o ID
            string prodId = conexao.SelecioneId(SQLquery);
            if(produto.FornId ==0)
                SQLquery = "INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES('"+prodId+"', NULL)";
            else
                SQLquery = "INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES('" + prodId + "','" + produto.FornId + "')";

            conexao.ExecutaInstrucaoNaBase(SQLquery);
        }
        public SqlDataReader TrazTodosId()
        {
            string query = "";

            SqlDataReader dr = conexao.CarregarVariosDados(query);
            return dr;
        }

    }
}
