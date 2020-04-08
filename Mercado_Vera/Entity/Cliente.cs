using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public  Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string rg, string cpf, string email, Telefone telefone, Endereco endereco)
        {
            if (nome == "")
            {
                throw new DomainExceptions("O nome do Cliente deve ser preenchido!");
            }

            if (rg == "")
            {
                throw new DomainExceptions("O RG do Cliente deve ser preenchido!");
            }

            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente(string id, string nome, string rg, string cpf, string email, string status, Telefone telefone, Endereco endereco) : this (nome, rg, cpf, email, telefone, endereco)
        {

            Id = int.Parse(id);
            Status = status;
            
        }
    }
}
