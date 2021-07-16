using BinaryTreeNode = DylPCustomDS.BinaryTreeNode;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DylPCustomDSTests
{
    [TestClass]
    public class BinaryTreeNodeTests
    {
        [TestMethod]
        public void DeleteChildrenResultsInNullLeftAndRight()
        {
            BinaryTreeNode testBTRoot = new BinaryTreeNode("root");
            testBTRoot.left = new BinaryTreeNode("left");
            testBTRoot.right = new BinaryTreeNode("right");

            testBTRoot.DeleteChildren();
            Assert.IsNull(testBTRoot.left);
            Assert.IsNull(testBTRoot.right);
        }

        [TestMethod]
        public void NewNodeAcceptsIntValue()
        {
            int testInt = 42;
            BinaryTreeNode testBTNode = new BinaryTreeNode(testInt);
            Assert.AreEqual(testInt, testBTNode.value);
        }

        [TestMethod]
        public void NewNodeAcceptsStringValue()
        {
            string testString = "NewNodeTestString";
            BinaryTreeNode testBTNode = new BinaryTreeNode(testString);
            Assert.AreEqual(testString, testBTNode.value);
        }

        [TestMethod]
        public void NewNodeHasNoChildren()
        {
            BinaryTreeNode testBTNode = new BinaryTreeNode("");
            Assert.IsNull(testBTNode.left);
            Assert.IsNull(testBTNode.right);
        }

        [TestMethod]
        public void NewNodeWithoutArgsHasValueEqualNull()
        {
            BinaryTreeNode testBTNode = new BinaryTreeNode();
            Assert.IsNull(testBTNode.value);
        }

        [TestMethod]
        public void NodeAcceptsChildrenOfDifferentType()
        {
            BinaryTreeNode testBTRoot = new BinaryTreeNode(0);
            testBTRoot.left = new BinaryTreeNode("left");
            testBTRoot.right = new BinaryTreeNode("right");

            Assert.AreEqual("left", testBTRoot.left.value);
            Assert.AreEqual("right", testBTRoot.right.value);
        }

        [TestMethod]
        public void NodeAcceptsChildrenOfSameType()
        {
            BinaryTreeNode testBTRoot = new BinaryTreeNode("root");
            testBTRoot.left = new BinaryTreeNode("left");
            testBTRoot.right = new BinaryTreeNode("right");

            Assert.AreEqual("left", testBTRoot.left.value);
            Assert.AreEqual("right", testBTRoot.right.value);
        }

        [TestMethod]
        public void NodeAcceptsChildrenOfVaryingTypes()
        {
            BinaryTreeNode testBTRoot = new BinaryTreeNode(0);
            testBTRoot.left = new BinaryTreeNode("left");
            testBTRoot.right = new BinaryTreeNode(true);

            Assert.AreEqual("left", testBTRoot.left.value);
            Assert.IsTrue(testBTRoot.right.value);
        }
    }
}
