using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Resources;
using System.Collections.Specialized;
using System.Web;
using PNN.ProductsApp.ProductsDB.DAL;
using PNN.ProductsApp.Web.Models;
using PNN.ProductsApp.ProductsDB.Models;
using PNN.ProductsApp.ProductsDB.Exceptions;
using PNN.ProductsApp.Web.Infrastructure;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PNN.ProductsApp.Web.ApiControllers
{
    public class ProductController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductDTO productDTO = new ProductDTO()
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name
            };
            return Ok(productDTO);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(ProductDTO productDTO)
        {
            SaveImage(productDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = new Product()
            {
                CategoryId = productDTO.CategoryId,
                Description = productDTO.Description,
                Id = productDTO.Id,
                ImageUrl = productDTO.ImageUrl,
                Name = productDTO.Name
            };

            _unitOfWork.ProductRepository.Update(product);

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

            return Ok(product);
        }

        [HttpPost]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(ProductDTO productDTO)
        {
            SaveImage(productDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = new Product()
            {
                CategoryId = productDTO.CategoryId,
                Description = productDTO.Description,
                Id = productDTO.Id,
                ImageUrl = productDTO.ImageUrl,
                Name = productDTO.Name 
            };

            _unitOfWork.ProductRepository.Add(product);
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

            productDTO.Id = product.Id;

            return Ok(productDTO);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
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

        private void SaveImage(ProductDTO productDTO)
        {
            try
            {
                if (!string.IsNullOrEmpty(productDTO.ImageData))
                {
                    string imgAsBase64 = productDTO.ImageData;
                    //removing the not needed start information:
                    Regex rgx = new Regex("data:image/.*;base64,");
                    imgAsBase64 = rgx.Replace(imgAsBase64, string.Empty);

                    productDTO.ImageUrl =
                        ImageHelper.SaveBase64Image(
                            imgAsBase64, 
                            productDTO.ImageExtension);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("customMessage", ErrorMessages.GenericErrorMessage);
            }
        }
    }
}
