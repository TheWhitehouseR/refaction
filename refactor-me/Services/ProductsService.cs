using ProductsApi.Contracts;
using System;
using ProductsApi.Models;
using ProductsApi.Attributes;

namespace ProductsApi.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductsService : IProductsService
    {
        private IProductsSearchService _searchService;

        public ProductsService(IProductsSearchService searchService)
        {
            _searchService = searchService;
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Products GetAllProducts()
        {
            return _searchService.GetAll();
        }

        public Product GetProductById(Guid productGuid)
        {
            throw new NotImplementedException();
        }

        public Products GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}