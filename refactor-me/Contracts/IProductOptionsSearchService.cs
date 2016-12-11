using System;
using ProductsApi.Models;

namespace ProductsApi.Contracts
{
    public interface IProductOptionsSearchService
    {
        ProductOptions GetAllByProductId(Guid productId);
        ProductOption GetOptionByOptionId(Guid productOptionId);
        ProductOptions GetByName(string name);
    }
}