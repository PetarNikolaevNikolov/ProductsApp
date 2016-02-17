using PNN.ProductsApp.ProductsDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.DAL
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>//to do: change this behaviour when going to production
    {

        protected override void Seed(ProductContext context)
        {
            Category fruitsCategoty = new Category
            {
                Name = "Fruits",
                Description = "In botany, a fruit is the seed-bearing structure in angiosperms formed from the ovary after flowering."
            };

            Category vegetablesCategoty = new Category
            {
                Name = "Vegetables",
                Description = "In everyday usage, a vegetable is any part of a plant that is consumed by humans as food as part of a savory meal"
            };

            var categoties = new List<Category>
            {
                fruitsCategoty,
                vegetablesCategoty
            };



            var products = new List<Product>
            {
                new Product{ Category = fruitsCategoty, Name = "Apple", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Apricot", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Avocado", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Banana", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Blackberry", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Blueberry", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Cherry", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Coconut", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Grape", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Kiwi fruit", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Lemon", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Lime", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Mango", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Melon", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Watermelon", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Nectarine", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Olive", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Orange", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Papaya", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Peach", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Plum", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = fruitsCategoty, Name = "Boold Orange", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},

                new Product{ Category = vegetablesCategoty, Name = "Artichoke", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Arugula", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Eggplant", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Celery", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Corn salad", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Lavender", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Lemon Grass", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Rosemary", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Mushrooms", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Onion", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Garlic", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Green pepper", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Chili pepper", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Paprika", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Tabasco pepper", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Carrot", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Ginger", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Cucumber", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Pumpkin", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
                new Product{ Category = vegetablesCategoty, Name = "Potato", Description = "to do put something meaningless here", ImageUrl = "/Content/Images/9b4a9d9a-07fd-40fe-97e6-c3f3581b56a0.jpg"},
            };

            categoties.ForEach(c => context.Categories.Add(c));
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
