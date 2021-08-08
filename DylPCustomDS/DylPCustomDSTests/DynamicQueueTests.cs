using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicQueue = DylPCustomDS.DynamicQueue;
using System;
using System.Collections.Generic;

namespace DylPCustomDSTests
{
    [TestClass]
    public class DynamicQueueTests
    {
        [TestMethod]
        public void newQueueWithArrayParameterPopsReverseElements()
        {
            dynamic[] initializerArray = new dynamic[] { 1, "2", 3, 4, 5 };
            DynamicQueue newQueue = new DynamicQueue(initializerArray);

            Assert.AreEqual(5, newQueue.size);

            Assert.AreEqual(1, newQueue.Dequeue());
            Assert.AreEqual(4, newQueue.size);

            Assert.AreEqual("2", newQueue.Dequeue());
            Assert.AreEqual(3, newQueue.size);

            Assert.AreEqual(3, newQueue.Dequeue());
            Assert.AreEqual(2, newQueue.size);

            Assert.AreEqual(4, newQueue.Dequeue());
            Assert.AreEqual(1, newQueue.size);

            Assert.AreEqual(5, newQueue.Dequeue());
            Assert.AreEqual(0, newQueue.size);
        }

        [TestMethod]
        public void newQueueWithNoParametersIsEmpty()
        {
            DynamicQueue newQueue = new DynamicQueue();
            List<dynamic> emptyDynamicList = new List<dynamic>();

            Assert.AreEqual(0, newQueue.size);
            CollectionAssert.AreEqual(emptyDynamicList, newQueue.elements);
        }

        [TestMethod]
        public void TopReturnsTopElement()
        {
            dynamic[] initializerArray = new dynamic[] { 1, "2", 3, 4, 5 };
            DynamicQueue newQueue = new DynamicQueue(initializerArray);

            Assert.AreEqual(1, newQueue.Next());
            Assert.AreEqual(5, newQueue.size);
        }
    }
}
