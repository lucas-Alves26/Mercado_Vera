using System;


namespace Mercado_Vera.Exceptions
{
    class DomainExceptions : ApplicationException
    {
        public DomainExceptions()
        {
        }
        public DomainExceptions(string message) : base(message)
        {

        }

    }
}
