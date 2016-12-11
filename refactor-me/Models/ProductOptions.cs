using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ProductsApi.Models
{
    public class ProductOptions
    {
        public IList<ProductOption> Items { get; private set; }

        public ProductOptions()
        {
            
        }

        public ProductOptions(IList<ProductOption> items)
        {
            Items = items;
        }
    }
}