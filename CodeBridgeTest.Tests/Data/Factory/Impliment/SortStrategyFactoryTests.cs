using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Data.Factory.Impliment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using Microsoft.Extensions.DependencyInjection;
using CodeBridgeTest.Services.Managment;

namespace CodeBridgeTest.Data.Factory.Impliment.Tests
{
    [TestClass()]
    public class SortStrategyFactoryTests
    {
        private SortStrategyFactory sortStrategyFactory;

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

            sortStrategyFactory = new SortStrategyFactory(serviceProviderMock.Object);
        }

        [TestMethod()]
        public void Create_AttributeTailLenghtWithOrderDesc_ShouldReturnCorrectSortStrategy()
        {
            // Arrange
            string attribute = Attributes.TailLength;
            string order = Order.Desc;

            // Act
            var result = sortStrategyFactory.Create(attribute, order);

            // Assert
            Assert.IsInstanceOfType(result, typeof(DogTailLengthDescendingSortStrategy));
        }
        [TestMethod()]
        public void Create_AttributeTailLenghtWithOrderAcs_ShouldReturnCorrectSortStrategy()
        {
            // Arrange
            string attribute = Attributes.TailLength;
            string order = Order.Asc;

            // Act
            var result = sortStrategyFactory.Create(attribute, order);

            // Assert
            Assert.IsInstanceOfType(result, typeof(DogTailLengthAscendingSortStrategy));
        }
        [TestMethod()]
        public void Create_AttributeWeightWithOrderAcs_ShouldReturnCorrectSortStrategy()
        {
            // Arrange
            string attribute = Attributes.Weight;
            string order = Order.Asc;

            // Act
            var result = sortStrategyFactory.Create(attribute, order);

            // Assert
            Assert.IsInstanceOfType(result, typeof(DogWeightAscendingSortStrategy));
        }
        [TestMethod()]
        public void Create_AttributeWeightWithOrderDesc_ShouldReturnCorrectSortStrategy()
        {
            // Arrange
            string attribute = Attributes.Weight;
            string order = Order.Desc;

            // Act
            var result = sortStrategyFactory.Create(attribute, order);

            // Assert
            Assert.IsInstanceOfType(result, typeof(DogWeightDescendingSortStrategy));
        }
        [TestMethod()]
        public void Create_WithInvalidAttributes_ShouldThrowArgumentException()
        {
            // Arrange
            string attribute = "InvalidAttribute";
            string order = Order.Desc;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sortStrategyFactory.Create(attribute, order));
        }
    }
}