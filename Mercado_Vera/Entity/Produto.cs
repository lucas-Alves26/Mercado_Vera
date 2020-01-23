using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Cod { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Qtd { get; set; }
        public int QtdMin { get; set; }
        public string Marca { get; set; }
        public int SubCate { get; set; }

        public Produto()
        {
        }

        public Produto(string cod, string nome, string preco, string precoVenda, string qtd, string qtdMin, string marca, string subCate)
        {
            Cod = cod;
            Nome = nome;
            Preco = decimal.Parse(preco);
            PrecoVenda = decimal.Parse(precoVenda);
            Qtd = int.Parse(qtd);
            QtdMin = int.Parse(qtdMin);
            Marca = marca;
            SubCate = int.Parse(subCate);
        }
    }
}
