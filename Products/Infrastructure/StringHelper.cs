using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNN.ProductsApp.Web.Infrastructure
{
    public static class StringHelper
    {
        public static int? ToNullableInt(this string str)
        {
            int tml;
            int? result = null;
            if (Int32.TryParse(str, out tml))
            {
                result = tml;
            }
            return result;
        }
    }
}