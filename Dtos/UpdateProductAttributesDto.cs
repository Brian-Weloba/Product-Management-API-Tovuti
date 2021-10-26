using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Dtos
{
    public class UpdateProductAttributesDto
    {
        public Dictionary<string, List<string>> Attributes { get; init; }
    }
}