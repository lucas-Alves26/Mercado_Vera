using dllDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoFornecedor
    {
        Conexao conexao = new Conexao();

        public DataTable SelectForne()
        {
            string query = "SELECT DISTINCT FOR_ID, FOR_NOME_FANT FROM TBL_FORNECEDOR";
            return conexao.CarregarDados(query);
        }
    }
}
