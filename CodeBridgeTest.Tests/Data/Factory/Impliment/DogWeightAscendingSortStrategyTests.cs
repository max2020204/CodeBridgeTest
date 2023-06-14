﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Data.Factory.Impliment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBridgeTest.Model;
using CodeBridgeTest.Tests.Data.Factory.Impliment;
using CodeBridgeTest.Data.Factory.Interfaces;

namespace CodeBridgeTest.Data.Factory.Impliment.Tests
{
    [TestClass()]
    public class DogWeightAscendingSortStrategyTests : SortStrategyTest<float>
    {
        protected override ISortStrategy<Dog> SortStrategy => new DogWeightAscendingSortStrategy();
        protected override Func<Dog, float> SortProperty => dog => dog.Weight;

        [TestMethod()]
        public void Sort_ShouldSortDogsInAscendingOrder()
        {
            // Arrange
            var expected = Dogs.OrderBy(SortProperty);

            // Act
            var result = SortStrategy.Sort(Dogs);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}