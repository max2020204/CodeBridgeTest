using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Managment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeBridgeTest.Services.Impliment.Tests
{
    [TestClass()]
    public class DogServicesTests
    {
        private Mock<IDogRepository>? _dogRepository;
        private List<Dog>? _dogs;
        private DogServices? _services;

        [TestInitialize]
        public void TestInitialize()
        {
            _dogRepository = new Mock<IDogRepository>();
            _services = new DogServices(_dogRepository.Object);
            _dogs = _dogs = new List<Dog>()
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
            _dogRepository.Setup(x => x.GetAll()).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(null, null, null, null);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_And_PageSize()
        {
            int pageNumber = 2;
            int pageSize = 2;
            _dogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(pageNumber, pageSize, null, null);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_TailLength_And_Order_Acs()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.TailLength;
            string order = Order.Asc;
            _dogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_TailLength_And_Order_Desc()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.TailLength;
            string order = Order.Desc;
            _dogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_Weight_And_Order_Acs()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.Weight;
            string order = Order.Asc;
            _dogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_PageNumber_PageSize_Attributes_Weight_And_Order_Desc()
        {
            int pageNumber = 2;
            int pageSize = 2;
            string attribute = Attributes.Weight;
            string order = Order.Desc;
            _dogRepository.Setup(x => x.GetDogPeganation(pageNumber, pageSize, attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(pageNumber, pageSize, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_TailLength_And_Order_Acs()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Asc;
            _dogRepository.Setup(x => x.SortDog(attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_TailLength_And_Order_Desc()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Desc;
            _dogRepository.Setup(x => x.SortDog(attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_Weight_And_Order_Acs()
        {
            string attribute = Attributes.Weight;
            string order = Order.Asc;
            _dogRepository.Setup(x => x.SortDog(attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }

        [TestMethod()]
        public void Dogs_Should_Return_Peginated_Dogs_With_Parametrs_Attributes_Weight_And_Order_Desc()
        {
            string attribute = Attributes.Weight;
            string order = Order.Desc;
            _dogRepository.Setup(x => x.SortDog(attribute, order)).Returns(_dogs.AsQueryable());

            var result = _services.GetDogs(null, null, attribute, order);

            Assert.IsTrue(_dogs.SequenceEqual(result));
        }
    }
}