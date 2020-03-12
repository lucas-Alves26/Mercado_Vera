using Mercado_Vera.Exceptions;
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

        public Venda(string cliId, string qtd, string valorTotal, string date, string tipoPagamento, string bandeira, string parcelas)
        {
            if(tipoPagamento == "Crédito")
            {
                if (bandeira == "" || bandeira == null)
                {
                    throw new DomainExceptions("A bandeira do cartão deve ser preenchida!");
                }
                else if(parcelas == "" || parcelas == null)
                {
                    throw new DomainExceptions("o número de parcelas do cartão deve ser preenchida!");
                }
            }
            if(tipoPagamento == "Débito")
            {
                if(bandeira == "" || bandeira == null)
                {
                    throw new DomainExceptions("A bandeira do cartão deve ser preenchida!");
                }
            }
            if(parcelas == null || parcelas == "")
            {
                parcelas = "0";
            }
       
            CliId = int.Parse(cliId);
            Qtd = int.Parse(qtd);
            ValorTotal = decimal.Parse(valorTotal);
            Date = DateTime.Parse(date);
            TipoPagamento = tipoPagamento;
            Bandeira = bandeira;
            Parcelas = int.Parse(parcelas);
        }
    }


    
}
