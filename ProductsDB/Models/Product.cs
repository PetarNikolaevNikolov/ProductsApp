using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNN.ProductsApp.ProductsDB.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1024, ErrorMessage = "Name must be 1024 characters or less")]
        [Index("ProductNameIdx")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Index("ProductCategotyIdIdx")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
