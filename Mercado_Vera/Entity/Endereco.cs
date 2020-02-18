using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Endereco
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Num { get; set; }
        public string Cep { get; set; }
        public string Comp { get; set; }

        public Endereco()
        {
        }

        public Endereco(string bairro, string rua, string num, string cep, string comp)
        {
            if(num == "")
            {
                num = "-1";
            }
            if(cep == "")
            {
                cep = "0";
            }

            Bairro = bairro;
            Rua = rua;
            Num = int.Parse(num);
            Cep = cep;
            Comp = comp;
        }

        public Endereco(string id , string bairro, string rua, string num, string cep, string comp)
            : this(bairro,rua,num,cep,comp)
        {
            if (num == "")
            {
                num = "-1";
            }
            if (cep == "")
            {
                cep = "0";
            }

            Id = int.Parse(id);
        }
    }
}
