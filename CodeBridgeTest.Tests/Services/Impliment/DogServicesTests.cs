using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Services.Impliment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Managment;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Services.Interfaces;

namespace CodeBridgeTest.Services.Impliment.Tests
{
    [TestClass()]
    public class DogServicesTests
    {
        Mock<IDogRepository> DogRepository;
        List<Dog> Dogs;
        DogServices services;

        [TestInitialize]
        public void TestInitialize()
        {
            DogRepository = new Mock<IDogRepository>();
            services = new DogServices(DogRepository.Object);
            Dogs = Dogs = new List<Dog>()
            {
                 new Dog
                {
                    Id = 1,
                    Name = "Neo",
                    Color = "red & amber",
                    TailLength = 22f,
                    Weight = 32f
                },
                new Dog
                {
                    Id = 2,
                    Name = "Jessy",
                    Color = "black & white",
                    TailLength = 7f,
                    Weight = 14
                },
                new Dog
                {
                    Id = 2,
                    Name = "Bimbo",
                    Color = "black",
                    TailLength = 14f,
                    Weight = 18
                }
            };
        }

        [TestMethod()]
        public void Dogs_Should_Return_Expected_List_From_Service()
        {
            DogRepository.Setup(x => x.GetAll()).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(null, null, null, null);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_And_PageSize()
        {
            int pageNumber = 2;
            int pageSize = 2;
            DogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(pageNumber, pageSize, null, null);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_TailLength_And_Order_Acs()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.TailLength;
            string order = Order.Asc;
            DogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_TailLength_And_Order_Desc()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.TailLength;
            string order = Order.Desc;
            DogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_Weight_And_Order_Acs()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.Weight;
            string order = Order.Asc;
            DogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_Weight_And_Order_Desc()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.Weight;
            string order = Order.Desc;
            DogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_TailLength_And_Order_Acs()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Asc;
            DogRepository.Setup(x => x.SortDog(attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_TailLength_And_Order_Desc()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Desc;
            DogRepository.Setup(x => x.SortDog(attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_Weight_And_Order_Acs()
        {
            string attribute = Attributes.Weight;
            string order = Order.Asc;
            DogRepository.Setup(x => x.SortDog(attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_Weight_And_Order_Desc()
        {
            string attribute = Attributes.Weight;
            string order = Order.Desc;
            DogRepository.Setup(x => x.SortDog(attribute, order)).Returns(Dogs.AsQueryable());

            var result = services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(Dogs.SequenceEqual(result));
        }

    }
}