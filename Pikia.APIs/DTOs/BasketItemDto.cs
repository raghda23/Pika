using System.ComponentModel.DataAnnotations;

namespace Pikia.APIs.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int Price { get; set; }
        [Required]
        [Range(1 , int.MaxValue , ErrorMessage = "Quentity must be 1 at least")]
        public int Quantity { get; set; }
        [Required]
        public string Type { get; set; }
    }
}