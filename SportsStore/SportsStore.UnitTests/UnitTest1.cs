﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
      Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
      mock.Setup(m => m.Products).Returns(new Product[]
        {
          new Product { ProductID = 1, Name= "P1" },
          new Product { ProductID = 2, Name= "P2" },
          new Product { ProductID = 3, Name= "P3" },
          new Product { ProductID = 4, Name= "P4" },
          new Product { ProductID = 5, Name= "P5" },
          });

      ProductController controller = new ProductController(mock.Object);
      controller.PageSize = 3;

      ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

      Product[] prodArray = result.Products.ToArray();
      Assert.IsTrue(prodArray.Length == 2);
      Assert.AreEqual(prodArray[0].Name, "P4");
      Assert.AreEqual(prodArray[1].Name, "P5");
        }

    [TestMethod]
    public void Can_Generate_Page_Links()
      {
      HtmlHelper myhelper = null;
      PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, ItemsPerPage = 10, TotalItems = 28 };
      Func<int, string> pageUrlDelegate = i => "Page" + i;

      MvcHtmlString result = myhelper.PageLinks(pagingInfo, pageUrlDelegate);

      string erwartet = @"<a class=""btn btn-default"" href=""Page1"">1</a>"
                    + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                    + @"<a class=""btn btn-default"" href=""Page3"">3</a>";

      Assert.AreEqual(erwartet, result.ToString());
      }

    [TestMethod]
    public void Can_Send_Pagination_View_Model()
      {
      Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
      mock.Setup(m => m.Products).Returns(new Product[]
        {
          new Product { ProductID = 1, Name= "P1" },
          new Product { ProductID = 2, Name= "P2" },
          new Product { ProductID = 3, Name= "P3" },
          new Product { ProductID = 4, Name= "P4" },
          new Product { ProductID = 5, Name= "P5" },
          });

      ProductController controller = new ProductController(mock.Object);
      controller.PageSize = 3;

      ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

      PagingInfo pageInfo = result.PagingInfo;
      Assert.AreEqual(pageInfo.CurrentPage, 2);
      Assert.AreEqual(pageInfo.ItemsPerPage, 3);
      Assert.AreEqual(pageInfo.TotalItems, 5);
      Assert.AreEqual(pageInfo.TotalPages, 2);
      }



    }
}
