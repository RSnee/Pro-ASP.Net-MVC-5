using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private Product myProduct = new Product
        {
            ProductId = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersport",
            Price = 275M
        };

        // GET: Home
        public ActionResult Index()
        {
            return View(this.myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(this.myProduct);
        }
    }
}