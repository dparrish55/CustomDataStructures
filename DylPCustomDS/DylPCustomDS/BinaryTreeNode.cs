using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylPCustomDS
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode left, right = null;
        public dynamic value;

        public BinaryTreeNode()
        {
            this.value = null;
        }

        public BinaryTreeNode(dynamic value)
        {
            this.value = value;
        }

        public BinaryTreeNode CopyNode()
        {
            BinaryTreeNode copied = new BinaryTreeNode(this.value);
            if (this.left != null)
            {
                copied.left = this.left.CopyNode();
            }

            if (this.right != null)
            {
                copied.right = this.right.CopyNode();
            }

            return copied;
        }

        public void DeleteChildren()
        {
            this.left = null;
            this.right = null;
        }
    }
}
