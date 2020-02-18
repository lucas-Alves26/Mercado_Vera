using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Telefone
    {
        public int Id { get; set; }
        public string Ddd { get; set; }
        public string Ope { get; set; }
        public string Fixo { get; set; }
        public string Cel { get; set; }

        public Telefone()
        {
        }

        public Telefone(int id)
        {
            Id = id;
        }

        public Telefone(string ddd, string ope, string fixo, string cel)
        {
            if(ddd == "")
            {
                ddd ="0";
            }
            else if (ddd.Length < 3)
            {
                throw new DomainExceptions("O DDD do telefone não pode ser menor que 3 dígitos");
            }
            if(fixo == "")
            {
                fixo = "0";
            }
            else if (fixo.Length < 8)
            {
                throw new DomainExceptions("O telefone fixo não pode ser menor que 8 dígitos");
            }
            if (cel == "")
            {
                cel = "0";
            }
            else if (cel != "0" && cel.Length < 9)
            {
                throw new DomainExceptions("O telefone celular não pode ser menor que 9 dígitos");
            }

            Ddd = ddd;
            Ope = ope;
            Fixo = fixo;
            Cel = cel;
        }

        public Telefone(string id, string ddd, string ope, string fixo, string cel)
            : this(ddd, ope, fixo, cel)
        {
            Id = int.Parse(id);
        }


    }
}
