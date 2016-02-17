using Ninject;
using Ninject.Web.WebApi;
using PNN.ProductsApp.ProductsDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNN.ProductsApp.Web.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam): base(kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        //public object GetService(Type serviceType)
        //{
        //    return _kernel.TryGet(serviceType);
        //}

        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    return _kernel.GetAll(serviceType);
        //}

        private void AddBindings()
        {
            //_kernel.Bind<ICategoryRepository>().To<CategoryRepository>().WithConstructorArgument("context", new ProductContext());
            //_kernel.Bind<IProductRepository>().To<ProductRepository>().WithConstructorArgument("context", new ProductContext());

            _kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel.BeginBlock());
        }
    }
}