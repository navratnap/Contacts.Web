using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contacts.Web;
using Contacts.Web.Controllers;
using Contacts.BusinessAccess.Repository;
using Microsoft.Practices.Unity;
using Moq;
using Contacts.BusinessAccess.Services;
using Contacts.BusinessAccess.Model;
using Contacts.Web.Models;

namespace Contacts.Web.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
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
        public void ContactWithEmptyList()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.GetAllContacts()).Returns(() => new List<ContactModel>());
            
            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, "Contact");
            Assert.IsInstanceOfType(result.Model, typeof(List<ContactsViewModel>));
            Assert.AreEqual(((List<ContactsViewModel>)result.Model).Count, 0);
        }

        [TestMethod]
        public void ContactWithList()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.GetAllContacts()).Returns(() => new List<ContactModel>()
            {
                new ContactModel() {
                    ContactId = 1,
                    FirstName = "TestFirst",
                    LastName = "TestLast",
                    EmailID = "Test@test.com",
                    PhoneNumber = "9000000000",
                    Status = true }
            });

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual(((List<ContactsViewModel>)result.Model).Count, 1);
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].ContactId, 1);
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].FirstName, "TestFirst");
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].LastName, "TestLast");
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].EmailID, "Test@test.com");
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].PhoneNumber, "9000000000");
            Assert.AreEqual(((List<ContactsViewModel>)result.Model)[0].Status, true);
        }

        [TestMethod]
        public void AddContactGet()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.AddContact(new ContactModel())).Returns(() => 1);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.AddContact() as ViewResult;

            // Assert
            Assert.AreEqual("AddContact", result.ViewName);
        }

        [TestMethod]
        public void AddContactPostReturnsError()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.AddContact(new ContactModel())).Returns(() => 0);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.AddContact(new ContactsViewModel()) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void UpdateContactGet()
        {
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.UpdateContact(new ContactModel())).Returns(() => 1);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.UpdateContact(Common.Encryption.Encrypt("1")) as ViewResult;

            // Assert
            Assert.AreEqual("UpdateContact", result.ViewName);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void UpdateContactPostReturnsError()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.AddContact(new ContactModel())).Returns(() => 0);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.AddContact(new ContactsViewModel()) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void DeleteContactGet()
        {
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.DeleteContact(1)).Returns(() => 1);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.DeleteContact(Common.Encryption.Encrypt("1")) as ViewResult;

            // Assert
            Assert.AreEqual("DeleteContact", result.ViewName);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void DeleteContactPostReturnsError()
        {
            // Arrange
            Mock<IContact> mockRepository = new Mock<IContact>();
            mockRepository.Setup(s => s.DeleteContact(1)).Returns(() => 0);

            ContactController controller = new ContactController(mockRepository.Object);

            // Act
            ViewResult result = controller.DeleteContact(1) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
            Assert.IsNull(result.Model);
        }
    }
}
