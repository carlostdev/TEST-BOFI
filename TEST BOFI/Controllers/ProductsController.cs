using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST_BOFI.DataAccess;
using TEST_BOFI.Models;

namespace TEST_BOFI.Controllers
{
    public class ProductsController : ApiController
    {
        ProductRepository Repository;

        public ProductsController()
        {
            Repository = new ProductRepository();
        }
        
        public ProductsController(List<Product> productos)
        {
            Repository = new ProductRepository(productos);
        }

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return Repository.SelectAll();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return Repository.SelectById(id);
        }

        // POST: api/Products
        public HttpResponseMessage Post(Product product)
        {
            Repository.Insert(product);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Products/5
        public void Put(Product product)
        {
            Repository.Update(product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            Repository.Delete(id);
        }
    }
}
