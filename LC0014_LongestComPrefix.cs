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


            testcases.Add(new string[] { "flower", "flow", "flight"});
            testcases.Add(new string[] { "dog", "racecar", "car" });

            foreach (String[] s in testcases)
            {
                Console.WriteLine(LongestCommonPrefix(s));
            }





        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";

            foreach (String s in strs)
                if (s.Length == 0) return "";
            
            int minLength = 1;
            StringBuilder outbuff = new StringBuilder();
            String buff;
            
            for (int i = 0; i < minLength; i++)
            {
                buff = strs[0].Substring(i, 1);
                foreach (String s in strs)
                {
                    if (s[i].CompareTo(buff.ToCharArray()[0]) != 0) return outbuff.ToString();
                    if (s.Length < minLength) minLength = s.Length;
                }
                outbuff.Append(buff);
            }
            return outbuff.ToString();
        }



    }
}
