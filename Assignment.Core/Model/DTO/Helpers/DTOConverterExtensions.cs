using System.Linq;

namespace Assignment.Core.Model.DTO.Helpers
{
    public static class DTOConverterExtensions
    {
        public static Product ConvertToDTO(this Model.Product product)
        {
            return new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName
            };
        }

        public static OrderItem ConvertToDTO(this Model.OrderItem orderItem)
        {
            return new OrderItem
            {
                Count = orderItem.Count,
                State = (State)orderItem.State,
                Product = orderItem.Product.ConvertToDTO()
            };
        }

        public static Order ConvertToDTO(this Model.Order order)
        {
            return new Order
            {
                DeliveryAdress = order.DeliveryAddress,
                Email = order.Email,
                OrderID = order.OrderID,
                OrderItems = order.OrderItems.Select(oi => oi.ConvertToDTO()).ToList()
            };
        }
    }
}
