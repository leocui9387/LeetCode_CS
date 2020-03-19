using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0038_CountNSay
    {
        public static void runner()
        {

            for(int i = 2; i < 5; i++)
            {
                Console.WriteLine("START i=======" + i);

                Console.WriteLine("OUTPUT:" + CountAndSay(i));

                Console.WriteLine("END:============");

            }



        }

        public static string CountAndSay(int n)
        {
            String buff = "1";

            if(n > 1)
            {
                for(int i = 2; i < n+1; i++)
                {
                    Console.WriteLine("buff0:" + buff);
                    buff = CAS_inner(buff);
                    Console.WriteLine("buff1:" + buff);
                }
            }


            return buff;

        }

        private static String CAS_inner(String s)
        {
            StringBuilder buff = new StringBuilder();
            int sL = s.Length;

            int count = 0;
            char letter_buff = s[0]; 
            for (int i=0; i<sL; i++)
            {
                Console.WriteLine("START|buff:" + buff + "|i:" + i);
                if (letter_buff == s[i])
                {
                    count++;
                }
                else
                {
                    buff.Append(count.ToString() + letter_buff.ToString());
                    letter_buff = s[i];
                    count = 1;
                }
                Console.WriteLine("END buff:" + buff);
            }
            buff.Append(count.ToString() + letter_buff.ToString());

            return buff.ToString();
        }



        public static string CountAndSay_1(int n) {

            String buff="1";
            
            for (int i = 2; i < n + 1; i++)
            {
                Console.WriteLine("START buff:" + buff);
                buff = CAS_inner_1(Int32.Parse(buff));
                Console.WriteLine("END buff:" + buff);
            }



            return buff;
        }
        public static string CAS_inner_1(int n)
        {

            StringBuilder output = new StringBuilder();

            


            Stack<pair> stk = new Stack<pair>();
            pair buff = new pair(0, 0);
            byte last = 0;

            while (n != 0)
            {
                last = (byte)(n % 10);
                if (buff.num == last)
                {
                    buff.count++;
                }
                else
                {
                    stk.Push(buff);
                    buff = new pair(1,last);
                }

                n = n / 10;

            }

            stk.Push(buff);

            while (stk.Count > 1)
            {
                buff = stk.Pop();
                output.Append(buff.count);
                output.Append(buff.num);
            }


            return output.ToString();
        }

        class pair
        {
            public int count;
            public byte num;
            public pair(int p_count, byte p_num)
            {
                count = p_count;
                num = p_num;
            }
        }



    }
}
