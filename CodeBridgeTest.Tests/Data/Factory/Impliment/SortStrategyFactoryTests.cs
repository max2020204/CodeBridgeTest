using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Managment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeBridgeTest.Data.Factory.Impliment.Tests
{
    [TestClass()]
    public class SortStrategyFactoryTests
    {
        private SortStrategyFactory? _sortStrategyFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.As<IServiceProvider>().Setup(x => x.GetService(typeof(IEnumerable<ISortStrategy<Dog>>)))
                .Returns(new List<ISortStrategy<Dog>>
                {
                new DogTailLengthDescendingSortStrategy(),
                new DogTailLengthAscendingSortStrategy(),
                new DogWeightDescendingSortStrategy(),
                new DogWeightAscendingSortStrategy()
                });

            _sortStrategyFactory = new SortStrategyFactory(serviceProviderMock.Object);
        }

        [TestMethod()]
        public void Create_AttributeTailLenghtWithOrderDesc_ShouldReturnCorrectSortStrategy()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Desc;
            var result = _sortStrategyFactory.Create(attribute, order);
            Assert.IsInstanceOfType(result, typeof(DogTailLengthDescendingSortStrategy));
        }

        [TestMethod()]
        public void Create_AttributeTailLenghtWithOrderAcs_ShouldReturnCorrectSortStrategy()
        {
            string attribute = Attributes.TailLength;
            string order = Order.Asc;
            var result = _sortStrategyFactory.Create(attribute, order);
            Assert.IsInstanceOfType(result, typeof(DogTailLengthAscendingSortStrategy));
        }

        [TestMethod()]
        public void Create_AttributeWeightWithOrderAcs_ShouldReturnCorrectSortStrategy()
        {
            string attribute = Attributes.Weight;
            string order = Order.Asc;
            var result = _sortStrategyFactory.Create(attribute, order);
            Assert.IsInstanceOfType(result, typeof(DogWeightAscendingSortStrategy));
        }

        [TestMethod()]
        public void Create_AttributeWeightWithOrderDesc_ShouldReturnCorrectSortStrategy()
        {
            string attribute = Attributes.Weight;
            string order = Order.Desc;
            var result = _sortStrategyFactory.Create(attribute, order);

            Assert.IsInstanceOfType(result, typeof(DogWeightDescendingSortStrategy));
        }

        [TestMethod()]
        public void Create_WithInvalidAttributes_ShouldThrowArgumentException()
        {
            string attribute = "InvalidAttribute";
            string order = Order.Desc;
            Assert.ThrowsException<ArgumentException>(() => _sortStrategyFactory.Create(attribute, order));
        }
    }
}