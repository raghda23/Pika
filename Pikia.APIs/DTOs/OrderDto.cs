namespace Pikia.APIs.DTOs
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }
}
