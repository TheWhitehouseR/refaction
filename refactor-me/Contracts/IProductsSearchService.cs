using System;
using ProductsApi.Models;

namespace ProductsApi.Contracts
{
    public interface IProductsSearchService
    {
        Products GetAll();

        Product GetById(Guid productGuid);

        Products GetByName(string productName);
    }
}