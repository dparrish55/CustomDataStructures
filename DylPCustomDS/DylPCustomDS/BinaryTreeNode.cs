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

        public void DeleteChildren()
        {
            this.left = null;
            this.right = null;
        }
    }
}
