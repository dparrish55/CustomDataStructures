using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylPCustomDS
{
    public class BinaryTree
    {
        public BinaryTreeNode root;

        public BinaryTree()
        {
            this.root = new BinaryTreeNode();
        }

        public BinaryTree(BinaryTreeNode root)
        {
            this.root = root;
        }

        public BinaryTreeNode BreadthFirstSearch(dynamic valueToFind)
        {
            Queue<BinaryTreeNode> frontier = new Queue<BinaryTreeNode>();
            frontier.Enqueue(this.root);

            while (frontier.Count > 0)
            {
                BinaryTreeNode currentNode = frontier.Dequeue();

                if (currentNode.value.GetType() == valueToFind.GetType())
                {
                    if (currentNode.value == valueToFind) { return currentNode; }
                }

                if (currentNode.left != null) { frontier.Enqueue(currentNode.left); }
                if (currentNode.right != null) { frontier.Enqueue(currentNode.right); }
            }

            return null;
        }

        public List<dynamic> BreadthFirstTraverse()
        {
            List<dynamic> traverseOrder = new List<dynamic>();
            Queue<BinaryTreeNode> frontier = new Queue<BinaryTreeNode>();
            frontier.Enqueue(this.root);

            while (frontier.Count > 0)
            {
                BinaryTreeNode currentNode = frontier.Dequeue();
                traverseOrder.Add(currentNode.value);

                if (currentNode.left != null) { frontier.Enqueue(currentNode.left); } 
                if (currentNode.right != null) { frontier.Enqueue(currentNode.right); }
            }

            return traverseOrder;
        }

        public BinaryTree CopyAt(dynamic targetNodeValue)
        {
            return new BinaryTree(DepthFirstSearch(targetNodeValue).CopyNode());
        }

        public void DeleteAt(dynamic targetNodeValue)
        {
            BinaryTreeNode targetNode = DepthFirstSearch(targetNodeValue);
            DeleteRecursor(targetNode);

            if (targetNode == this.root) { this.root = null; }
            else
            {
                BinaryTreeNode parentNode = FindParent(targetNodeValue);
                if (parentNode != null)
                {
                    if (parentNode.left.value == targetNodeValue) { parentNode.left = null; }
                    else { parentNode.right = null; }
                }
            }
        }

        public void DeleteRecursor(BinaryTreeNode currentNode)
        {
            if (currentNode.left != null) { DeleteRecursor(currentNode.left); }
            if (currentNode.right != null) { DeleteRecursor(currentNode.right); }

            currentNode.DeleteChildren();
        }

        public BinaryTreeNode DepthFirstSearch(dynamic valueToFind)
        {
            return DepthFirstSearchRecursor(valueToFind, this.root);
        }

        private BinaryTreeNode DepthFirstSearchRecursor(dynamic valueToFind, BinaryTreeNode currentNode)
        {
            BinaryTreeNode containingNodeLeft = null;
            if (currentNode.left != null)
            {
                containingNodeLeft = DepthFirstSearchRecursor(valueToFind, currentNode.left);
            }
            if (containingNodeLeft != null) { return containingNodeLeft; }

            if (currentNode.value.GetType() == valueToFind.GetType())
            {
                if (currentNode.value == valueToFind) { return currentNode; }
            }

            BinaryTreeNode containingNodeRight = null;
            if (currentNode.right != null)
            {
                containingNodeRight = DepthFirstSearchRecursor(valueToFind, currentNode.right);
            }
            if (containingNodeRight != null) { return containingNodeRight; }

            return null;
        }

        public bool Equals(BinaryTree compareTree)
        {
            List<dynamic> thisTraversal = this.InorderTraverse();
            List<dynamic> compareTraversal = compareTree.InorderTraverse();
            return thisTraversal.SequenceEqual(compareTraversal);
        }

        public BinaryTreeNode FindParent(dynamic valueToFind)
        {
            Queue<BinaryTreeNode> frontier = new Queue<BinaryTreeNode>();
            frontier.Enqueue(this.root);

            while (frontier.Count > 0)
            {
                BinaryTreeNode currentNode = frontier.Dequeue();

                if (currentNode.left != null) 
                {
                    if (currentNode.left.value.GetType() == valueToFind.GetType())
                    {
                        if (currentNode.left.value == valueToFind) { return currentNode; }
                    }

                    frontier.Enqueue(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    if (currentNode.right.value.GetType() == valueToFind.GetType())
                    {
                        if (currentNode.right.value == valueToFind) { return currentNode; }
                    }

                    frontier.Enqueue(currentNode.right);
                }
            }

            return null;
        }

        public List<dynamic> InorderTraverse()
        {
            List<dynamic> traverseOrder = new List<dynamic>();
            return InorderTraverseRecursor(traverseOrder, this.root);
        }

        private List<dynamic> InorderTraverseRecursor(List<dynamic> traverseOrder, BinaryTreeNode currentNode)
        {
            if (currentNode.left != null) { traverseOrder.Concat(InorderTraverseRecursor(traverseOrder, currentNode.left)); }
            traverseOrder.Add(currentNode.value);
            if (currentNode.right != null) { traverseOrder.Concat(InorderTraverseRecursor(traverseOrder, currentNode.right)); }

            return traverseOrder;
        }

        public List<dynamic> PostorderTraverse()
        {
            List<dynamic> traverseOrder = new List<dynamic>();
            return PostorderTraverseRecursor(traverseOrder, this.root);
        }

        private List<dynamic> PostorderTraverseRecursor(List<dynamic> traverseOrder, BinaryTreeNode currentNode)
        {
            if (currentNode.left != null) { traverseOrder.Concat(PostorderTraverseRecursor(traverseOrder, currentNode.left)); }
            if (currentNode.right != null) { traverseOrder.Concat(PostorderTraverseRecursor(traverseOrder, currentNode.right)); }
            traverseOrder.Add(currentNode.value);

            return traverseOrder;
        }

        public List<dynamic> PreorderTraverse()
        {
            List<dynamic> traverseOrder = new List<dynamic>();
            return PreorderTraverseRecursor(traverseOrder, this.root);
        }

        private List<dynamic> PreorderTraverseRecursor(List<dynamic> traverseOrder, BinaryTreeNode currentNode)
        {
            traverseOrder.Add(currentNode.value);
            if (currentNode.left != null) { traverseOrder.Concat(PreorderTraverseRecursor(traverseOrder, currentNode.left)); }
            if (currentNode.right != null) { traverseOrder.Concat(PreorderTraverseRecursor(traverseOrder, currentNode.right)); }

            return traverseOrder;
        }

        public bool TryAddAt(dynamic targetNodeValue, BinaryTree treeToAdd)
        {
            BinaryTreeNode targetNode = BreadthFirstSearch(targetNodeValue);
            
            if (targetNode == null) { return false; }
            
            else if (targetNode.left == null)
            {
                targetNode.left = treeToAdd.root;
                return true;
            }

            else if (targetNode.right == null)
            {
                targetNode.right = treeToAdd.root;
                return true;
            }

            else { return false; }
        }
    }
}
