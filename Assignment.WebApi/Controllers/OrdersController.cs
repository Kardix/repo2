using Assignment.Core;
using Assignment.Core.Model;
using Assignment.Core.Model.DTO;
using Assignment.Core.Model.DTO.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Assignment.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        AssignmentEntities context = new AssignmentEntities();

        [HttpGet]
        [Route("api/orders/list")]
        public IHttpActionResult GetList()
        {
            return Json(context.Orders.ToList().Select(o => o.ConvertToDTO()).ToList());
        }

        [HttpGet]
        [Route("api/orders/order")]
        public IHttpActionResult GetOrder(long id)
        {
            var order = context.Orders.FirstOrDefault(o => o.OrderID == id);

            // perhaps return NotFound() if order == null ? not sure how this scenario is typically handled in webApi.
            return Json(order?.ConvertToDTO());
        }


        [HttpPost]
        [Route("api/orders/create")]
        public IHttpActionResult CreateOrder([FromBody]Core.Model.DTO.Order newOrder)
        {
            var order = new Core.Model.Order
            {
                DeliveryAddress = newOrder.DeliveryAdress,
                Email = newOrder.Email,
                OrderItems = new List<Core.Model.OrderItem>()
            };

            foreach (var orderItem in newOrder.OrderItems)
            {
                var productInDB = context.Products.FirstOrDefault(p => p.ProductID == orderItem.Product.ProductID);
                if (productInDB == null)
                    return BadRequest();

                order.OrderItems.Add(new Core.Model.OrderItem
                {
                    Product = productInDB,
                    Count = orderItem.Count,
                    State = (int)State.Created
                });
            }

            context.Orders.Add(order);
            context.SaveChanges();

            return Json(order.OrderID);
        }
    }
}
