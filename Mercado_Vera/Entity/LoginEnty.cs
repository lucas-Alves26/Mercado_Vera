using Mercado_Vera.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class LoginEnty
    {
        public bool tem;
        public string Mensagen = "";

        public bool acessar(string login, string senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLogin(login, senha);
            if (!loginDao.Mensagen.Equals(""))
            {
                this.Mensagen = loginDao.Mensagen;

            }
            return tem;
        }
    }
}
