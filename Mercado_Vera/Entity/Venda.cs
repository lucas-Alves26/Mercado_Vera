using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Venda
    {
        public int VendId { get; set; }
        public int CliId { get; set; }
        public int Qtd { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Date { get; set; }
        public string TipoPagamento { get; set; }
        public string Bandeira { get; set; }
        public int Parcelas { get; set; }


        public Venda()
        {
        }

        public Venda(int cliId, int qtd, decimal valorTotal, DateTime date, string tipoPagamento, string bandeira, int parcelas)
        {
            CliId = cliId;
            Qtd = qtd;
            ValorTotal = valorTotal;
            Date = date;
            TipoPagamento = tipoPagamento;
            Bandeira = bandeira;
            Parcelas = parcelas;
        }
    }


    
}
