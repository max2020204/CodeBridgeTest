using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeBridgeTest.Tests.Data.Factory.Impliment
{
    public abstract class SortStrategyTest<T>
    {
        protected abstract ISortStrategy<Dog> SortStrategy { get; }
        protected abstract Func<Dog, T> SortProperty { get; }

        protected IEnumerable<Dog> Dogs { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Dogs = new List<Dog>
            {
            new Dog { Weight = 3, TailLength = 2 },
            new Dog { Weight = 1, TailLength = 3 },
            new Dog { Weight = 2, TailLength = 1 },
            };
        }
    }
}