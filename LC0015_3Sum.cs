using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS
{
    class LC0015_3Sum
    {
        public static void runner()
        {
            List<int[]> testcases = new List<int[]>();

            testcases.Add(new int[] { 0,0,0 });
            testcases.Add(new int[] { -1, 0, 1, 2, -1, -4 });

            IList<IList<int>> tempOut;
            foreach(int[] ia in testcases)
            {
                tempOut = ThreeSum(ia);

                Console.WriteLine("START NEW----------");

                foreach(IList<int> ii in tempOut)
                {
                    Console.WriteLine("   [");
                    Console.Write("[");
                    foreach (int i in ii)
                    {
                        Console.Write(i + ",");
                    }
                    Console.Write("]");
                    Console.WriteLine("   ]");
                }


                Console.WriteLine("END OLD -----------");

            }

        }

        public static IList<IList<int>> ThreeSum_1(int[] nums)
        {
            //brute force
            Array.Sort(nums);
            
            Dictionary<String, List<int>> result = new Dictionary<String, List<int>>();
            Dictionary<int, int> num_count = new Dictionary<int, int>();
            
            //build dictionary
            foreach (int n in nums)
            {
                if (num_count.ContainsKey(n))
                {
                    num_count[n]++;
                }
                else
                {
                    num_count.Add(n, 1);
                }
            }
            
            int seekVal;
            int[] uniqz = new int[num_count.Keys.Count];
            num_count.Keys.CopyTo(uniqz, 0);

            int[] sortBuff;
            String keyStr;
            // run thru each so u can 2 sum the list
            foreach (int n in uniqz)
            {
                Console.WriteLine(n);
                num_count[n]--;

                for(int j = uniqz.Length -1; j >-1; j--)
                {
                    
                    if (num_count[uniqz[j]] == 0 || uniqz[j] < n) continue;
                    Console.WriteLine("- m:" + uniqz[j]);
                    num_count[uniqz[j]]--;
                    seekVal = -uniqz[j] - n;
                    Console.WriteLine("- seek:" + seekVal);

                    if (seekVal < uniqz[0]) continue;

                    if (num_count.ContainsKey(seekVal) && num_count[seekVal] > 0 )
                    {
                        sortBuff = new int[] { n, uniqz[j], seekVal };
                        leadSort(sortBuff);
                        keyStr = sortBuff[0] + "," + sortBuff[1] + "," + sortBuff[2];
                        Console.WriteLine(keyStr);
                        if(!result.ContainsKey(keyStr))
                            result.Add(keyStr  , new List<int>(sortBuff));
                    }


                    num_count[uniqz[j]]++;
                }


                num_count[n]++;
            }


            

            return new List<IList<int>>(result.Values);
        }

        private static void leadSort(int[] p_arr)
        {
            
            int buff;

            bool triggered = true;

            while (triggered)
            {
                triggered = false;

                for( int i =1; i< p_arr.Length; i++){
                    if (p_arr[i - 1] > p_arr[i] )
                    {
                        triggered = true;
                        buff = p_arr[i];
                        p_arr[i] = p_arr[i - 1];
                        p_arr[i - 1] = buff;
                    }
                }
                
              
            }



        }



    }
}
