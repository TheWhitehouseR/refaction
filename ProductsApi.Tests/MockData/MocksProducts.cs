using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Tests.MockData
{
    public class MocksProducts : Products
    {
        private static Guid _firstItemGuid = new Guid("ADC863A1-720C-4F67-80AA-ADBF7763AD2E");
        private static Guid _secondItemGuid = new Guid("7658E50C-FAC0-4065-A727-48B01A686050");
        private static Guid _thirdItemGuid = new Guid("83504285-CA33-4BF9-A30E-0B59215730D7");

        public Guid FirstItemGuid { get; set; }
        public Guid SecondItemGuid { get; set; }
        public Guid ThirdItemGuid { get; set; }

        public MocksProducts(): base(new List<Product>()
            {
                new Product(_firstItemGuid)
                {
                    Name = "Samsung Galaxy S7",
                    Description = "Newest mobile product from Samsung.",
                    Price = 1024.99M,
                    DeliveryPrice = 16.99M
                },

                new Product(_secondItemGuid)
                {
                    Name = "Apple iPhone 6S",
                    Description = "Newest mobile product from Apple.",
                    Price = 1299.99M,
                    DeliveryPrice = 15.99M
                },

                new Product(_thirdItemGuid)
                {
                    Name = "Apple iPhone 5s",
                    Description = "Older, but still great!",
                    Price = 500M,
                    DeliveryPrice = 15.99M
                },
            })
        {
            FirstItemGuid = _firstItemGuid;
            SecondItemGuid = _secondItemGuid;
            ThirdItemGuid = _thirdItemGuid;
        }
    }
}
