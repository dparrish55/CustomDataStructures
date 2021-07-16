using BinaryTreeNode = DylPCustomDS.BinaryTreeNode;
using BinaryTree = DylPCustomDS.BinaryTree;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DylPCustomDSTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        private BinaryTree testTree;

        [TestInitialize]
        public void SetUpTestTree()
        {
            BinaryTreeNode node0 = new BinaryTreeNode(0);
            BinaryTreeNode node1 = new BinaryTreeNode(true); //Test that it still works with varying types in BTNode.value
            BinaryTreeNode node2 = new BinaryTreeNode(2);
            BinaryTreeNode node3 = new BinaryTreeNode(3);
            BinaryTreeNode node4 = new BinaryTreeNode(4);
            BinaryTreeNode node5 = new BinaryTreeNode("5"); //As above with an additional type
            BinaryTreeNode node6 = new BinaryTreeNode(6);
            BinaryTreeNode node7 = new BinaryTreeNode(7);

            node0.left = node1;
            node0.right = node2;

            node1.left = node3;

            node2.right = node6;

            node3.left = node4;
            node3.right = node5;

            node6.left = node7;

            //nodes 4, 5, and 7 have no children

            testTree = new BinaryTree(node0);
        }

        [TestMethod]
        public void BreadthFirstSearchDoesNotFindInvalidElement()
        {
            bool valueToFind = false;
            Assert.IsNull(testTree.BreadthFirstSearch(valueToFind));
        }

        [TestMethod]
        public void BreadthFirstSearchFindsValidElement()
        {
            string valueToFind = "5";
            Assert.AreEqual(valueToFind, testTree.BreadthFirstSearch(valueToFind).value);
        }

        [TestMethod]
        public void BreadthFirstTraverseExploresInProperOrder()
        {
            List<dynamic> properOrder = new List<dynamic> { 0, true, 2, 3, 6, 4, "5", 7 };
            CollectionAssert.AreEqual(properOrder, testTree.BreadthFirstTraverse());
        }

        [TestMethod]
        public void CopyAtNodeGeneratesIdenticalSubTree()
        {
            BinaryTreeNode Node3 = new BinaryTreeNode(3);
            BinaryTreeNode Node4 = new BinaryTreeNode(4);
            BinaryTreeNode Node5 = new BinaryTreeNode("5");
            Node3.left = Node4;
            Node3.right = Node5;
            BinaryTree compareTree = new BinaryTree(Node3);

            BinaryTree copiedTree = testTree.CopyAt(3);

            Assert.IsTrue(compareTree.Equals(copiedTree));
        }

        [TestMethod]
        public void CopyAtRootGeneratesIdenticalTree()
        {
            BinaryTree copiedTree = testTree.CopyAt(testTree.root.value);

            Assert.IsTrue(testTree.Equals(copiedTree));
        }

        [TestMethod]
        public void DeleteAtNodeResultsInSubtreeWithoutCorrespondingBranch()
        {

            BinaryTreeNode node0 = new BinaryTreeNode(0);
            BinaryTreeNode node1 = new BinaryTreeNode(true); //Test that it still works with varying types in BTNode.value
            BinaryTreeNode node2 = new BinaryTreeNode(2);
            BinaryTreeNode node6 = new BinaryTreeNode(6);
            BinaryTreeNode node7 = new BinaryTreeNode(7);

            node0.left = node1;
            node0.right = node2;

            node2.right = node6;

            node6.left = node7;

            BinaryTree subTree = new BinaryTree(node0);

            testTree.DeleteAt(3);

            Assert.IsTrue(subTree.Equals(testTree));
        }

        [TestMethod]
        public void DeleteAtRootResultsInNullRoot()
        {
            testTree.DeleteAt(testTree.root.value);
            Assert.IsNull(testTree.root);
        }

        [TestMethod]
        public void DepthFirstSearchDoesNotFindInvalidElement()
        {
            bool valueToFind = false;
            Assert.IsNull(testTree.DepthFirstSearch(valueToFind));
        }

        [TestMethod]
        public void DepthFirstSearchFindsValidElement()
        {
            string valueToFind = "5";
            Assert.AreEqual(valueToFind, testTree.DepthFirstSearch(valueToFind).value);
        }

        [TestMethod]
        public void EqualsIsFalseWhenTreesAreNotEqual()
        {
            BinaryTreeNode compareRoot = new BinaryTreeNode(0);
            BinaryTree compareTree = new BinaryTree(compareRoot);

            Assert.IsFalse(testTree.Equals(compareTree));
        }

        [TestMethod]
        public void EqualsIsTrueWhenTreesAreEqual()
        {
            BinaryTree compareTree = testTree;

            Assert.IsTrue(testTree.Equals(compareTree));
        }

        [TestMethod]
        public void FindParentReturnsParentOfNodeWithGivenValue()
        {
            BinaryTreeNode actualParent = testTree.root.left;
            Assert.AreEqual(actualParent.value, testTree.FindParent(3).value);
        }

        [TestMethod]
        public void InorderTraverseExploresInProperOrder()
        {
            List<dynamic> properOrder = new List<dynamic> { 4, 3, "5", true, 0, 2, 7, 6 };
            CollectionAssert.AreEqual(properOrder, testTree.InorderTraverse());
        }

        [TestMethod]
        public void NewTreeWithoutParameterHasRootWithNullValue()
        {
            BinaryTree testBT = new BinaryTree();
            Assert.IsNull(testBT.root.value);
        }

        [TestMethod]
        public void NewTreeWithParameterAcceptsPassedRootWithChildren()
        {
            BinaryTreeNode testRoot = new BinaryTreeNode("root");
            testRoot.left = new BinaryTreeNode("left");
            testRoot.right = new BinaryTreeNode("right");

            BinaryTree testBT = new BinaryTree(testRoot);

            Assert.AreEqual("root", testBT.root.value);
            Assert.AreEqual("left", testBT.root.left.value);
            Assert.AreEqual("right", testBT.root.right.value);
        }

        [TestMethod]
        public void PostorderTraverseExploresInProperOrder()
        {
            List<dynamic> properOrder = new List<dynamic> { 4, "5", 3, true, 7, 6, 2, 0 };
            CollectionAssert.AreEqual(properOrder, testTree.PostorderTraverse());
        }

        [TestMethod]
        public void PreorderTraverseExploresInProperOrder()
        {
            List<dynamic> properOrder = new List<dynamic> { 0, true, 3, 4, "5", 2, 6, 7 };
            CollectionAssert.AreEqual(properOrder, testTree.PreorderTraverse());
        }
    }
}
