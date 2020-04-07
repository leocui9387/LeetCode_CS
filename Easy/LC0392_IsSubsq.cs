using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0392_IsSubsq
    {
        public static void runner()
        {
            Dictionary<string, string> tc = new Dictionary<string, string>();
            tc.Add("abc", "ahbgdc");
            tc.Add("axc", "ahbgdc");
            //tc.Add();


            foreach(KeyValuePair<string, string> c in tc)
            {
                Console.WriteLine("START");
                Console.WriteLine($"Case:{c.Key},{c.Value}|Result:{IsSubsequence(c.Key, c.Value)}");
                Console.WriteLine("END");
            }

        }
        public static bool IsSubsequence(string s, string t)
        {

            
            int i = 0;
            foreach(Char c in t.ToCharArray())
            {
                Console.WriteLine(c +"|"+ s[i]);
                if (s[i] == c) i++;
                if (i == s.Length) return true;
            }

            return false;
        }

    }
}
