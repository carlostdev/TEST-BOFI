using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TEST_BOFI.Models;

namespace TEST_BOFI.DataAccess
{
    public class ProductRepository:IProductRepository
    {
        private List<Product> AllProducts;
        private XDocument ProductData;

        public ProductRepository()
        {
            AllProducts = new List<Product>();
            ProductData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Products.xml"));
            var Products = from p in ProductData.Descendants("Product")
                           select new Product
                           {
                               Id = (int)p.Element("Id"),
                               Name = p.Element("Name").Value,
                               Description = p.Element("Description").Value,
                               AgeRestriction = (int)p.Element("AgeRestriction"),
                               Company = p.Element("Company").Value,
                               Price = (decimal)p.Element("Price")
                           };
            AllProducts.AddRange(Products.ToList<Product>());
        }

        public ProductRepository(List<Product> products)
        {
            AllProducts = products;
        }

        public IEnumerable<Product> SelectAll()
        {
            return AllProducts;
        }

        public Product SelectById(int id)
        {
            return AllProducts.Find(Product => Product.Id == id);
        }

        public void Insert(Product obj)
        {
            obj.Id = (int)(from P in ProductData.Descendants("Product")
                           orderby (int)P.Element("Id") descending
                           select (int)P.Element("Id")).FirstOrDefault() + 1;

            ProductData.Root.Add(new XElement("Product", new XElement("Id",obj.Id),
                new XElement("Name",obj.Name),
                new XElement("Description",obj.Description),
                new XElement("AgeRestriction",obj.AgeRestriction),
                new XElement("Company",obj.Company),
                new XElement("Price",obj.Price)
                )
            );
            ProductData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Products.xml"));
        }

        public void Update(Product obj)
        {
            XElement node = ProductData.Root.Elements("Product").Where(i => (int)i.Element("Id") == obj.Id).FirstOrDefault();

            node.SetElementValue("Name", obj.Name);
            node.SetElementValue("Description", obj.Description);
            node.SetElementValue("AgeRestriction", obj.AgeRestriction);
            node.SetElementValue("Company", obj.Company);
            node.SetElementValue("Price", obj.Price);
            ProductData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Products.xml"));
        }

        public void Delete(int id)
        {
            ProductData.Root.Elements("Product").Where(i => (int)i.Element("Id") == id).Remove();
            ProductData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Products.xml"));
        }
    }
}