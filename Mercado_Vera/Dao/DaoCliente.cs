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
            string query = "SELECT COUNT(*) AS NUMERO FROM TBL_CLIENTE WHERE CLI_NOME = '" + cliente.Nome;
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

                cmd1.CommandText = "INSERT INTO TBL_FORNECEDOR(FOR_CNPJ,FOR_NOME_FANT) VALUES(@CNPJ,@NOME)";
                cmd2.CommandText = "INSERT INTO TBL_TELEFONE(TEL_DDD, TEL_FIXO, TEL_CELULAR, TEL_OPERADORA)VALUES(@DDD, @FIXO, @CEL, @OPE)";
                cmd3.CommandText = "INSERT INTO TBL_ENDERECO(END_BAIRRO, END_RUA, END_NUMERO, END_CEP, END_COMP) VALUES(@BAIRRO,@RUA,@NUM,@CEP,@COMP)";


                cmd1.Parameters.Add(new SqlParameter("@NOME", fornecedor.NomeFant));

                if (fornecedor.Cnpj == "")
                    cmd1.Parameters.Add(new SqlParameter("@CNPJ", DBNull.Value));
                else
                    cmd1.Parameters.Add(new SqlParameter("@CNPJ", fornecedor.Cnpj));

                if (fornecedor.Telefone.Ddd == 0)
                    cmd2.Parameters.Add(new SqlParameter("@DDD", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@DDD", fornecedor.Telefone.Ddd));

                if (fornecedor.Telefone.Fixo == 0)
                    cmd2.Parameters.Add(new SqlParameter("@FIXO", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@FIXO", fornecedor.Telefone.Fixo));

                if (fornecedor.Telefone.Cel == 0)
                    cmd2.Parameters.Add(new SqlParameter("@CEL", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@CEL", fornecedor.Telefone.Cel));

                if (fornecedor.Telefone.Ope == "")
                    cmd2.Parameters.Add(new SqlParameter("@OPE", DBNull.Value));
                else
                    cmd2.Parameters.Add(new SqlParameter("@OPE", fornecedor.Telefone.Ope));

                if (fornecedor.Endereco.Bairro == "")
                    cmd3.Parameters.Add(new SqlParameter("@BAIRRO", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@BAIRRO", fornecedor.Endereco.Bairro));

                if (fornecedor.Endereco.Rua == "")
                    cmd3.Parameters.Add(new SqlParameter("@RUA", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@RUA", fornecedor.Endereco.Rua));

                if (fornecedor.Endereco.Num == -1)
                    cmd3.Parameters.Add(new SqlParameter("@NUM", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@NUM", fornecedor.Endereco.Num));

                if (fornecedor.Endereco.Cep == 0)
                    cmd3.Parameters.Add(new SqlParameter("@CEP", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@CEP", fornecedor.Endereco.Cep));

                if (fornecedor.Endereco.Comp == "")
                    cmd3.Parameters.Add(new SqlParameter("@COMP", DBNull.Value));
                else
                    cmd3.Parameters.Add(new SqlParameter("@COMP", fornecedor.Endereco.Comp));


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

    }
}
