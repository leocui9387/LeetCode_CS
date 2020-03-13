using System.Collections.Generic;
using System;



namespace LeetCode_CS
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
            ListNode diver1 = l1;
            ListNode diver2 = l2;

            ListNode root = new ListNode(0);
            ListNode head = root;
            
            while (diver1 != null || diver2 != null)
            {

                if(diver2 is null || diver1.val < diver2.val)
                {
                    head.next = new ListNode(diver1.val);
                    diver1 = diver1.next;
                }
                else
                {
                    head.next = new ListNode(diver2.val);
                    diver2 = diver2.next;
                }

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
