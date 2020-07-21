using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contacts.Web;
using Contacts.Web.Controllers;
using Contacts.BusinessAccess.Repository;
using Moq;

namespace Contacts.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            HomeController controller = new HomeController(mockRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            HomeController controller = new HomeController(mockRepository.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Contact description page.", result.ViewBag.Message);
        }
    }
}
