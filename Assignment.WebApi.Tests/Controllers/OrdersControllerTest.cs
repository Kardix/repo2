using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.WebApi.Controllers;
using System.Web.Http;
using Assignment.Core.Model.DTO;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Assignment.WebApi.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTest
    {
        [Test]
        public void GetAllOrders()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
            IHttpActionResult result = controller.GetList();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllItems()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            IHttpActionResult result = controller.GetList();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetOrder()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
            IHttpActionResult result = controller.GetOrder(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetItem()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            IHttpActionResult result = controller.GetProduct(1);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
