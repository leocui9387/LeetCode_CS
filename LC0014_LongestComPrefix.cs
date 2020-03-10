using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS
{
    class LC0014_LongestComPrefix
    {

        public static void runner()
        {

            List<String[]> testcases = new List<string[]>();

            testcases.Add(new string[] { "aa","aa" });
            testcases.Add(new string[] { "flower", "flow", "flight" });
            testcases.Add(new string[] { "dog", "racecar", "car" });
            
            foreach (String[] s in testcases)
            {
                Console.WriteLine(LongestCommonPrefix(s));
            }

        }

        public static string LongestCommonPrefix(string[] strs)
        {
            // WITH BINARY search - nice idea. doesn't perform better
            if (strs.Length == 0 || strs[0].Length == 0) return "";

            int minLength = strs[0].Length;

            for (int i = 1; i < strs.Length; i++)
                if (strs[i].Length < minLength) minLength = strs[i].Length;

            if (minLength == 0) return "";

            int beg = 0;
            int end = minLength - 1;
            int mid = end;
            int j;
            String substr = "";
            while (end >= beg)
            {
                Console.WriteLine("START || substr:" + substr + "|b:" + beg + "|m:" + mid + "|e:" + end);
                

                mid = (beg + end) / 2;
                
                
                substr = strs[0].Substring(0, mid+1);

                for (j = 0; j < strs.Length; j++)
                {
                    Console.WriteLine(j);
                    if (strs[j].Substring(0, mid+1).CompareTo(substr) != 0)
                        break;

                }

                if (j < strs.Length ) { end = mid -1 ; }
                else {beg = mid +1;}
                


                Console.WriteLine("END || substr:" + substr + "|b:" + beg + "|m:" + mid + "|e:" + end);
                Console.WriteLine();

            }

            return strs[0].Substring(0,(beg + end + 1)/2);
        }

        public static string LongestCommonPrefix_noBinary(string[] strs)
        {
            if (strs.Length == 0) return "";

            foreach (String s in strs)
            {
                if (s.Length == 0)
                {
                    return "";
                }
            }


            int minLength = 100;
            StringBuilder outbuff = new StringBuilder();
            String buff;
            for (int i = 0; i < minLength; i++)
            {

                buff = strs[0].Substring(i, 1);

                foreach (String s in strs)
                {

                    if (s[i].CompareTo(buff.ToCharArray()[0]) != 0)
                    {
                        return outbuff.ToString();
                    }
                    if (s.Length < minLength) minLength = s.Length;
                }
                outbuff.Append(buff);

            }

            return outbuff.ToString();
        }
    }
}
