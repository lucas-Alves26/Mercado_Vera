using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Fechamento
    {
        public int Id { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal Dinheito { get; set; }
        public decimal Crediario { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public Fechamento(string debito, string credito, string dinheito, string crediario, string total, string date, string time)
        {
            if(debito == "")
            {
                debito = "0,00";
            }

            if (credito == "")
            {
                credito = "0,00";
            }

            if (dinheito == "")
            {
                dinheito = "0,00";
            }

            if (crediario == "")
            {
                crediario = "0,00";
            }

            if (total == "")
            {
                total = "0,00";
            }





            Debito = decimal.Parse(debito);
            Credito = decimal.Parse(credito);
            Dinheito = decimal.Parse(dinheito);
            Crediario = decimal.Parse(crediario);
            Total = decimal.Parse(total);
            Date =  DateTime.Parse(date);
            Time = TimeSpan.Parse(time);
        }
    }
}
