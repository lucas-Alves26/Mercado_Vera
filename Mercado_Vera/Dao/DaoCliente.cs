using dllDao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoCliente
    {
        Conexao conexao = new Conexao();

        
        public void CadastroCliente(Cliente cliente)
        {
            //VERIFICA SE EXISTE NOME CADASTRADO NO BANCO.
            string query = "SELECT COUNT(*) AS NUMERO FROM TBL_CLIENTE WHERE CLI_NOME ='" + cliente.Nome + "'";
            SqlDataReader dr = conexao.CarregarVariosDados(query);
            string numero = dr["NUMERO"].ToString();

            //SE O NUMERO FOR IGUAL A "1" É QUE JÁ EXISTE UM CLIENTE CADASTRADO COM ESSE NOME 
            if (int.Parse(numero) >= 1)
            {
                //CORTA O MÉTODO E ENVIA ESSA MENSAGEM AO USUÁRIO
                throw new DomainExceptions("Já existe um cliente cadastrado com esse nome");
            }
            else
            {
                SqlConnection con = new SqlConnection(conexao.StrConexao());
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd1.CommandText = "INSERT INTO TBL_CLIENTE(CLI_NOME) VALUES(@NOME)";
                cmd2.CommandText = "INSERT INTO TBL_TELEFONE(TEL_DDD, TEL_FIXO, TEL_CELULAR, TEL_OPERADORA)VALUES(@DDD, @FIXO, @CEL, @OPE)";
                cmd3.CommandText = "INSERT INTO TBL_ENDERECO(END_BAIRRO, END_RUA, END_NUMERO, END_CEP, END_COMP) VALUES(@BAIRRO,@RUA,@NUM,@CEP,@COMP)";


                cmd1.Parameters.Add(new SqlParameter("@NOME", cliente.Nome));

               
                if (cliente.Telefone.Ddd == "0")
                    cmd2.Parameters.Add(new SqlParameter("@DDD", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@DDD", cliente.Telefone.Ddd));

                if (cliente.Telefone.Fixo == "0")
                    cmd2.Parameters.Add(new SqlParameter("@FIXO", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@FIXO", cliente.Telefone.Fixo));

                if (cliente.Telefone.Cel == "0")
                    cmd2.Parameters.Add(new SqlParameter("@CEL", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@CEL", cliente.Telefone.Cel));

                if (cliente.Telefone.Ope == "")
                    cmd2.Parameters.Add(new SqlParameter("@OPE", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@OPE", cliente.Telefone.Ope));

                if (cliente.Endereco.Bairro == "")
                    cmd3.Parameters.Add(new SqlParameter("@BAIRRO", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@BAIRRO", cliente.Endereco.Bairro));

                if (cliente.Endereco.Rua == "")
                    cmd3.Parameters.Add(new SqlParameter("@RUA", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@RUA", cliente.Endereco.Rua));

                if (cliente.Endereco.Num == -1)
                    cmd3.Parameters.Add(new SqlParameter("@NUM", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@NUM", cliente.Endereco.Num));

                if (cliente.Endereco.Cep == "0")
                    cmd3.Parameters.Add(new SqlParameter("@CEP", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@CEP", cliente.Endereco.Cep));

                if (cliente.Endereco.Comp == "")
                    cmd3.Parameters.Add(new SqlParameter("@COMP", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@COMP", cliente.Endereco.Comp));


                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    cmd1.Transaction = tran;
                    cmd1.ExecuteNonQuery();
                    cmd2.Transaction = tran;
                    cmd2.ExecuteNonQuery();
                    cmd3.Transaction = tran;
                    cmd3.ExecuteNonQuery();
                    tran.Commit();

                    RelaciId();

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
        public void RelaciId()
        {
            //Traz o ultimo ID do Telefone para fazer o relacionamento
            string query = "SELECT MAX(TEL_ID) AS ID FROM TBL_TELEFONE";
            string telId = conexao.SelecioneId(query);

            //Traz o ultimo ID do fornecedor para fazer o relacionamento
            query = "SELECT MAX(CLI_ID) AS ID FROM TBL_CLIENTE";
            string cliId = conexao.SelecioneId(query);

            //Traz o ultimo ID do fornecedor para fazer o relacionamento
            query = "SELECT MAX(END_ID) AS ID FROM TBL_ENDERECO";
            string endId = conexao.SelecioneId(query);

            //Update na tabela fornecedor acrescentando telefone
            query = "UPDATE TBL_CLIENTE SET TEL_ID = " + telId + " WHERE CLI_ID = " + cliId;
            conexao.ExecutaInstrucaoNaBase(query);

            query = "INSERT INTO TBL_CLI_END(END_ID, CLI_ID)VALUES('" + endId + "','" + cliId + "')";
            conexao.ExecutaInstrucaoNaBase(query);
        }
    }
}
