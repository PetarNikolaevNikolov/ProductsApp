using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.Exceptions
{
    internal static class ExceptionHelper
    {
        /// <summary>
        /// To do extend it
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string TranslateException(Exception ex)
        {
            string result = null;
            if (ex is System.Data.SqlClient.SqlException)
            {
                var sqlException = (System.Data.SqlClient.SqlException)ex;
                if (sqlException.Number == 2601)
                {
                    result = "Unique contraint violated";
                }
            }
            else if (ex.InnerException != null)
            {
                result = TranslateException(ex.InnerException);
            }

            return result;
        }
    }
}
