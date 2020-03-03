using dllDao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public string Mensagen = "";//tudo ok.
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool verificarLogin(string login, string senha)
        {
            //comandos sqlpara verificar se tem no banco.
            cmd.CommandText = "SELECT * FROM TBL_LOGIN WHERE LOG_LOGIN = @login AND LOG_SENHA = @senha";
            cmd.Parameters.AddWithValue("@login", login);//recebe o login do banco e troca pela varialvel criada.
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)// se foi encontrado 
                {
                    tem = true;//retorna 'tem' e acessa os dados
                }
            }
            catch (SqlException)
            {
                this.Mensagen = "Erro no Banco de Dados!!";// caso não encontre, retorna o erro no banco.
            }
            return tem;

        }

    }
}
