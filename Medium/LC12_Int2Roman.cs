using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS
{
    class LC12_Int2Roman.Medium
    {

        public static void runner()
        {
            /*
            Random rand = new Random();

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(rand.Next(1, 3999));
            }
            */

            String[] testCases = { "I", "MMMCCLXXVIII", "MMMDCCCXV", "MMMCCCLXXXII", "MMMDCXXIV", "MDCCXXXVII", "LXXXII", "MCDXXIX", "MMMCCCLXIV", "MDCII", "DCCXLI" };
            int[] testCases_int = { 1, 3278, 3815, 3382, 3624, 1737, 82, 1429, 3364, 1602, 741 };

            foreach (int tCase in testCases_int)
            {
                Console.WriteLine(LC12_Int2Roman.IntToRoman(tCase));
            }

        }

        public static string IntToRoman(int num)
        {

            int output = 0;
            Dictionary<int, Char> RNmap = new Dictionary<int, char>();
            RNmap.Add(1, 'I');
            RNmap.Add(5,'V');
            RNmap.Add(10,'X');
            RNmap.Add(50, 'L');
            RNmap.Add(100, 'C');
            RNmap.Add(500, 'D');
            RNmap.Add(1000, 'M');



            return "leo";
        }

        public static int RomanToInt(string s)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("New String: " + s);

            int output = 0;
            Dictionary<Char, int> RNmap = new Dictionary<char, int>();

            RNmap.Add('I', 1);
            RNmap.Add('V', 5);
            RNmap.Add('X', 10);
            RNmap.Add('L', 50);
            RNmap.Add('C', 100);
            RNmap.Add('D', 500);
            RNmap.Add('M', 1000);

            for (int i = s.Length - 1; i > -1; i--)
            {
                if (i + 1 < s.Length && RNmap[s[i + 1]] > RNmap[s[i]])
                {
                    output -= RNmap[s[i]];
                }
                else
                {
                    output += RNmap[s[i]];
                }

                Console.WriteLine("Total:" + output + "|new dig:" + s[i]);
            }

            Console.WriteLine("-------------------------------------------------------");

            return output;
        }

    }



}

