using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeBridgeTest.Controllers.Tests
{
    [TestClass()]
    public class DogInfoControllerTests
    {
        private Mock<IDogRepository>? _mockDogRepository;
        private DogInfoController? _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDogRepository = new Mock<IDogRepository>();
            _controller = new DogInfoController(_mockDogRepository.Object, new Mock<IDogsServices>().Object);
        }

        [TestMethod()]
        public void Ping_Should_Return_Service_Version()
        {
            var result = _controller.Ping() as OkObjectResult;

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

            _mockDogRepository.Setup(r => r.Save(newDog)).Verifiable();

            var result = _controller.NewDog(newDog) as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _mockDogRepository.Verify();
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

            _mockDogRepository.Setup(r => r.Save(newDog)).Throws(new DbUpdateException("Test Exception Message"));

            var result = _controller.NewDog(newDog) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("This name already in database. Test Exception Message", result.Value);
        }
    }
}