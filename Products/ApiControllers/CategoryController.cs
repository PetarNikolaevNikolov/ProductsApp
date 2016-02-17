using PNN.ProductsApp.ProductsDB.DAL;
using PNN.ProductsApp.ProductsDB.Exceptions;
using PNN.ProductsApp.ProductsDB.Models;
using PNN.ProductsApp.Web.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PNN.ProductsApp.Web.ApiControllers
{
    public class CategoryController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var categoriesDTO = from c in categories
                                select new CategoryDTO() { Id = c.Id, Name = c.Name, Description = c.Description };
            return Ok(categoriesDTO);
        }

        [HttpGet]
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategoty(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(categoryDTO);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

            _unitOfWork.CategoryRepository.Update(category);

            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (DbBusinessException ex)
            { 
                ModelState.AddModelError("customMessage", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                ModelState.AddModelError("customMessage", ErrorMessages.GenericErrorMessage);
                return BadRequest(ModelState);
            }

            categoryDTO.Id = category.Id;

            return Ok(category);
        }

        [HttpPost]
        [ResponseType(typeof(CategoryDTO))]
        public async Task<IHttpActionResult> PostCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

            _unitOfWork.CategoryRepository.Add(category);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (DbBusinessException ex)
            {
                ModelState.AddModelError("customMessage", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                ModelState.AddModelError("customMessage", ErrorMessages.GenericErrorMessage);
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (DbBusinessException ex)
            {
                ModelState.AddModelError("customMessage", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                ModelState.AddModelError("customMessage", ErrorMessages.GenericErrorMessage);
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
