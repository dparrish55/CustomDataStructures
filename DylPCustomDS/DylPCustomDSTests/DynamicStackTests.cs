using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicStack = DylPCustomDS.DynamicStack;
using System;

namespace DylPCustomDSTests
{
    [TestClass]
    public class DynamicStackTests
    {
        [TestMethod]
        public void NewStackWithArrayParameterPopsReverseElements()
        {
            dynamic[] initializerArray = new dynamic[] { 1, "2", 3, 4, 5 };
            DynamicStack newStack = new DynamicStack(initializerArray);

            Assert.AreEqual(5, newStack.size);

            Assert.AreEqual(5, newStack.Pop());
            Assert.AreEqual(4, newStack.size);

            Assert.AreEqual(4, newStack.Pop());
            Assert.AreEqual(3, newStack.size);

            Assert.AreEqual(3, newStack.Pop());
            Assert.AreEqual(2, newStack.size);

            Assert.AreEqual("2", newStack.Pop());
            Assert.AreEqual(1, newStack.size);

            Assert.AreEqual(1, newStack.Pop());
            Assert.AreEqual(0, newStack.size);
        }

        [TestMethod]
        public void NewStackWithNoParametersIsEmpty()
        {
            DynamicStack newStack = new DynamicStack();
            dynamic[] emptyDynamicArray = new dynamic[0];

            Assert.AreEqual(0, newStack.size);
            CollectionAssert.AreEqual(emptyDynamicArray, newStack.elements);
        }

        [TestMethod]
        public void TopReturnsTopElement()
        {
            dynamic[] initializerArray = new dynamic[] { 1, "2", 3, 4, 5 };
            DynamicStack newStack = new DynamicStack(initializerArray);

            Assert.AreEqual(5, newStack.Top());
            Assert.AreEqual(5, newStack.size);
        }
    }
}
