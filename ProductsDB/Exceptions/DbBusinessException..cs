using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.Exceptions
{
    public class DbBusinessException : Exception
    {
        public DbBusinessException(): base() { }

        public DbBusinessException(string message) : base(message) { }

        public DbBusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
