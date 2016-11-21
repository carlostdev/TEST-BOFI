using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_BOFI.Models;

namespace TEST_BOFI.DataAccess
{
    interface IProductRepository
    {
        IEnumerable<Product> SelectAll();
        Product SelectById(int id);
        void Insert(Product obj);
        void Update(Product obj);
        void Delete(int id);
    }
}
