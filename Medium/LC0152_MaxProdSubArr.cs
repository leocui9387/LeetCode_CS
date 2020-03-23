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
            tc.Add(new int[] { 2, -1, 3});
            tc.Add(new int[] { 2,-1, 2, 3, -2, 4,-1, 1,12,3,4,5,-1,-1,-1,1 });
            tc.Add(new int[] { -2, 0, -1 });
            //tc.Add(new int[] { });

            foreach(int[] c in tc)
            {
                Console.WriteLine("NEW CAST ++++++++++++++++++++");
                Utility.PrintIterable<int>(c);
                Console.WriteLine(MaxProduct(c));
                Console.WriteLine("END +++++++++++++++++++++++++");
            }

        }
        public static int MaxProduct(int[] nums)
        {
            int i;
            Console.WriteLine(MaxProd_Neg(nums , 0 , out i));
            Console.WriteLine(i);
            return 0;
        }

        private static int? MaxProd_Neg(int[] p_arr,int p_start, out int p_end)
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
                    if (negz.Count > 1)
                    {
                        // if sub array is null, 

                        if (negSubArray is null) negSubArray = p_arr[p_end];
                        else
                        {
                            while (negz.Count > 2) { negSubArray *= negz.Pop(); }
                            
                            /*
                            negz.Push(negSubArray);
                            negz.Push(p_arr[p_end]);
                            negSubArray = null;
                            continue;
                            */
                        }


                    }
                    else if (negz.Count == 0)
                    {
                        /*
                        negz.Push(negSubArray);
                        negz.Push(p_arr[p_end]);
                        negSubArray = null;
                        continue;
                        */
                    }

                    negz.Push(negSubArray);
                    negz.Push(p_arr[p_end]);
                    negSubArray = null;

                }

                if (negSubArray is null) negSubArray = p_arr[p_end];
                else negSubArray *= p_arr[p_end];

            }

            if (negSubArray != null) {
                negz.Push(negSubArray);
            }




            Console.WriteLine("Print: Negz");
            Utility.PrintIterable<int?>(negz);

            return 0;
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
