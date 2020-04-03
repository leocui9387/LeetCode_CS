using System;
using System.Collections.Generic;

namespace LeetCode_CS.Easy
{
    class LC0028_ImplementstrStr
    {
        public static void runner()
        {
            List<String[]> tc = new List<string[]>();
            tc.Add(new String[] { "mississippi", "issi" });
            tc.Add(new String[] {"hello", "ll" });
            tc.Add(new String[] { "aaaaa","bba" });
            tc.Add(new String[] {"a", "a" });
            tc.Add(new String[] { "mississippi", "issip" });

            //tc.Add(new String[] { });

            foreach (String[] s in tc)
            {
                Console.WriteLine("START|H:" + s[0] + "|N:" + s[1]);
                //Console.WriteLine("DFA:" + kmp_dfa(s[1]).ToString());
                Console.WriteLine("RESULT:" + StrStr_KMP(s[0], s[1]));
                Console.WriteLine("END-------");
            }
        }
        public static int StrStr(string haystack, string needle)
        {
            //Boyer Moore
            

            int nL = needle.Length;
            if (nL == 0) return 0;
            Dictionary<Char, int> skip = BM_skipper(needle);
            int hL = haystack.Length;

            int i, j;
            
            for (i = 0; i < (hL - nL) + 1 ;)
            {

                for (j= nL -1; j > -1 && needle[j] == haystack[i+j]; j--)
                {
                    Console.WriteLine("I:" + i + "|J:" + j+"|needle:"+ needle[j] + "|haystack:"+ haystack[i + j]);
                }

                if (j == -1) { return i; }
                else if (!skip.ContainsKey(haystack[i + j])) { i++; }
                else { i = i + nL - skip[needle[j]]; }
                
                Console.WriteLine("Skip:" + skip[needle[j]] + "|i" + i + "|j"+j);
            }

            return -1;

        }

        private static Dictionary<Char, int> BM_skipper(String p_pat)
        {
            // mismatch character algo
            Dictionary<Char, int> pattern = new Dictionary<char, int>();

            for(int i = p_pat.Length -1; i> -1; i--)
            {
                if (!pattern.ContainsKey(p_pat[i]))
                {
                    pattern.Add(p_pat[i], i);
                }

            }
            printBMSkipper(pattern);
            return pattern;

        }

        private static void printBMSkipper(Dictionary<Char, int> p_pat)
        {
            Console.WriteLine("START: BM Skipper********");

            foreach(KeyValuePair<Char, int> kvp in p_pat)
            {
                Console.WriteLine("CHAR:" + kvp.Key + "|VAL:" + kvp.Value);

            }

            Console.WriteLine("END:*********************");
        }


        public static int StrStr_KMP(string haystack, string needle)
        {

            // KMP 
            int nL = needle.Length;
            if (nL == 0) return 0;

            int hL = haystack.Length;

            Dictionary<Char, int[]> dfa = kmp_dfa(needle);
            int j=0;

            for(int i=0; i < hL; i++ )
            {
                if (dfa.ContainsKey(haystack[i]))
                {
                    j = dfa[haystack[i]][j];
                    if (j == nL) return (i - j + 1);
                }
                else
                {
                    j = 0;
                }

            }

            return -1;
        }

        private static Dictionary<Char, int[]> kmp_dfa(String p_needle)
        {

            int nL = p_needle.Length;
            if (nL == 0) return null;
            Dictionary<Char, int[]> dfa = new Dictionary<char, int[]>();

            dfa.Add(p_needle[0], new int[nL]);
            dfa[p_needle[0]][0] = 1;
            
            for (int i = 1, j = 0; i < nL; i++)
            {
                if (!dfa.ContainsKey(p_needle[i])) { dfa.Add(p_needle[i], new int[nL]); }
                
                foreach (KeyValuePair<Char, int[]> kvp in dfa)
                    kvp.Value[i] = dfa[kvp.Key][j];

                dfa[p_needle[i]][i] = i + 1;
                j = dfa[p_needle[i]][j];
                
            }

            printDFA(dfa);


            return dfa;

        }

        private static void printDFA(Dictionary<Char, int[]> p_dfa)
        {
            Console.WriteLine("PRINT DFA-----------");
            foreach (KeyValuePair<Char, int[]> kvp in p_dfa)
            {
                
                Console.Write("CHAR:" + kvp.Key + "|");
                foreach(int i in kvp.Value)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("END PRINT DFA-------");
        }

        public static int StrStr_SedgewickP761(string haystack, string needle)
        {
            int nL = needle.Length;
            if (nL == 0) return 0;

            int hL = haystack.Length;

            int i, j;

            for (i = 0, j = 0; i < hL && j < nL; i++)
            {
                Console.WriteLine("i:" + i + "|j:" + j);
                if (needle[j] == haystack[i]) { j++; }
                else
                {

                    i -= j;
                    j = 0;
                }

                if (j == nL) return i - nL + 1;

            }

            return -1;

        }
        public static int StrStr_2(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (haystack.Length == 0) return -1;

            int max = (haystack.Length - needle.Length) + 1;
            int i = 0;
            while (i < max)
            {

                while (i < max - 1 && haystack[i] != needle[0]) { i++; }
                if (haystack.Substring(i, needle.Length).CompareTo(needle) == 0)
                {
                    return i;
                }

                i++;
            }

            return -1;
        }
        public static int StrStr_1(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (haystack.Length == 0) return -1;

            for (int i = 0; i < (haystack.Length - needle.Length) + 1; i++)
            {
                if (haystack.Substring(i, needle.Length).CompareTo(needle) == 0)
                {
                    return i;
                }

            }

            return -1;
        }
    }
}
