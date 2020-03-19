using System;

namespace LeetCode_CS.Easy
{
    class LC09_PalindromeNumber
    {
        public static void runner()
        {

            int[] tester = { 0, 1, 10, 10000, 123948713, 12321, 493021, 463364 };

            foreach (int i in tester)
            {
                Console.WriteLine("number:" + i + "|" + LC09_PalindromeNumber.IsPalindrome(i));
            }
            Console.WriteLine();
        }



        public static bool IsPalindrome(int x)
        {
            //IsPalindrome_IntOnlyHalf
            //FAILURE zeros are ignored
            int buff = x;
            int rev = 0;
            int dig = 0;

            if (x < 10 && x > -10) return true;

            while (buff > rev)
            {
                dig = buff % 10;
                buff = buff / 10;

                if (rev == buff && rev != 0) break;

                rev = rev * 10;
                rev = rev + dig;

            }


            return rev == buff ? true : false;
        }
        public static bool IsPalindrome_IntOnlyFull(int x)
        {
            int buff = x;
            int rev = 0;



            while (buff > 0)
            {

                rev = rev * 10;
                rev = rev + buff % 10;
                buff = buff / 10;
            }


            return rev == x ? true : false;
        }
        public static bool IsPalindrome_String(int x)
        {
            string buff = x.ToString();


            for (int beg = 0, end = buff.Length - 1; beg < end; beg++, end--)
            {

                Console.WriteLine(buff[beg] + "|" + buff[end]);
                if (buff[beg] != buff[end]) return false;
            }


            return true;
        }
    }
}
