using System.ComponentModel.DataAnnotations;

namespace ProductsAPIForTechGig.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public string ProductDescription { get; set; }
        public decimal Prize { get; set; }
        [Required]
        public string Category { get; set; }
        
    }
}
