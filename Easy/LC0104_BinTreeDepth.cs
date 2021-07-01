using System;
using System.Collections.Generic;
using System.Text;

using LeetCode_CS.Basis;

namespace LeetCode_CS.Easy
{
    class LC0104_BinTreeDepth
    {
        public int MaxDepth(TreeNode root)
        {
            if (root != null) return 1 + Math.Max(MaxDepth(root.left),MaxDepth(root.right));
            else return 0;
        }

    }
}
