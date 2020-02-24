using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Venda
    {
        public int CliId { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Date { get; set; }

        public Venda()
        {
        }

        public Venda(int cliId, decimal valorTotal, DateTime date)
        {
            CliId = cliId;
            ValorTotal = valorTotal;
            Date = date;
        }
    }


    
}
