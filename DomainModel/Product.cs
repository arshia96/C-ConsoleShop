using System;

namespace DomainModel
{
    public class Product
    {
        public Product(int productId, Device device, Amount price)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Device = device;
            Price = price;
        }
        public Device Device { get; set; }
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public Amount Price { get; set; }
    }
}