﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
      //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
      //mock.Setup(m => m.Products).Returns(new List<Product>
      //{
      //    new Product { Name = "Football", Price = 25 },
      //    new Product { Name = "Surf Board", Price = 179 },
      //    new Product { Name = "Running shoes", Price = 95 }
      //});

      // kernel.Bind<IProductsRepository>().ToConstant(mock.Object);

      kernel.Bind<IProductsRepository>().To<EFProductRepository>();

        }
    }
}