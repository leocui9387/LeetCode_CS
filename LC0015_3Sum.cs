using System;
using System.Collections.Generic;

namespace LeetCode_CS
{
    class LC0015_3Sum
    {
        public static void runner()
        {
            List<int[]> testcases = new List<int[]>();


            testcases.Add(new int[] { 0, -4, -1, -4, -2, -3, 2 });
            testcases.Add(new int[] { 1, 2, -2, -1 });
            testcases.Add(new int[] { 0, 0, 0 });
            testcases.Add(new int[] { -1, 0, 1, 2, -1, -4 });

            IList<IList<int>> tempOut;
            foreach (int[] ia in testcases)
            {
                tempOut = ThreeSum(ia);

                Console.WriteLine("START NEW----------");

                foreach (IList<int> ii in tempOut)
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

        public static IList<IList<int>> ThreeSum(int[] nums)
        {

            if (nums.Length == 0) return new List<IList<int>>();

            Dictionary<int, int> num_count = new Dictionary<int, int>();

            //build dictionary
            foreach (int n in nums)
            {
                if (num_count.ContainsKey(n)) num_count[n]++;
                else num_count.Add(n, 1);

            }

            Array.Sort(nums);
            int seekVal;

            Dictionary<String, threeTuple> result = new Dictionary<string, threeTuple>();
            threeTuple buff;
            // give each 2x2 triangle combination
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums.Length - 1; j > i; j--)
                {
                    

                    seekVal = -(nums[j] + nums[i]);
                    Console.WriteLine("i:" + i + "|j:" + j);
                    Console.WriteLine("Num i:" + nums[i] + "|Num j:" + nums[j] + "|seek:" + seekVal);

                    if (seekVal <= nums[i]) continue;
                    
                    /* if seek value is out of the array's range
                     * TEST FOR MORE OPTIMIZATION
                     */
                    if (nums[nums.Length - 1] < seekVal) j = i; //sortedNums[0] > seekVal ||

                    // if seek value is a duplciate. will be saved for straight pass of sortedNums
                    if (seekVal == nums[i] || seekVal == nums[j]) continue;

                    if (num_count.ContainsKey(seekVal))
                    {

                        buff = new threeTuple(nums[i], nums[j], seekVal);
                        if (!result.ContainsKey(buff.ToString())) result.Add(buff.ToString(), buff);
                    }

                }

            }

            IList<IList<int>> fOut = new List<IList<int>>();

            foreach (threeTuple t in result.Values)
            {
                fOut.Add(t.toList());
            }

            return fOut;
        }
        public static IList<IList<int>> ThreeSum_2(int[] nums)
        {
            //
            if (nums.Length == 0) return new List<IList<int>>();

            Dictionary<int, int> num_count = new Dictionary<int, int>();

            //build dictionary
            foreach (int n in nums)
            {
                if (num_count.ContainsKey(n)) num_count[n]++;
                else num_count.Add(n, 1);

            }

            int[] sortedNums = new int[num_count.Keys.Count];
            num_count.Keys.CopyTo(sortedNums, 0);
            Array.Sort(sortedNums);
            int seekVal;

            Dictionary<String, threeTuple> result = new Dictionary<string, threeTuple>();
            threeTuple buff;
            // give each 2x2 triangle combination
            for (int i = 0; i < sortedNums.Length; i++)
            {
                for (int j = sortedNums.Length - 1; j > i; j--)
                {

                    seekVal = -(sortedNums[j] + sortedNums[i]);
                    Console.WriteLine("i:" + i + "|j:" + j);
                    Console.WriteLine("Num i:" + sortedNums[i] + "|Num j:" + sortedNums[j] + "|seek:" + seekVal);
                    /* if seek value is out of the array's range
                     * TEST FOR MORE OPTIMIZATION
                     */
                    if (sortedNums[sortedNums.Length - 1] < seekVal) j = i; //sortedNums[0] > seekVal ||

                    // if seek value is a duplciate. will be saved for straight pass of sortedNums
                    if (seekVal == sortedNums[i] || seekVal == sortedNums[j]) continue;

                    if (num_count.ContainsKey(seekVal))
                    {

                        buff = new threeTuple(sortedNums[i], sortedNums[j], seekVal);
                        if (!result.ContainsKey(buff.ToString())) result.Add(buff.ToString(), buff);
                    }

                }

            }

            foreach (int i in sortedNums)
            {
                if (num_count[i] < 2) continue;
                seekVal = -2 * i;

                num_count[i] -= 2;

                if (num_count.ContainsKey(seekVal) && num_count[seekVal] > 0)
                {
                    buff = new threeTuple(i, i, seekVal);
                    if (!result.ContainsKey(buff.ToString())) result.Add(buff.ToString(), buff);
                }

                num_count[i] += 2;

            }


            IList<IList<int>> fOut = new List<IList<int>>();

            foreach (threeTuple t in result.Values)
            {
                fOut.Add(t.toList());
            }

            return fOut;
        }

        class threeTuple : IComparable<threeTuple>
        {
            int[] g { get; }
            private String str;
            public threeTuple(int p_first, int p_second, int p_third)
            {
                g = new int[] { p_first, p_second, p_third };
                Array.Sort(g);
            }

            public List<int> toList()
            {
                return new List<int>(g);
            }

            public override String ToString()
            {
                if (str is null) str = g[0] + "," + g[1] + "," + g[2];
                return str;
            }


            public int CompareTo(threeTuple p_in)
            {
                int outComp;

                for (int i = 0; i < g.Length; i++)
                {
                    outComp = g[i].CompareTo(p_in.g[i]);
                    if (outComp != 0) return outComp;
                }

                return 0;
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

                for (int j = uniqz.Length - 1; j > -1; j--)
                {

                    if (num_count[uniqz[j]] == 0 || uniqz[j] < n) continue;
                    Console.WriteLine("- m:" + uniqz[j]);
                    num_count[uniqz[j]]--;
                    seekVal = -uniqz[j] - n;
                    Console.WriteLine("- seek:" + seekVal);

                    if (seekVal < uniqz[0]) continue;

                    if (num_count.ContainsKey(seekVal) && num_count[seekVal] > 0)
                    {
                        sortBuff = new int[] { n, uniqz[j], seekVal };
                        leadSort(sortBuff);
                        keyStr = sortBuff[0] + "," + sortBuff[1] + "," + sortBuff[2];
                        Console.WriteLine(keyStr);
                        if (!result.ContainsKey(keyStr))
                            result.Add(keyStr, new List<int>(sortBuff));
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

                for (int i = 1; i < p_arr.Length; i++)
                {
                    if (p_arr[i - 1] > p_arr[i])
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
