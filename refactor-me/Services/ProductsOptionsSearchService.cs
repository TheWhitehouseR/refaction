using ProductsApi.Contracts;
using System;
using ProductsApi.Models;
using ProductsApi.Attributes;
using ProductsApi.Data;
using System.Linq;

namespace ProductsApi.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductOptionsSearchService : IProductOptionsSearchService
    {
        private IRepository _repository;

        public ProductOptionsSearchService(IRepository repository)
        {
            _repository = repository;
        }

        public ProductOptions GetAllByProductId(Guid productId)
        {
            return new ProductOptions(_repository.Query<Product>().FirstOrDefault(x => x.Id == productId)?.ProductOptions?.ToList());
        }

        public ProductOptions GetByName(string name)
        {
            return new ProductOptions(_repository.Query<ProductOption>().Where(x => x.Name.Contains(name)).ToList());
        }

        public ProductOption GetOptionByOptionId(Guid productOptionId)
        {
            return _repository.Query<ProductOption>().FirstOrDefault(x => x.Id == productOptionId);
        }
    }
}