using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApi.Contracts
{
    public interface IProductsService
    {
        Products GetAllProducts();

        Products GetProductsByName(string name);

        Product GetProductById(Guid productGuid);
        void CreateProduct(Product product);
        void UpdateProduct(Guid id, Product product);
        void DeleteProduct(Guid id);
    }
}