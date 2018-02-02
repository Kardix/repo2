using System.Collections.Generic;

namespace Assignment.Core.Model.DTO
{
    public class Order
    {
        public long OrderID { get; set; }

        public string DeliveryAdress { get; set; }

        public string Email { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
