using System;
using System.Collections.Generic;


namespace LeetCode_CS.Easy
{
    class LC0001_TwoSum
    {
        public static void runner()
        {

            int[] numz = new int[] { 6, 8, 2, 1, 3, 5, 4, 9, -1, 10, -3 };

            LC0001_TwoSum.QuickSort tester = new LC0001_TwoSum.QuickSort();

            tester.TwoSum(numz, 3);

            foreach (int i in numz)
                Console.Write(i + "|");
        }
        interface ISignature
        {
            int[] TwoSum(int[] nums, int target);
        }
        public class QuickSort : ISignature
        {
            public int[] TwoSum(int[] nums, int target)
            {
                QSort<int>(nums, 0, nums.Length-1);
                Console.WriteLine("INDEX of "+ target + ":" +BinarySearch<int>(target, nums, 0, nums.Length - 1));
                

                return new int[] { -1, -1 };
            }


            private void QSort<T> (T[] p_array, int p_start, int p_end) where T : IComparable<T>
            {
                T swapper;
                int i = p_start;
                int j = p_end;
                int piv= i;

                // find correct index of pivot
                for(int x = i+1; x <=j; x++)
                    if(p_array[x].CompareTo( p_array[i]) ==-1)
                        piv++;

                // place pivot in correct place
                swapper = p_array[i];
                p_array[i] = p_array[piv];
                p_array[piv] = swapper;

                while (i < piv && piv < j)
                {
                    while (p_array[i].CompareTo(p_array[piv]) < 0 ) i++;
                    while (p_array[j].CompareTo(p_array[piv]) > 0) j--;

                    swapper = p_array[i];
                    p_array[i] = p_array[j];
                    p_array[j] = swapper;
                }

                if ((piv - p_start ) > 1) QSort<T>(p_array, p_start, piv - 1);
                if ((p_end - piv ) > 1) QSort<T>(p_array, piv + 1, p_end);

            }

            private int BinarySearch<T>(T p_search, T[] p_array, int p_start, int p_end) where T:IComparable
            {
                
                
                if (p_start > p_end)
                {
                        return -1;
                }

                int mid = (p_start + p_end) / 2;

                switch (p_search.CompareTo(p_array[mid]))
                {
                    case -1:
                        return BinarySearch<T>(p_search, p_array, p_start, mid-1);

                    case 0:
                        return mid;
                        
                    case 1:
                        return BinarySearch<T>(p_search, p_array, mid+1, p_end);
                    
                    default:
                        return -1;
                        
                }
                                               
            }

        }
        public class HashTable: ISignature{
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> search = new Dictionary<int, int>();

                for(int i =0; i<nums.Length; i++)
                {
                    search.Add(nums[i], i);
                    
                    if(search.ContainsKey(target - nums[i])){
                        return new int[] { search[target - nums[i]] , i };
                    }

                }



                return new int[] {-1, -1};
            }
        }

        public class BruteForce: ISignature
        {
            public int[] TwoSum(int[] nums, int target)
            {
                //brute force
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] == (target - nums[j]))
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return new int[] { -1, -1 };
            }
        }
       

    }
}
