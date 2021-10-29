using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ProductManagementAPI.Dtos
{
    public record CreateAttributeDto
    {
        public string Name { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public string Attributes { get; set; }
        public List<string> AttributeValues
        {
            get { return Attributes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t).ToList(); }
            set { Attributes = string.Join(",", value); }
        }
    }
}