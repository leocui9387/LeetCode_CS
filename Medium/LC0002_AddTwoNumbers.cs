using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    public class LC0002_AddTwoNumbers
    {
        public static void runner()
        {
            Console.WriteLine("LEO");

            LC0002_AddTwoNumbers test = new LC0002_AddTwoNumbers();
            ListNode number1 = test.LN_Generator("342");
            Console.WriteLine(number1.ToString());

            ListNode number2 = test.LN_Generator("1465");
            Console.WriteLine(number2.ToString());

            ListNode result = test.Add(number1, number2);
            Console.WriteLine(result.ToString());

        }
        
        ListNode Add(ListNode p_1, ListNode p_2)
        {
            ListNode result = new ListNode(1);
            ListNode iterator = result;
            ListNode buff1 = p_1;
            ListNode buff2 = p_2;

            int calc;
            int carryover = 0;

            while ((!(buff1 is null) || !(buff2 is null)) || carryover > 0)
            {
                calc = (buff1 is null ? 0: buff1.val) + (buff2 is null ? 0 : buff2.val) + carryover;
                iterator.next = new ListNode(calc % 10);
                carryover = calc / 10;

                if (!(buff2 is null)) buff2 = buff2.next;
                if (!(buff1 is null)) buff1 = buff1.next;
                iterator = iterator.next;
            }

            return result.next;
        }

        ListNode LN_Generator(String p_input)
        {
            if(p_input.Length <= 0)
                return new ListNode(-1);

            int i = p_input.Length - 1;
            ListNode start = new ListNode( Int32.Parse(p_input[i].ToString()));
            ListNode buff= start;

            for(i--; i>-1; i--)
            {
                buff.next = new ListNode(Int32.Parse(p_input[i].ToString()));
                buff = buff.next;
            }

            return start;
        }




    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        override public String ToString()
        {
            if (next is null) return val.ToString();
            return next.ToString() + val.ToString() ;
        }
    }
}
