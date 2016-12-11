using ProductsApi.Contracts;
using System;
using ProductsApi.Models;
using ProductsApi.Attributes;

namespace ProductsApi.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductsService : IProductsService
    {
        private IRepository _repository;
        private IProductsSearchService _searchService;

        public ProductsService(IProductsSearchService searchService, IRepository repository)
        {
            _searchService = searchService;
            _repository = repository;
        }

        public void CreateProduct(Product product)
        {
            if (product.Id != Guid.Empty)
            {
                throw new InvalidOperationException("Inserting products with ids is not supported");
            }

            product.Id = Guid.NewGuid();

            _repository.Insert(product);
            _repository.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            _repository.Delete<Product>(id);
            _repository.SaveChanges();
        }

        public Products GetAllProducts()
        {
            return _searchService.GetAll();
        }

        public Product GetProductById(string productGuid)
        {
            Guid productId;
            if (!Guid.TryParse(productGuid, out productId))
            {
                throw new ArgumentException("productGuid must be a guid");
            }

            return GetProductById(productId);
        }

        public Product GetProductById(Guid productGuid)
        {
            return _searchService.GetById(productGuid);
        }

        public Products GetProductsByName(string name)
        {
            return _searchService.GetByName(name);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                throw new InvalidOperationException("Changing product guid is not supported");
            }

            _repository.Update(product);
            _repository.SaveChanges();
        }
    }
}