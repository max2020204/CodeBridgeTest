using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CodeBridgeTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Controllers.Tests
{
    [TestClass()]
    public class DogInfoControllerTests
    {
        private Mock<IDogRepository> mockDogRepository;
        private DogInfoController controller;
        [TestInitialize]
        public void TestInitialize()
        {
            mockDogRepository = new Mock<IDogRepository>();
            controller = new DogInfoController(mockDogRepository.Object, new Mock<IDogsServices>().Object);

        }

        [TestMethod()]
        public void Ping_Should_Return_Service_Version()
        {
            var result = controller.Ping() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Dogs house service. Version 1.0.1", result.Value);
        }

        [TestMethod()]
        public void NewDog_Should_Return_Ok_If_Dog_Saved_Successfully()
        {
            var newDog = new Dog
            {
                Name = "Doggy",
                Color = "Red",
                TailLength = 173f,
                Weight = 33
            };

            mockDogRepository.Setup(r => r.Save(newDog)).Verifiable();

            var result = controller.NewDog(newDog) as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            mockDogRepository.Verify();
        }

        [TestMethod()]
        public void NewDog_Should_Return_BadRequest_If_DbUpdateException_Is_Thrown()
        {
            var newDog = new Dog
            {
                Id = 1,
                Name = "Neo",
                Color = "red & amber",
                TailLength = 22f,
                Weight = 32f
            };

            mockDogRepository.Setup(r => r.Save(newDog)).Throws(new DbUpdateException("Test Exception Message"));

            var result = controller.NewDog(newDog) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("This name already in database. Test Exception Message", result.Value);
        }
    }
}
