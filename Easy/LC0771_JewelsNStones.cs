using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    public class LC0771_JewelsNStones
    {
        public int numJewelsInStones(string J, string S)
        {
            HashSet<char> jewelz = new HashSet<char>();

            foreach(Char c in J.ToCharArray()) jewelz.Add(c);
            
            int i = 0;

            foreach(char c in S.ToCharArray()) if (jewelz.Contains(c)) i++;
            
            return i;
        }

    }
}
