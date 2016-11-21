using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_BOFI.DataAccess;
using TEST_BOFI.Models;

namespace TEST_BOFI.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository productRepository = new ProductRepository();
        // GET: Home
        public ActionResult Index()
        {
            var model = productRepository.SelectAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        public ActionResult Edit()
        {
            return PartialView();
        }
    }
}