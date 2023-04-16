namespace Pikia.APIs.DTOs
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }

        public int ProductTypeId { get; set; } 
        public string ProductType { get; set; } 
    }
}
