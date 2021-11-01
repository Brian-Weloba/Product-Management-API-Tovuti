using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ProductManagementAPI.Entities
{
    //Attributes for a product with variants
    public record ProductAttributes
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductSKU { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        //[XmlIgnore]
        //public string Attributes { get; set; }
        //[NotMapped]
        public string AttributeValue { get; set; }
        //public List<string> AttributeValues
        //{
        //    get { return Attributes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t).ToList(); }
        //    set { Attributes = string.Join(",", value); }
        //}
        public ProductAttributes()
        {
            Id = Guid.NewGuid();
        }

        public static implicit operator List<object>(ProductAttributes v)
        {
            throw new NotImplementedException();
        }
    }
}