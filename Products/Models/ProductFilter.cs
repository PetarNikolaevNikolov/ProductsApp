using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNN.ProductsApp.Web.Models
{
    public class ProductFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}