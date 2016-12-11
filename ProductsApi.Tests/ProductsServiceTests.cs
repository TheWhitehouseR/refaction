using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApi.Contracts;
using ProductsApi.Services;
using Moq;
using ProductsApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProductsApi.Tests.MockData;

namespace ProductsApi.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        private MocksProducts _products;

        public ProductsServiceTests()
        {
            _products = new MocksProducts();
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var sut = CreateProductService();

            var products = sut.GetAllProducts();

            Assert.AreEqual(3, products.Items.Count);
            Assert.AreEqual(_products.FirstItemGuid, products.Items[0].Id);
            Assert.AreEqual(_products.SecondItemGuid, products.Items[1].Id);
            Assert.AreEqual(_products.ThirdItemGuid, products.Items[2].Id);
        }

        [TestMethod]
        public void GetProductById_CorrectGuid_ReturnsCorrectProduct()
        {
            var sut = CreateProductService();

            var product = sut.GetProductById(_products.FirstItemGuid);

            Assert.AreEqual(_products.FirstItemGuid, product.Id);
            Assert.AreEqual("Samsung Galaxy S7", product.Name);

            product = sut.GetProductById(_products.SecondItemGuid);

            Assert.AreEqual(_products.SecondItemGuid, product.Id);
            Assert.AreEqual("Apple iPhone 6S", product.Name);

            product = sut.GetProductById(_products.ThirdItemGuid);

            Assert.AreEqual(_products.ThirdItemGuid, product.Id);
            Assert.AreEqual("Apple iPhone 5s", product.Name);
        }

        [TestMethod]
        public void GetProductById_IncorrectGuid_ReturnsNullProduct()
        {
            var sut = CreateProductService();

            var product = sut.GetProductById(Guid.NewGuid());

            Assert.AreEqual(null, product);
        }

        [TestMethod]
        public void GetProductsByName_CorrectName_ReturnsCorrectProduct()
        {
            var sut = CreateProductService();

            var products = sut.GetProductsByName("Samsung");

            Assert.AreEqual(1, products.Items.Count);
            Assert.AreEqual(_products.FirstItemGuid, products.Items[0].Id);
            Assert.AreEqual("Samsung Galaxy S7", products.Items[0].Name);

            products = sut.GetProductsByName("Apple");

            Assert.AreEqual(2, products.Items.Count);
            Assert.AreEqual(_products.SecondItemGuid, products.Items[0].Id);
            Assert.AreEqual("Apple iPhone 6S", products.Items[0].Name);

            Assert.AreEqual(_products.ThirdItemGuid, products.Items[1].Id);
            Assert.AreEqual("Apple iPhone 5s", products.Items[1].Name);
        }

        private IProductsService CreateProductService()
        {
            var mockSearchService = new Mock<IProductsSearchService>();

            mockSearchService.Setup(x => x.GetAll()).Returns(new Products(_products.Items));
            mockSearchService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns((Product)null);
            mockSearchService.Setup(x => x.GetById(_products.FirstItemGuid)).Returns(_products.Items.FirstOrDefault(x => x.Id == _products.FirstItemGuid));
            mockSearchService.Setup(x => x.GetById(_products.SecondItemGuid)).Returns(_products.Items.FirstOrDefault(x => x.Id == _products.SecondItemGuid));
            mockSearchService.Setup(x => x.GetById(_products.ThirdItemGuid)).Returns(_products.Items.FirstOrDefault(x => x.Id == _products.ThirdItemGuid));

            mockSearchService.Setup(x => x.GetByName(It.IsAny<string>())).Returns(new Products((Product)null));
            mockSearchService.Setup(x => x.GetByName(_products.Items[0].Name)).Returns(new Products(_products.Items[0]));
            mockSearchService.Setup(x => x.GetByName(_products.Items[1].Name)).Returns(new Products(_products.Items[1]));
            mockSearchService.Setup(x => x.GetByName(_products.Items[2].Name)).Returns(new Products(_products.Items[2]));

            mockSearchService.Setup(x => x.GetByName("Samsung")).Returns(new Products(_products.Items[0]));
            mockSearchService.Setup(x => x.GetByName("Apple")).Returns(new Products(new List<Product>() { _products.Items[1], _products.Items[2] }));

            return new ProductsService(mockSearchService.Object, new MockData.MockRepository());
        }
    }
}
