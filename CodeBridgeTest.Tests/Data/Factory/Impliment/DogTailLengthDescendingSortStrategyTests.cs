﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Data.Factory.Impliment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBridgeTest.Tests.Data.Factory.Impliment;
using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;

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
            // Arrange
            var expected = Dogs.OrderByDescending(SortProperty);

            // Act
            var result = SortStrategy.Sort(Dogs);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}