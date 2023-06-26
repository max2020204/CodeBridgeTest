using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Tests.Data.Factory.Impliment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeBridgeTest.Data.Factory.Impliment.Tests
{
    [TestClass()]
    public class DogWeightDescendingSortStrategyTests : SortStrategyTest<float>
    {
        protected override ISortStrategy<Dog> SortStrategy => new DogWeightDescendingSortStrategy();

        protected override Func<Dog, float> SortProperty => dog => dog.Weight;

        [TestMethod()]
        public void SortTest()
        {
            var expected = Dogs.OrderByDescending(SortProperty);
            var result = SortStrategy.Sort(Dogs);
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}