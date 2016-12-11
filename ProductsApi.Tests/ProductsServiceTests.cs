using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApi.Contracts;
using ProductsApi.Services;
using Moq;
using ProductsApi.Models;
using System.Collections.Generic;

namespace ProductsApi.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        private IList<Product> _sampleProducts = new List<Product>()
        {
            new Product(new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"))
            {
                Name = "Samsung Galaxy S7",
                Description = "Newest mobile product from Samsung.",
                Price = 1024.99M,
                DeliveryPrice = 16.99M
            },

            new Product(new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"))
            {
                Name = "Apple iPhone 6S",
                Description = "Newest mobile product from Apple.",
                Price = 1299.99M,
                DeliveryPrice = 15.99M
            },
        };

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var sut = CreateProductService();

            var products = sut.GetAllProducts();

            Assert.AreEqual(2, products.Items.Count);
            Assert.AreEqual(new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"), products.Items[0].Id);
            Assert.AreEqual(new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"), products.Items[1].Id);
        }

        private IProductsService CreateProductService()
        {
            var mockSearchService = new Mock<IProductsSearchService>();

            mockSearchService.Setup(x => x.GetAll()).Returns(new Products(_sampleProducts));

            return new ProductsService(mockSearchService.Object);
        }
    }
}
