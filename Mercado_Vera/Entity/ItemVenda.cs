using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class ItemVenda
    {
        public int VendaId { get; set; }
        public int ProdId { get; set; }
        public decimal ValorTotal { get; set; }
        public int Qtd { get; set; }

        public ItemVenda()
        {
        }

        public ItemVenda(string prodId, string valorTotal, string qtd)
        {
            //VendaId = int.Parse(vendaId);
            ProdId = int.Parse(prodId);
            ValorTotal = decimal.Parse(valorTotal);
            Qtd = int.Parse(qtd);
        }
    }
}
