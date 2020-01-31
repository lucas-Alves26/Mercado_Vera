using Mercado_Vera.Exceptions;
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
        public int FornId { get; set; }

        public Produto()
        {
        }

        public Produto(string id = "0")
        {
            Id = int.Parse(id);
        }

        public Produto(string cod, string nome, string preco, string precoVenda, string qtd, string qtdMin, string marca, string subCate, string fornId)
        {
            if(nome == "")
            {
                throw  new DomainExceptions("O nome do produto deve ser preenchido!");
            }
            if (preco == "")
            {
                throw new DomainExceptions("O preço de custo do produto deve ser preenchido!");
            }
            if (precoVenda == "")
            {
                throw new DomainExceptions("O preço de venda do produto deve ser preenchido!");
            }
            if (qtd == "")
            {
                throw new DomainExceptions("A quantidade do produto deve ser preenchida!");
            }
            if (subCate == "")
            {
                throw new DomainExceptions("A categoria do produto deve ser preenchida!");
            }
            if (qtdMin == "")
            {
                qtdMin = "0";
            }
            if (fornId == "")
            {
                fornId = "0";
            }

            Cod = cod;
            Nome = nome;
            Preco = decimal.Parse(preco);
            PrecoVenda = decimal.Parse(precoVenda);
            Qtd = int.Parse(qtd);
            QtdMin = int.Parse(qtdMin);
            Marca = marca;
            SubCate = int.Parse(subCate);
            FornId = int.Parse(fornId);
        }
    }
}
