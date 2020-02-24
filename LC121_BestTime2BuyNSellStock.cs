using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CS
{
    class LC121_BestTime2BuyNSellStock
    {
        public static void runner()
        {
            Random rand = new Random();

            const int len = 20;

            int[] price_array = new int[len];
            for (int i = 0; i < len; i++)
            {
                price_array[i] = rand.Next(1, 20);
                Console.WriteLine("Time:" + i + "|Price:" + price_array[i]);

            }

            // make unit test for last item case
            price_array[price_array.Length-1] = price_array[0];

            Console.WriteLine("Max Profit:" + LC121_BestTime2BuyNSellStock.MaxProfit(price_array));

        }

        public static int MaxProfit(int[] prices)
        {
            QuickSort<int>(prices, 0, prices.Length - 1);

             Lookup<int, int> price_time = prices.ToLookup(price => );

            for (int i = 0; i < prices.Length; i++)
            {
                price_time.Add(prices[i], i);
            }

            


            foreach(int i in prices)
            {
                Console.WriteLine("Sorted Prices:" +i);
            }

            return 0;
        }

        private static void QuickSort<T>(T[] p_InArray, int p_beg, int p_end) where T : IComparable<T> {

            int init_position = p_beg;
            int dupz = 0;
            
            for (int k = p_beg + 1; k <= p_end; k++)
            {
                
                if (p_InArray[p_beg].CompareTo(p_InArray[k]) > 0)
                {
                    init_position++;
                }
                    
                if (p_InArray[p_beg].CompareTo(p_InArray[k]) == 0)
                    dupz++;
                //Console.WriteLine("index(" + k + "): " + p_InArray[k] + "|init:" + init_position + "|dupz:" + dupz);
            }

            Swapper<T>(p_InArray, p_beg, init_position);
                        
            // normal quick sort
            int i = p_beg;
            int j = p_end;
            int dup_index = 1;

            while ((i + dupz) < j)
            {
                // find LEFT
                while (p_InArray[i].CompareTo(p_InArray[init_position]) < 1 && i < init_position)
                {
                    //Console.WriteLine("item " + i + ":" + p_InArray[i] +"|init position:" + init_position + "|dup index" + dup_index );
                    if (p_InArray[i].CompareTo(p_InArray[init_position]) == 0)
                    {

                        Swapper<T>(p_InArray,i, init_position + dup_index);
                        dup_index++;
                        continue;
                    }
                    i++;
                }
                    
                
                // find RIGHT
                while (p_InArray[j].CompareTo(p_InArray[init_position]) > -1 && j > (init_position + dupz))
                {
                    if (p_InArray[j].CompareTo(p_InArray[init_position]) == 0)
                    {
                        Swapper<T>(p_InArray,j, init_position + dup_index);
                        dup_index++;
                        continue;
                    }
                    j--;
                }
                
                //swap
                if ((i + dupz) < j){
                    Swapper<T>(p_InArray, j, i);
                }

                // recurse
                if(init_position != p_beg)
                {
                    QuickSort<T>(p_InArray, p_beg, init_position -1);
                }
                if (init_position + dupz != p_end)
                {
                    QuickSort<T>(p_InArray, init_position + dupz + 1 , p_end);
                }

                //safety
                //Console.WriteLine("LEO");
                
            }


        }

        private static void Swapper<T>(T[] p_array, int p_one, int p_two){
            T buffer = p_array[ p_one];
            p_array[p_one] = p_array[p_two];
            p_array[p_two] = buffer;
        }

    }
}
