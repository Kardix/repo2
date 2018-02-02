using Assignment.Core.Model;
using Assignment.Core.Model.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers
{
    public static class OrderProcessor
    {
        private static AssignmentEntities context = new AssignmentEntities();

        public static void ProcessOrder(long orderID)
        {
            var order = context.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order == null)
                return;

            foreach (var orderItem in order.OrderItems)
            {
                var productInDB = context.Products.FirstOrDefault(p => p.ProductID == orderItem.Product.ProductID);
                if (productInDB == null)
                    return;

                var state = productInDB.Remainder >= orderItem.Count ? State.Processed : State.NotInStock;
                if (state == State.Processed)
                {
                    productInDB.Remainder -= orderItem.Count;
                }
                else
                {
                    var priority = GetPriorityForReservation(order, productInDB);
                    context.ProductReservations.Add(new ProductReservation
                    {
                        Count = orderItem.Count,
                        DateOfReservation = DateTime.Now,
                        ProductID = productInDB.ProductID,
                        Priority = priority
                    });
                }
            }

            context.SaveChanges();
        }

        // There should be some logic here in terms of priority if needed
        private static int GetPriorityForReservation(Model.Order order, Model.Product product)
        {
            return 1;
        }
        
    }
}
