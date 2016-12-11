using System;
using ProductsApi.Models;

namespace ProductsApi.Contracts
{
    public interface IProductOptionsService
    {
        ProductOptions GetOptionsByProductId(Guid productId);

        ProductOption GetOptionByProductOptionId(Guid productId, Guid id);

        void CreateOption(Guid productId, ProductOption option);

        void UpdateOption(Guid optionId, ProductOption option);

        void DeleteOption(Guid optionId);
    }
}