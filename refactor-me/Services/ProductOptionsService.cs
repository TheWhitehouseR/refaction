using ProductsApi.Contracts;
using System;
using ProductsApi.Models;
using ProductsApi.Attributes;

namespace ProductsApi.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductOptionsService : IProductOptionsService
    {
        private IRepository _repository;
        private IProductOptionsSearchService _searchService;

        public ProductOptionsService(IProductOptionsSearchService searchService, IRepository repository)
        {
            _searchService = searchService;
            _repository = repository;
        }

        public void CreateProductOption(Guid productId, ProductOption productOption)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentException("Product Options must have a related product");
            }

            if (productOption.Id != Guid.Empty)
            {
                throw new InvalidOperationException("Inserting products with ids is not supported");
            }

            productOption.Id = Guid.NewGuid();
            productOption.ProductId = productId;

            _repository.Insert(productOption);
            _repository.SaveChanges();
        }

        public void DeleteProductOption(Guid id)
        {
            _repository.Delete<ProductOption>(id);
            _repository.SaveChanges();
        }

        public ProductOptions GetOptionsByProductId(Guid productId)
        {
            return _searchService.GetAllByProductId(productId);
        }

        public ProductOption GetOptionByProductOptionId(Guid optionId)
        {
            return _searchService.GetOptionByOptionId(optionId);
        }

        public ProductOptions GetProductOptionsByName(string name)
        {
            return _searchService.GetByName(name);
        }

        public void UpdateProductOption(Guid id, ProductOption productOption)
        {
            if (id != productOption.Id)
            {
                throw new InvalidOperationException("Changing product guid is not supported");
            }

            _repository.Update(productOption);
            _repository.SaveChanges();
        }
    }
}