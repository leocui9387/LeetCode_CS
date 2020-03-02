using System;
using System.Collections.Generic;
using System.Text;


namespace LeetCode_CS
{
    class LC1302_DeepestLeavesSum
    {

        public static void runner()
        {
            TreeNode root = new TreeNode(1);
            //root.Randomizer(0,7);

            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.left.left = new TreeNode(7);

            root.right = new TreeNode(3);
            root.right.right = new TreeNode(6);
            root.right.right.right = new TreeNode(8);

            Console.WriteLine(deepestLeavesSum(root));
            
        }

        public static int deepestLeavesSum(TreeNode p_root)
        {
            depthVal topdv = new depthVal(0, p_root.val);

            topdv.add(diver(p_root.left, topdv));
            topdv.add(diver(p_root.right, topdv));

            return topdv.val;

        }

        public static depthVal diver(TreeNode p_node, depthVal p_parent)
        {

            if(p_node is null)
            {
                return p_parent;
            }
            Console.WriteLine("depth:" + (p_parent.depth + 1) + "|val:" + p_node.val);
            
            depthVal thisNode = new depthVal(p_parent.depth + 1 , p_node.val);

            if (!(p_node.left is null))
            {
                
                thisNode.add(diver(p_node.left, thisNode));
            }
            if (!(p_node.right is null))
            {
                thisNode.add(diver(p_node.right, thisNode));
            }

            return thisNode;
        }

        public class depthVal
        {
            public int depth;
            public int val;

            public depthVal(int p_depth, int p_val)
            {
                depth = p_depth;
                val = p_val;
            }

            public void add(depthVal p_dv)
            {
                if (p_dv is null)
                {
                    return;
                }
                if (p_dv.depth == this.depth)
                {
                    this.val += p_dv.val;
                }else if (this.depth < p_dv.depth)
                {
                    this.val = p_dv.val;
                    this.depth = p_dv.depth;
                }
            }

            
        }



        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }

            public void Randomizer(int p_type, int p_chances = 4)
            {
                Console.WriteLine("val:" + val);
                Random rnd = new Random();

                switch(p_type)
                {
                    case 0:
                        right = new TreeNode(rnd.Next(1, 100));
                        right.Randomizer(rnd.Next(0, p_chances));
                        left = new TreeNode(rnd.Next(1, 100));
                        left.Randomizer(rnd.Next(0, p_chances));
                        return;
                    case 1:
                        left = new TreeNode(rnd.Next(1,100));
                        left.Randomizer(rnd.Next(0, p_chances));
                        return;
                    case 2:
                        right = new TreeNode(rnd.Next(1, 100));
                        right.Randomizer(rnd.Next(0, p_chances));
                        return;
                    
                    
                }
            }
        }
    }
}
