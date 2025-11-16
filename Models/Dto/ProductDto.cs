using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPIForTechGig.Models
{
    public class ProductDto
    {   
        public int Id { get; set; }
        public string ProductName { get; set; }
        [JsonPropertyName("Price")]
        public decimal Prize { get; set; }
        public string Category { get; set; }
        [JsonPropertyName("Description")]
        public string ProductDescription { get; set; }
    }
}
