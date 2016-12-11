using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using ProductsApi.Contracts;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }

        public Product()
        {
            
        }

        public Product(Guid id)
        {
            Id = id;
        }
    }
}