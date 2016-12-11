using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Interfaces
{
    public interface IProductsService
    {
        Products GetAllProducts();

        Product GetProductByName(string name);

        Product GetProductByName(Guid productGuid);
    }
}