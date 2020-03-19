using System.Collections.Generic;
using System;



namespace LeetCode_CS.Easy
{
    class LC0021_Merge2SortedLists
    {
        public static void runner()
        {
            Queue<ListNode> testcases = new Queue<ListNode>();
            testcases.Enqueue(buildListNode(new int[] {1,2,4 }));
            testcases.Enqueue(buildListNode(new int[] { 1, 3, 4 }));

            ListNode buff;
            while (testcases.Count > 1)
            {
                buff = MergeTwoLists(testcases.Dequeue(),testcases.Dequeue());
                Console.WriteLine("START");

                while(buff != null)
                {
                    Console.Write(buff.val + ",");
                    buff = buff.next;
                }
                Console.WriteLine();
                Console.WriteLine("END");
            }





        }
        public static ListNode buildListNode(int[] p_arr)
        {
            ListNode root = new ListNode(0);
            ListNode head = root;
            foreach(int i in p_arr)
            {
                head.next = new ListNode(i);
                head = head.next;

            }
            return root.next;
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode[] diver = new ListNode[2];
            diver[0] = l1;
            diver[1] = l2;

            int idx = 0;
            ListNode root = new ListNode(0);
            ListNode head = root;
            
            while (diver[0] != null || diver[1] != null)
            {
                if (diver[0] is null) { idx = 1; }
                else if (diver[1] is null) { idx = 0; }
                else if (diver[0].val < diver[1].val) { idx = 0;}
                else { idx = 1; }

                head.next = new ListNode(diver[idx].val);
                diver[idx] = diver[idx].next;

                head = head.next;
            }

            
            return root.next;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
