using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Tests.Data.Factory.Impliment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeBridgeTest.Data.Factory.Impliment.Tests
{
    [TestClass()]
    public class DogTailLengthDescendingSortStrategyTests : SortStrategyTest<float>
    {
        protected override ISortStrategy<Dog> SortStrategy => new DogTailLengthDescendingSortStrategy();
        protected override Func<Dog, float> SortProperty => dog => dog.TailLength;

        [TestMethod()]
        public void Sort_ShouldSortDogsInDescendingOrder()
        {
            var expected = Dogs.OrderByDescending(SortProperty);
            var result = SortStrategy.Sort(Dogs);
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}