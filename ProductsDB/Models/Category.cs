using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1024, ErrorMessage = "Name must be 1024 characters or less")]
        [Index("CategoryNameIdx", IsUnique = true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
