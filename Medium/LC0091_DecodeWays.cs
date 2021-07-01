using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    public class LC0091_DecodeWays
    {
        public int NumDecodings(string s)
        {
            int possibilities = 1;
            char[] sChars = s.ToCharArray();
            int numBuff;
            int blockSize=0;

            for(int i =0; i < sChars.Length - 1; i++ ) 
            {
                numBuff = Int16.Parse( sChars[i ].ToString() + sChars[i+1].ToString());
                if (numBuff < 27 && numBuff > 9) 
                {
                    blockSize++;
                }
                else
                {
                    if (numBuff < 27 && numBuff > 10 || blockSize > 0) possibilities *= fibonacci(blockSize);
                    blockSize = 0;
                }
            }

            if (blockSize >0) possibilities *= fibonacci(blockSize);

            return possibilities;
        }

        private int fibonacci(int p_index)
        {
            if (p_index == 1) return 2;
            if (p_index == 2) return 3;
            int output1 = 2;
            int output2 = 3;
            for(int i =3; i< p_index+1; i++)
            {
                if (output1 < output2) output1 +=  output2;
                else output2 += output1 ;
            }

            return Math.Max(output1, output2);
        }
    }

}
