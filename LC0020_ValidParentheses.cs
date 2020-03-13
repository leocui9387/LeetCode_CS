using System;
using System.Collections.Generic;

namespace LeetCode_CS
{
    class LC0020_ValidParentheses
    {
        public static void runner()
        {

            List<String> testcases = new List<string>();
            testcases.Add("()");
            testcases.Add("()[]{}");
            testcases.Add("(]");
            testcases.Add("([)]");
            testcases.Add("{[]}");
            testcases.Add("}");

            foreach (String s in testcases)
            {
                Console.WriteLine("input:" + s + "|valid:" + IsValid(s));
            }

        }

        public static bool IsValid(string s)
        {
            if (s.Length == 1) return false;
            Stack<Char> pStack = new Stack<char>();
            Char[] sArr = s.ToCharArray();


            foreach (Char c in sArr)
            {

                switch (c)
                {
                    case '(': // open norm 40
                    case '[': // open square 91
                    case '{': // open curly 123

                        pStack.Push(c);
                        break;
                    case ']': // close square
                        if (pStack.Count > 0 && pStack.Peek().CompareTo('[') == 0) { pStack.Pop(); }
                        else { return false; }
                        break;

                    case ')': // close norm
                        if (pStack.Count > 0 && pStack.Peek().CompareTo('(') == 0) { pStack.Pop(); }
                        else { return false; }
                        break;

                    case '}': // close curly
                        if (pStack.Count > 0 && pStack.Peek().CompareTo('{') == 0) { pStack.Pop(); }
                        else { return false; }
                        break;
                }

            }

            return pStack.Count == 0 ? true : false;
        }



    }
}
