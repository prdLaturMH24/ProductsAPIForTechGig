using System.Text.Json.Serialization;

namespace ProductsAPIForTechGig.Models.Dal
{
    public class ProductDal
    {
        public string ProductName { get; set; }
        [JsonPropertyName("Price")]
        public decimal Prize { get; set; }
        public string Category { get; set; }
        [JsonPropertyName("Description")]
        public string ProductDescription { get; set; }
    }
}
