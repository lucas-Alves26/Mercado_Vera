using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Fornecedor
    {
        public int Id { get; set; }
        public string NomeFant { get; set; }
        public string Cnpj { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Fornecedor()
        {
        }

        public Fornecedor(int id)
        {
            Id = id;
        }

        public Fornecedor(string nomeFant, string cnpj, Telefone telefone, Endereco endereco)
        {
            if(nomeFant == "")
            {
                throw new DomainExceptions("O nome do fornecedor deve ser preenchido!");
            }

            if (cnpj !="" && cnpj.Length < 14)
            {
                throw new DomainExceptions("O CNPJ está faltando caracteres!");
            }

            NomeFant = nomeFant;
            Cnpj = cnpj;
            Telefone = telefone;
            Endereco = endereco;
        }
        public Fornecedor(string id, string nomeFant, string cnpj, Telefone telefone, Endereco endereco)
            :this(nomeFant, cnpj, telefone, endereco)
        {
            if (nomeFant == "")
            {
                throw new DomainExceptions("O nome do fornecedor deve ser preenchido!");
            }

            if (cnpj != "" && cnpj.Length < 14)
            {
                throw new DomainExceptions("O CNPJ está faltando caracteres!");
            }

            Id = int.Parse(id);
        }
    }
}
