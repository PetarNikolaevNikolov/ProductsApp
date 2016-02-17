using PNN.ProductsApp.ProductsDB.Exceptions;
using PNN.ProductsApp.ProductsDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.DAL
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ProductContext _context = new ProductContext();
        private EfGenericRepository<Category> _categoryRepository;
        private EfGenericRepository<Product> _productRepository;
        private bool _disposed = false;



        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new EfGenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new EfGenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ExceptionHelper.TranslateException(ex);
                if (!string.IsNullOrEmpty(message))
                {
                    throw new DbBusinessException(message, ex);
                }
                else
                {
                    throw new DbBusinessException(ex.Message, ex);// to do remove this when the translator is extendet
                }
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ExceptionHelper.TranslateException(ex);
                if (!string.IsNullOrEmpty(message))
                {
                    throw new DbBusinessException(message, ex);
                }
                else
                {
                    throw new DbBusinessException(ex.Message, ex);// to do remove this when the translator is extendet
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
