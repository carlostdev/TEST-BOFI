using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEST_BOFI.Controllers;
using TEST_BOFI.Models;
using TEST_BOFI.DataAccess;
using System.Collections.Generic;

namespace TEST_BOFI.Tests
{
    [TestClass]
    public class TestProductRepository
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductRepository(testProducts);

            var result = controller.SelectAll() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductRepository(testProducts);

            var result = controller.SelectById(4);
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProductRepository(GetTestProducts());

            var result = controller.SelectById(999);
            Assert.IsNull(result);
        }
        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { Id = 1, Name = "Demo1", Description = "Test Description", AgeRestriction = 4, Company = "TestCo", Price = 1 });
            testProducts.Add(new Product { Id = 2, Name = "Demo2", Description = "Test Description", AgeRestriction = 12, Company = "TestCo", Price = 10.50m });
            testProducts.Add(new Product { Id = 3, Name = "Demo3", Description = "Test Description", AgeRestriction = 18, Company = "TestCo", Price = 19.99m });
            testProducts.Add(new Product { Id = 4, Name = "Demo4", Description = "Test Description", AgeRestriction = 3, Company = "TestCo", Price = 450.17m });
            testProducts.Add(new Product { Id = 5, Name = "Demo5", Description = "Test Description", AgeRestriction = 1, Company = "TestCo", Price = 10 });

            return testProducts;
        }
    }
}