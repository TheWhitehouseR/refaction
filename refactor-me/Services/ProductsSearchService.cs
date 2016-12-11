using ProductsApi.Contracts;
using System;
using ProductsApi.Models;
using ProductsApi.Attributes;
using ProductsApi.Data;
using System.Linq;

namespace ProductsApi.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductsSearchService : IProductsSearchService
    {
        private IRepository _repository;

        public ProductsSearchService(IRepository repository)
        {
            _repository = repository;
        }

        public Products GetAll()
        {
            return new Products(_repository.Query<Product>().ToList());
        }

        public Product GetById(Guid productGuid)
        {
            return _repository.Query<Product>().FirstOrDefault(x => x.Id == productGuid);
        }

        public Products GetByName(string productName)
        {
            return new Products(_repository.Query<Product>().Where(x => x.Name.Contains(productName)).ToList());
        }
    }
}