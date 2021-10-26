using System;
using System.Collections.Generic;

namespace ProductManagementAPI.Entities
{
    public record Product
    {

        private Random random = new Random();
        public string Vendor { get; init; }
        public string Name { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public Guid SKU { get; init; }
        public Dictionary<string, string> Attributes { get; init; }

        public Product(string vendor, string name, string brand, decimal price, int quantity, DateTimeOffset createdDate, Dictionary<string, string> attributes)
        {
            Vendor = vendor;
            Name = name;
            Brand = brand;
            Price = price;
            Quantity = quantity;
            CreatedDate = createdDate;
            SKU = Guid.NewGuid();
            Attributes = attributes;
        }

        public Product(string vendor, string name, decimal price, int quantity, DateTimeOffset createdDate)
        {
            Vendor = vendor;
            Name = name;
            Price = price;
            Quantity = quantity;
            CreatedDate = createdDate;
            SKU = Guid.NewGuid();
            Attributes = null;
        }

        public Product() {
            SKU = Guid.NewGuid();
         }


    }
}