using System;
using ProductsApi.Models;

namespace ProductsApi.Contracts
{
    public interface IProductOptionsService
    {
        ProductOptions GetOptionsByProductId(Guid productId);

        ProductOption GetOptionByProductOptionId(Guid optionId);

        void CreateProductOption(Guid productId, ProductOption option);

        void UpdateProductOption(Guid optionId, ProductOption option);

        void DeleteProductOption(Guid optionId);
    }
}