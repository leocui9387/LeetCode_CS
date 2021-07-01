using System;
using System.Collections.Generic;
using System.Text;

using LeetCode_CS.Basis;

namespace LeetCode_CS.Easy
{
    public class LC0617_Merge2BinTrees
    {

        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {

            if (root1 == null) return CopyNode(root2);
            else if (root2 == null) return CopyNode(root1);
            else return new TreeNode(
                    root1.val + root2.val,
                    MergeTrees(root1.left,root2.left),
                    MergeTrees(root1.right,root2.right)
                );

        }

        TreeNode CopyNode(TreeNode original) {
            if (original == null) return null;
            return new TreeNode(original.val, CopyNode(original.left), CopyNode(original.right));
        }

        
    }

    
}
