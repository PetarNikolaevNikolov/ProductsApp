using PNN.ProductsApp.ProductsDB.DAL;
using PNN.ProductsApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PNN.ProductsApp.Web.ApiControllers
{
    public class ProductFilterController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductFilterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProducts([FromUri] ProductFilter productFilter)
        {
             var result = await _unitOfWork.ProductRepository.AsQueryable().Include(p => p.Category).
                    Where(p => (productFilter.Id == null || productFilter.Id == p.Id)
                    && (string.IsNullOrEmpty(productFilter.Name) || p.Name.ToUpper().Contains(productFilter.Name.ToUpper()))
                    && (string.IsNullOrEmpty(productFilter.CategoryName) || p.Category.Name.ToUpper().Contains(productFilter.CategoryName.ToUpper()))).
                    Select(p => new ProductDTO()
                    {
                        CategoryId = p.CategoryId,
                        Description = p.Description,
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Name = p.Name,
                        CategoryName = p.Category.Name
                    }).ToListAsync();
            return Ok(result);
        }
    }
}
