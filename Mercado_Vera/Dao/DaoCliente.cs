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
    class DaoCliente
    {
        Conect conexao = new Conect();

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

                cmd1.CommandText = "INSERT INTO TBL_CLIENTE(CLI_NOME, CLI_RG, CLI_CPF, CLI_EMAIL, CLI_DIVIDA, CLI_STATUS) VALUES(@NOME, @RG, @CPF, @EMAIL, 0.00,'ATIVO')";
                cmd2.CommandText = "INSERT INTO TBL_TELEFONE(TEL_DDD, TEL_FIXO, TEL_CELULAR, TEL_OPERADORA)VALUES(@DDD, @FIXO, @CEL, @OPE)";
                cmd3.CommandText = "INSERT INTO TBL_ENDERECO(END_BAIRRO, END_RUA, END_NUMERO, END_CEP, END_COMP) VALUES(@BAIRRO,@RUA,@NUM,@CEP,@COMP)";


                cmd1.Parameters.Add(new SqlParameter("@NOME", cliente.Nome));

                if (cliente.Rg == "")
                    cmd1.Parameters.Add(new SqlParameter("@RG", DBNull.Value));
                else
                    cmd1.Parameters.Add(new SqlParameter("@RG", cliente.Rg));

                if (cliente.Cpf == "")
                    cmd1.Parameters.Add(new SqlParameter("@CPF", DBNull.Value));
                else
                    cmd1.Parameters.Add(new SqlParameter("@CPF", cliente.Cpf));

                if (cliente.Email == "")
                    cmd1.Parameters.Add(new SqlParameter("@EMAIL", DBNull.Value));
                else
                    cmd1.Parameters.Add(new SqlParameter("@EMAIL", cliente.Email));
                //-----
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
        public void EditarCli(Cliente cliente)
        {

            SqlConnection con = new SqlConnection(conexao.StrConexao());


            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();

            cmd1.CommandText = "UPDATE TBL_CLIENTE SET CLI_NOME = @NOME WHERE CLI_ID = " + cliente.Id.ToString();
            cmd2.CommandText = "UPDATE TBL_ENDERECO SET END_BAIRRO = @BAIRRO, END_RUA = @RUA, END_NUMERO = @NUM, END_CEP = @CEP, END_COMP = @COMP WHERE  END_ID = " + cliente.Endereco.Id.ToString();
            cmd3.CommandText = "UPDATE TBL_TELEFONE SET TEL_DDD = @DDD, TEL_CELULAR = @CEL, TEL_FIXO = @FIXO, TEL_OPERADORA = @OPE WHERE TEL_ID = " + cliente.Telefone.Id.ToString();


            cmd1.Parameters.Add(new SqlParameter("@NOME", cliente.Nome));

            if (cliente.Endereco.Bairro == "")
                cmd2.Parameters.Add(new SqlParameter("@BAIRRO", DBNull.Value));
            else
                cmd2.Parameters.Add(new SqlParameter("@BAIRRO", cliente.Endereco.Bairro));

            if (cliente.Endereco.Rua == "")
                cmd2.Parameters.Add(new SqlParameter("@RUA", DBNull.Value));
            else
                cmd2.Parameters.Add(new SqlParameter("@RUA", cliente.Endereco.Rua));

            if (cliente.Endereco.Num == -1)
                cmd2.Parameters.Add(new SqlParameter("@NUM", DBNull.Value));
            else
                cmd2.Parameters.Add(new SqlParameter("@NUM", cliente.Endereco.Num));

            if (cliente.Endereco.Cep == "0")
                cmd2.Parameters.Add(new SqlParameter("@CEP", DBNull.Value));
            else
                cmd2.Parameters.Add(new SqlParameter("@CEP", cliente.Endereco.Cep));

            if (cliente.Endereco.Comp == "")
                cmd2.Parameters.Add(new SqlParameter("@COMP", DBNull.Value));
            else
                cmd2.Parameters.Add(new SqlParameter("@COMP", cliente.Endereco.Comp));

            if (cliente.Telefone.Ddd == "0")
                cmd2.Parameters.Add(new SqlParameter("@DDD", DBNull.Value));
            else
                cmd3.Parameters.Add(new SqlParameter("@DDD", cliente.Telefone.Ddd));

            if (cliente.Telefone.Fixo == "0")
                cmd3.Parameters.Add(new SqlParameter("@FIXO", DBNull.Value));
            else
                cmd3.Parameters.Add(new SqlParameter("@FIXO", cliente.Telefone.Fixo));

            if (cliente.Telefone.Cel == "0")
                cmd3.Parameters.Add(new SqlParameter("@CEL", DBNull.Value));
            else
                cmd3.Parameters.Add(new SqlParameter("@CEL", cliente.Telefone.Cel));

            if (cliente.Telefone.Ope == "")
                cmd3.Parameters.Add(new SqlParameter("@OPE", DBNull.Value));
            else
                cmd3.Parameters.Add(new SqlParameter("@OPE", cliente.Telefone.Ope));


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

        public void DeleteCli(string id)
        {
            SqlDataReader dr = TrazTodosId(id);

            string endId = dr["END_ID"].ToString();
            string telId = dr["TEL_ID"].ToString();


            SqlConnection con = new SqlConnection(conexao.StrConexao());

            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();
            SqlCommand cmd4 = con.CreateCommand();

            cmd1.CommandText = "DELETE TBL_CLI_END WHERE END_ID = " + endId;
            cmd2.CommandText = "DELETE TBL_ENDERECO WHERE END_ID = " + endId;
            cmd3.CommandText = "DELETE TBL_CLIENTE WHERE CLI_ID = " + id;
            cmd4.CommandText = "DELETE TBL_TELEFONE WHERE TEL_ID = " + telId;

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
                cmd4.Transaction = tran;
                cmd4.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();

                throw new DomainExceptions("Erro, ao excluir o cliente");
            }
            finally
            {
                con.Close();
            }
        }
        public SqlDataReader TrazTodosId(string id)
        {
            string query = "SELECT C.CLI_ID, E.END_ID, CE.CLI_ID, T.TEL_ID FROM TBL_CLIENTE AS C "
            + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
            + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
            + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID WHERE C.CLI_ID = " + id;

            SqlDataReader dr = conexao.CarregarVariosDados(query);

            return dr;
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
        public DataTable SelectCliente()
        {
            string query = "SELECT CLI_ID, CLI_NOME FROM TBL_CLIENTE WHERE CLI_ID > 1 ORDER BY CLI_NOME ASC";
            return conexao.CarregarDados(query);
        }
        public DataTable SelectCliNome(string nome)
        {
            string query = "SELECT CLI_ID, CLI_NOME FROM TBL_CLIENTE " +
                "WHERE CLI_ID > 1 AND CLI_NOME LIKE '" + nome + "%' ORDER BY CLI_NOME ASC";
            return conexao.CarregarDados(query);
        }
        public DataTable SelectCliiD(string id)
        {
            string query = "SELECT CLI_ID, CLI_NOME FROM TBL_CLIENTE " +
                "WHERE  CLI_ID > 1 AND CLI_ID LIKE '" + id + "%' ORDER BY CLI_NOME ASC";
            return conexao.CarregarDados(query);
        }

        public DataTable PesqCliente(string id, string nome, string status)
        {
            string query = "";

            if (id != "" && status != "Todos")
            {
                query = "SELECT C.CLI_ID,C.CLI_NOME,C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
                + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
                + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
                + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
                + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
                + " WHERE C.CLI_ID LIKE '" + id + "%' AND C.CLI_STATUS = '" + status + "' AND C.CLI_ID > 1"
                + " ORDER BY C.CLI_NOME ASC";
            }

            else if (nome != "" && status != "Todos")
            {
                query = "SELECT C.CLI_ID, C.CLI_NOME, C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
              + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
              + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
              + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
              + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
              + " WHERE C.CLI_NOME LIKE '" + nome + "%' AND C.CLI_STATUS = '" + status + "' AND C.CLI_ID > 1"
              + " ORDER BY C.CLI_NOME ASC";
            }
            else if (status == "Todos" && (id != "" || nome != ""))
            {
                if (id == "") id = "0";
                if (nome == "") nome = "NADA";

                query = "SELECT C.CLI_ID, C.CLI_NOME,C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
              + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
              + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
              + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
              + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
              + " WHERE C.CLI_ID LIKE '" + id + "%' OR C.CLI_NOME LIKE '" + nome + "%'  AND C.CLI_ID > 1"
              + " ORDER BY C.CLI_NOME ASC";
            }

            else if (status == "Ativo")
            {
                query = "SELECT C.CLI_ID, C.CLI_NOME,C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
                + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
                + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
                + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
                + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
                + " WHERE C.CLI_STATUS = 'ATIVO' ORDER BY C.CLI_NOME ASC";
            }

            else if (status == "Inativo")
            {
                query = "SELECT C.CLI_ID, C.CLI_NOME,C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
                + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
                + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
                + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
                + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
                + " WHERE C.CLI_STATUS = 'INATIVO' ORDER BY C.CLI_NOME ASC";
            }

            else if (status == "Todos")
            {
                query = "SELECT C.CLI_ID, C.CLI_NOME,C.CLI_RG, E.END_RUA, E.END_NUMERO, T.TEL_CELULAR,"
                + " T.TEL_FIXO, C.CLI_DIVIDA, C.CLI_STATUS FROM TBL_CLIENTE AS C"
                + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
                + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
                + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID"
                + " ORDER BY C.CLI_NOME ASC";
            }


            return conexao.CarregarDados(query);
        }

        public SqlDataReader SelectEditarCli(string id)
        {
            string query = "  SELECT C.CLI_ID, C.CLI_NOME, E.END_ID, E.END_BAIRRO, E.END_RUA, E.END_NUMERO, E.END_COMP, E.END_CEP,"
            + " T.TEL_ID , T.TEL_DDD, T.TEL_CELULAR, T.TEL_FIXO, T.TEL_OPERADORA FROM TBL_CLIENTE AS C"
            + " INNER JOIN TBL_CLI_END  AS CE ON CE.CLI_ID = C.CLI_ID"
            + " INNER JOIN TBL_ENDERECO AS E ON E.END_ID = CE.END_ID"
            + " INNER JOIN TBL_TELEFONE AS T ON T.TEL_ID = C.TEL_ID WHERE C.CLI_ID = " + id;
            return conexao.CarregarVariosDados(query);

        }

    }
}
