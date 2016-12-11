using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ProductsApi.Models
{
    public class Products
    {
        public IList<Product> Items { get; private set; }

        public Products(IList<Product> items)
        {
            Items = items;
        }

        public Products(Product product)
        {
            Items = new List<Product>() { product };
        }
    }
}