using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS
{
    class Utility
    {

        public static void PrintIterable<T>(IEnumerable<T> p_arr)
        {
            Console.Write("Array:");
            foreach (T i in p_arr) { Console.Write(i.ToString() + ","); }
            Console.WriteLine();

        }

    }
}
