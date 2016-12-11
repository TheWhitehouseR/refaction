using System;
using System.Net;
using System.Web.Http;
using ProductsApi.Models;
using ProductsApi.Contracts;

namespace ProductsApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [Route]
        [HttpGet]
        public Products GetAll()
        {
            return _productsService.GetAllProducts();
        }

        [Route]
        [HttpGet]
        public Products SearchByName(string name)
        {
            return _productsService.GetProductsByName(name);
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            return _productsService.GetProductById(id);
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            _productsService.CreateProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            _productsService.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _productsService.DeleteProduct(id);
        }
    }
}
