using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApi.Contracts;
using ProductsApi.Services;
using Moq;
using ProductsApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProductsApi.Data;
using System.Data.Entity;
using ProductsApi.Tests.MockData;

namespace ProductsApi.Tests
{
    [TestClass]
    public class ProductsSearchServiceTests
    {
        private MocksProducts _products;

        public ProductsSearchServiceTests()
        {
            _products = new MocksProducts();
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var sut = CreateProductSearchService();

            var products = sut.GetAll();

            Assert.AreEqual(3, products.Items.Count);
            Assert.AreEqual(_products.FirstItemGuid, products.Items[0].Id);
            Assert.AreEqual(_products.SecondItemGuid, products.Items[1].Id);
            Assert.AreEqual(_products.ThirdItemGuid, products.Items[2].Id);
        }

        [TestMethod]
        public void GetById_CorrectGuid_ReturnsCorrectProduct()
        {
            var sut = CreateProductSearchService();

            var product = sut.GetById(_products.FirstItemGuid);

            Assert.AreEqual(_products.FirstItemGuid, product.Id);
            Assert.AreEqual("Samsung Galaxy S7", product.Name);

            product = sut.GetById(_products.SecondItemGuid);

            Assert.AreEqual(_products.SecondItemGuid, product.Id);
            Assert.AreEqual("Apple iPhone 6S", product.Name);

            product = sut.GetById(_products.ThirdItemGuid);

            Assert.AreEqual(_products.ThirdItemGuid, product.Id);
            Assert.AreEqual("Apple iPhone 5s", product.Name);
        }

        [TestMethod]
        public void GetById_IncorrectGuid_ReturnsNull()
        {
            var sut = CreateProductSearchService();

            var product = sut.GetById(Guid.NewGuid());

            Assert.AreEqual(null, product);
        }

        [TestMethod]
        public void GetProductsByName_CorrectName_ReturnsCorrectProduct()
        {
            var sut = CreateProductSearchService();

            var products = sut.GetByName("Samsung");

            Assert.AreEqual(1, products.Items.Count);
            Assert.AreEqual(_products.FirstItemGuid, products.Items[0].Id);
            Assert.AreEqual("Samsung Galaxy S7", products.Items[0].Name);

            products = sut.GetByName("Apple");

            Assert.AreEqual(2, products.Items.Count);
            Assert.AreEqual(_products.SecondItemGuid, products.Items[0].Id);
            Assert.AreEqual("Apple iPhone 6S", products.Items[0].Name);

            Assert.AreEqual(_products.ThirdItemGuid, products.Items[1].Id);
            Assert.AreEqual("Apple iPhone 5s", products.Items[1].Name);
        }

        private IProductsSearchService CreateProductSearchService()
        {
            return new ProductsSearchService(new MockData.MockRepository());
        }
    }
}
