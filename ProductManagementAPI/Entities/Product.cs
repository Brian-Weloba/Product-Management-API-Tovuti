using System;
using System.Collections.Generic;

namespace ProductManagementAPI.Entities
{
    public record Product
    {

        private Random random = new Random();
        public string Vendor { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int quantity { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public string SKU { get; init; }
        public Dictionary<string, string> attributes { get; init; }

        public Product(string vendor, string name, decimal price, int quantity, DateTimeOffset createdDate, Dictionary<string, string> attributes)
        {
            Vendor = vendor;
            Name = name;
            Price = price;
            this.quantity = quantity;
            CreatedDate = createdDate;
            SKU = vendor.Substring(0, 3) + name.Substring(0, 3) + random.Next(99);
            this.attributes = attributes;
        }
        public Product(string vendor, string name, decimal price, int quantity, DateTimeOffset createdDate)
        {
            Vendor = vendor;
            Name = name;
            Price = price;
            this.quantity = quantity;
            CreatedDate = createdDate;
            SKU = vendor.Substring(0, 3) + name.Substring(0, 3) + random.Next(99);
            this.attributes = null;
        }

    }
}