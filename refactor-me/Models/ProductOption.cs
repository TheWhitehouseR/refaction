using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using ProductsApi.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class ProductOption : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public ProductOption()
        {
        }

        public ProductOption(Guid id)
        {
            Id = id;
        }
    }
}