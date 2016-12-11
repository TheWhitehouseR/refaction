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

        /*
        private void LoadProductOptions(string where)
        {
            Items = new List<ProductOption>();
            var conn = Helpers.NewConnection();
            var cmd = new SqlCommand($"select id from productoption {where}", conn);
            conn.Open();

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr["id"].ToString());
                Items.Add(new ProductOption(id));
            }
        }*/
    }
}