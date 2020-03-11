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
        public  Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, Telefone telefone, Endereco endereco)
        {
            if (nome == "")
            {
                throw new DomainExceptions("O nome do Cliente deve ser preenchido!");
            }

            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente(string id, string nome, Telefone telefone, Endereco endereco) : this (nome, telefone,endereco)
        {

            Id = int.Parse(id);
            
        }
    }
}
