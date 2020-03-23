using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0152_MaxProdSubArr
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            //tc.Add(new int[] {2,1,1, -1,3});

            //tc.Add(new int[] { 2,-1, 2, 3, -2, 4,-1, 1,12,3,4,5,-1,-1,-1,1 });
            //tc.Add(new int[] { -2, 0, -1 });
            tc.Add(new int[] { -4, -3, -2});
            //tc.Add(new int[] { });

            foreach (int[] c in tc)
            {
                Console.WriteLine("NEW CAST ++++++++++++++++++++");
                Utility.PrintIterable<int>(c);
                Console.WriteLine(MaxProduct(c));
                Console.WriteLine("END +++++++++++++++++++++++++");
            }

        }
        public static int MaxProduct(int[] nums)
        {
            int i = 0;
            int max = MaxProd_Neg(nums, 0, out i);

            int buff;
            for (; i< nums.Length;i++)
            {
                buff = MaxProd_Neg(nums, i, out i);
                if (max < buff) max = buff;
                
            }

            return max;
        }

        private static int MaxProd_Neg(int[] p_arr,int p_start, out int p_end)
        {

            Stack<int?> negz = new Stack<int?>();
            int? negSubArray = null;

            int pL = p_arr.Length;
            for(p_end = p_start; p_end < pL && p_arr[p_end] != 0; p_end++)
            {

                if (p_arr[p_end] == 0) break;

                if (p_arr[p_end] < 0)
                {

                    /* three conditions: 
                     *      BASE CASE
                     *      1) initial : always push negSubArray to retain PN?NP stack
                     *      
                     *      INDUCTIVE CASE
                     *      2) positive: do the while loop
                     *      3) negative: do while loop but don't push negSubArray
                     */
                    int? buff;
                    while (negz.Count > 2) 
                    {
                        buff = negz.Pop();
                        if (buff is null) continue;
                        negSubArray = (negSubArray is null) ?  buff : negSubArray * buff;
                        
                    }
                    negz.Push(negSubArray);
                    negz.Push(p_arr[p_end]);
                    negSubArray = null;

                    Utility.PrintIterable<int?>(negz);
                    Console.WriteLine("nsa" + negSubArray);

                    continue;

                }

                negSubArray = (negSubArray is null) ? p_arr[p_end] : negSubArray * p_arr[p_end];
                
            }

            if (negSubArray != null) negz.Push(negSubArray);
 
            Console.WriteLine("Print: Negz");
            Utility.PrintIterable<int?>(negz);

            return MaxProd_Neg_Eval(negz);
        }
        private static int MaxProd_Neg_Eval(Stack<int?> p_stk)
        {

            /* CASES
             * 1: all positive
             * 2: ends in negative and there's only one negative
             * 3: one negative, ends with a positive
             * 4: at least 2 negatives. possible +1 if middle is negative, ends 2 negatives
             * 5: ends with positive, 2 negatives with +1 if middle is negative
             * 
             * MAX
             * 2: the first item unless only one negative
             * 3: compare first or second
             * 
             * 4,5: get middle number
             *  - if negative: smallest of two wings times middle
             *  - if positive: return total product
             *  - if null : total product
             */

            int negCount = p_stk.Count;
            if (negCount == 0) return 0;
            int? max = null;

            
            if( negCount < 4)
            {
                foreach(int? i in p_stk)
                {
                    if (i is null) continue;
                    if (max is null || max < i) max = i;
                }
            }
            else{

                int?[] arr = new int?[negCount];
                
                for (int i = negCount - 1; i > -1; i--) arr[i] = p_stk.Pop();

                if (arr[2] is null || arr[2] > 0)
                {
                    foreach (int? i in arr)
                    {
                        if (i is null) continue;

                        if (max is null) max = i;
                        else max *= i;
                    }
                }
                else
                {
                    int lWing = 1;
                    for(int i =0; i<2; i++)
                    {
                        if (arr[i] is null) continue;
                        lWing *= (int) arr[i];
                    }

                    int rWing = 1;
                    for (int i = 3; i < negCount; i++)
                    {
                        if (arr[i] is null) continue;
                        rWing *= (int)arr[i];
                    }

                    if (lWing < rWing) return (int)arr[2] * lWing;
                    else return (int)arr[2] * rWing;
                }

            }
            return (int) max;
        }

        public static int MaxProduct_0Messy(int[] nums)
        {
            // brute force

            int nL = nums.Length;
            int? zeroSubArray= null;
            int max = nums[0];

            Stack<int?> negz = new Stack<int?>();
            int? negSubArray = null;



            List<int?> totalz = new List<int?>();

            for(int i=0; i<nL; i++)
            {

                if (nums[i] > max) max = nums[i];
                
                if(nums[i] == 0)
                {
                    if(zeroSubArray != null) totalz.Add(zeroSubArray);
                    zeroSubArray = null;
                    negz.Clear();
                    continue;
                }
                if (nums[i] < 0)
                {

                    if (negz.Count > 2)
                    {
                        // if sub array is null, 

                        if (zeroSubArray is null) zeroSubArray = nums[i];
                        else
                        {
                            while(negz.Count > 2) { zeroSubArray *= negz.Pop(); }
                            negz.Push(zeroSubArray);
                            negz.Push(nums[i]);
                        }
                        
                        
                    } else if (negz.Count == 0)
                    {
                        negz.Push(negSubArray);
                        negz.Push(nums[i]);
                        negSubArray = null;
                        continue;
                    } 


                }
                if(negSubArray is null) negSubArray = nums[i];
                else negSubArray *= nums[i];

                if(zeroSubArray is null) zeroSubArray = nums[i];
                else zeroSubArray *= nums[i];


                Utility.PrintIterable<int?>(negz);
            }

            totalz.Add(zeroSubArray);
            if(negSubArray != null) negz.Push(negSubArray);

            Console.WriteLine("Print: Negz");
            Utility.PrintIterable<int?>(negz);
            Console.WriteLine("Print totalz");
            Utility.PrintIterable<int?>(totalz);
            return 0;
        }

    }
}
