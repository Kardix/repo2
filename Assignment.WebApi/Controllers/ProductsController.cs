using Assignment.Core.Model;
using Assignment.Core.Model.DTO.Helpers;
using System.Linq;
using System.Web.Http;

namespace Assignment.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        AssignmentEntities context = new AssignmentEntities();

        [HttpGet]
        [Route("api/products/list")]
        public IHttpActionResult GetList()
        {
            return Json(context.Products.ToList().Select(o => o.ConvertToDTO()).ToList());
        }

        [HttpGet]
        [Route("api/products/product")]
        public IHttpActionResult GetProduct(long id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);
            
            // perhaps return NotFound() if product == null ? not sure how this scenario is typically handled in webApi.
            return Json(product?.ConvertToDTO());
        }

        [HttpPost]
        [Route("api/products/create")]
        public IHttpActionResult CreateProduct([FromBody]Core.Model.DTO.Product newProduct)
        {
            var product = new Core.Model.Product
            {
                ProductName = newProduct.ProductName,
                Remainder = newProduct.Remainder
            };

            context.Products.Add(product);
            context.SaveChanges();

            return Json(product.ProductID);
        }

        [HttpPost]
        [Route("api/products/updateCount")]
        public IHttpActionResult UpdateProductRemainder(long productID, int remainder)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product == null)
            {
                return BadRequest();
            }

            product.Remainder = remainder;
            context.SaveChanges();

            return Json(product.ConvertToDTO());
        }
    }
}
