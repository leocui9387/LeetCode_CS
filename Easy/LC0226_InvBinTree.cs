using System;
using System.Collections.Generic;
using System.Text;

using LeetCode_CS.Basis;

namespace LeetCode_CS.Easy
{
    class LC0226_InvBinTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            return new TreeNode(root.val, InvertTree(root.right), InvertTree(root.left));
        }
    }
}
