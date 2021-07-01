using System;
using System.Collections.Generic;
using System.Text;

using LeetCode_CS.Basis;

namespace LeetCode_CS.Easy
{
    public class LC0094_BinTreeInorder
    {
        public IList<int> InorderTraversal(TreeNode root)
        {

            List<int> finput = new List<int>();
            if (root == null) return finput;
            Stack<TreeNode> traverser = new Stack<TreeNode>();
            traverser.Push(root);
            TreeNode buff = root;
            
            HashSet<TreeNode> visitedLeft = new HashSet<TreeNode>();

            do
            {

                if (buff.left != null && !visitedLeft.Contains(buff))
                {
                    traverser.Push(buff.left);
                    visitedLeft.Add(buff);
                    buff = buff.left;
                    continue;
                }

                finput.Add(buff.val);
                if(traverser.Count>0 && traverser.Peek() != buff) traverser.Pop();

                if (buff.right != null)
                {
                    traverser.Push(buff.right);
                    buff = buff.right;
                    continue;
                }

                if (!traverser.TryPop(out buff)) buff = null;

            } while (traverser.Count > 0  || buff != null );

            return finput;
        }

        public IList<int> InorderTraversal_triv(TreeNode root)
        {

            List<int> finput = new List<int>();

            if (root == null) return finput;
            if (root.left != null)
                foreach (int i in InorderTraversal(root.left))
                    finput.Add(i);

            finput.Add(root.val);

            if (root.right != null)
                foreach (int i in InorderTraversal(root.right))
                    finput.Add(i);

            return finput;
        }
    }
}
