using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    class LC07_ReverseInteger
    {
        public static void runner()
        {
            int[] tester = new int[] {123,452,-392,1239, 1534236469};
            foreach(int x in tester)
            {
                Console.WriteLine("input:" + x);
                Console.WriteLine("output:" + LC07_ReverseInteger.Reverse(x));
            }
            
        }

        public static int Reverse(int x)
        {

                long output = 0;

                while (x != 0)
                {
                    output = output * 10;

                    output = (output + x % 10);

                    if (output > int.MaxValue) return 0;

                    x = x / 10;
                }

                return (int) output;

        }
        public static int Reverse1(int x)
        {
            try { 

                Char[] buff = x.ToString().ToCharArray();
                int i = buff[0] =='-'?1:0;
                int j = buff.Length-1;

                char iterator;
                while (i < j){
                    iterator = buff[i];
                    buff[i] = buff[j];
                    buff[j] = iterator;
                    i++;
                    j--;
                }
                return int.Parse(buff);
            }
            catch(Exception e)
            {
                return 0;
            }



            
        }



    }
}
