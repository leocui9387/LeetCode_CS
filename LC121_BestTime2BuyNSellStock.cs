using System;
using System.Collections.Generic;
using System.Text;

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
                price_array[i] = rand.Next(1, 5);
                Console.WriteLine("Time:" + i + "|Price:" + price_array[i]);

            }

            // make unit test for last item case
            price_array[price_array.Length-1] = price_array[0];

            Console.WriteLine("Max Profit:" + LC121_BestTime2BuyNSellStock.MaxProfit(price_array));

        }

        public static int MaxProfit(int[] prices)
        {
            QuickSort<int>(prices, 0, prices.Length - 1);

            Dictionary<int, int> price_time = new Dictionary<int, int>();

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
            int i;

            

            for (i = p_beg + 1; i <= p_end; i++)
            {
                if (p_InArray[p_beg].CompareTo(p_InArray[i]) > 0)
                    init_position++;

                if (p_InArray[p_beg].CompareTo(p_InArray[i]) == 0)
                    dupz++;
                Console.WriteLine("index:" +i+ "|init:" + init_position + "|dupz:" + dupz);
            }

            Swapper<T>(p_InArray[p_beg], p_InArray[p_beg + init_position]);

            // normal quick sort
            i = p_beg;
            int j = p_end;
            int dup_index = 1;

            while ((i + dupz) < j)
            {
                // find LEFT
                while (p_InArray[i].CompareTo(p_InArray[init_position]) < 1)
                {
                    Console.WriteLine("item " + i + ":" + p_InArray[i] +"|init position:" + init_position + "|dup index" + dup_index );
                    if (p_InArray[i].CompareTo(p_InArray[init_position]) == 0)
                    {

                        Swapper<T>(p_InArray[i], p_InArray[init_position + dup_index]);
                        dup_index++;
                        continue;
                    }
                    i++;
                }
                    
                
                // find RIGHT
                while (p_InArray[j].CompareTo(p_InArray[init_position]) > -1)
                {
                    if (p_InArray[j].CompareTo(p_InArray[init_position]) == 0)
                    {
                        Swapper<T>(p_InArray[j], p_InArray[init_position + dup_index]);
                        dup_index++;
                        continue;
                    }
                    j--;
                }
                    
                
                
                //deal with dup
                
                

                //swap
                if ((i + dupz) < j){
                    Swapper<T>(p_InArray[j], p_InArray[i]);
                }

                //safety
                Console.WriteLine("LEO");

            }


        }

        private static void Swapper<T>(T p_one, T p_two){
            T buffer = p_one;
            p_one = p_two;
            p_two = buffer;
        }

    }
}
