using refactor_me.Interfaces;
using System;
using refactor_me.Models;
using refactor_me.Attributes;

namespace refactor_me.Services
{
    [Component(RegisterAsImplementedInterface = true)]
    public class ProductsService : IProductsService
    {
        public Products GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(Guid productGuid)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}