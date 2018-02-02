using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.WebApi.Controllers;
using System.Web.Http;

namespace Assignment.WebApi.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
            IHttpActionResult result = controller.GetList();


            // Assert
            Assert.IsNotNull(result);
        }
    }
}
