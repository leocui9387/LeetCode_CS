using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CS.Easy
{
    class LC121_BestTime2BuyNSellStock
    {
        public static void runner()
        {

            /*
            Random rand = new Random();

            const int len = 20;

            int[] price_array = new int[len];
            for (int i = 0; i < len; i++)
            {
                price_array[i] = rand.Next(1, 20);
                Console.WriteLine("Time:" + i + "|Price:" + price_array[i]);

            }
            */
            // make unit test for last item case
            //price_array[price_array.Length-1] = price_array[0];

            int[] price_array = {1,2};//{ 7,1,5,3,6,4};//{9,8,7,6,5,4,3,2,1 };   //{ 0,0,0,0,0,0,0,0};

            Console.WriteLine("Max Profit:" + LC121_BestTime2BuyNSellStock.MaxProfit(price_array));

        }

        public static int MaxProfit(int[] prices)
        {
            // straight walk. based on miniums separating the array into blocks
            if (prices.Length < 1) return 0;

            int min = prices[0];
            int max = prices[0];
            int pi = 0;

            for(int i=0; i < prices.Length; i++)
            {
                if (prices[i] > max) max = prices[i];
                if (prices[i] < min)
                {
                    if (pi < (max - min)) pi = max - min;
                    min = prices[i];
                    max = prices[i];
                }

            }
            if (pi < (max - min)) pi = max - min;
            return pi;
        }


        public static int MaxProfit_withCalc(int[] prices)
        {

            if (prices.Length < 2) return 0;

            // find max and min

            Dictionary<int, List<int>> max_price_time = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> min_price_time = new Dictionary<int, List<int>>();

            int t_0 = 0;
            int t_1 = 0;

            t_0 = prices[1].CompareTo(prices[0]);

            // handle first point derivative
                min_price_time.Add(prices[0], new List<int>());
                min_price_time[prices[0]].Add(0);


            for (int i = 1; i< prices.Length - 1 ; i++)
            {
                Console.WriteLine("price i+1: {0}|price i: {1}", prices[i + 1], prices[i]);
                t_1 = prices[i+1].CompareTo(prices[i]);

                if(t_0 < 0 && t_1 > 0)
                {
                    //min
                    if (!min_price_time.ContainsKey(prices[i]))
                    {
                        min_price_time.Add(prices[i], new List<int>());
                    }
                    min_price_time[prices[i]].Add(i);
                   

                } else if (t_0 > 0 && t_1 < 0)
                {
                    //max
                    if (!max_price_time.ContainsKey(prices[i]))
                    {
                        max_price_time.Add(prices[i], new List<int>());
                    }
                    max_price_time[prices[i]].Add(i);

                }


                if (t_1 != 0)
                {
                    t_0 = t_1;
                }
                
            }

            
            // handle last point derivative

            if (!max_price_time.ContainsKey(prices[prices.Length - 1]))
            {
                max_price_time.Add(prices[prices.Length - 1], new List<int>());
            }
            max_price_time[prices[prices.Length - 1]].Add(prices.Length - 1);


            if (min_price_time.Count == 0 || max_price_time.Count == 0) return 0;
            

            List<KeyValuePair<int, List<int>>> buyPoints = (from kvp in min_price_time 
                                                           orderby kvp.Key ascending
                                                           select kvp).ToList();


            List<KeyValuePair<int, List<int>>> potentialSales = (from kvp in max_price_time
                                                                 orderby kvp.Key descending
                                                                 select kvp).ToList() ;

            int max = 0;
            foreach (KeyValuePair<int, List<int>> kvp in buyPoints)
            {
                foreach (KeyValuePair<int, List<int>> kvp_sales in potentialSales.Where(x => (x.Key > kvp.Key && kvp.Value.Min() < x.Value.Max())))
                {
                    if (max < (kvp_sales.Key - kvp.Key))
                    {
                        max = kvp_sales.Key - kvp.Key;
                    }
                    else break;
                    
                }

            }






            return max;
        }

        public static int MaxProfit_NonCalculus(int[] prices)
        {
            // feel old, but also.. Calc 1/2 was jr of high school... so 15 years ago !!!

            Dictionary<int, List<int>> price_time = new Dictionary<int, List<int>>(); //PRICE, TIME 

            for (int i = 0; i < prices.Length; i++)
            {
                if (!price_time.ContainsKey(prices[i]))
                {
                    price_time.Add(prices[i], new List<int>());
                }
                price_time[prices[i]].Add(i);
            }

            // print out price_time
            foreach(KeyValuePair<int, List<int>> l in price_time){
                Console.Write("key:" + l.Key + "|List:");
                l.Value.ForEach(x => Console.Write(x + ","));
                Console.WriteLine();
                
            }

            //Array.Sort(prices);
            
            QuickSort<int>(prices, 0, prices.Length - 1);


            //QUESTION: Best way to get distinct sorted list from unsorted list with duplicates?

            foreach (int i in prices)
            {
                Console.WriteLine("Sorted Prices:" +i);
            }
            
            int[] dPrices = prices.Distinct<int>().ToArray();
            //Array.Sort(dPrices);
            int max = 0;


            /***************
             * Readable-est. Leverage the work of others... Very slow
             ***************
            List<KeyValuePair<int, List<int>>> potentialSales;
            for(int i = 0; i< dPrices.Length; i++)
            {
                potentialSales = price_time.Where(x => (x.Key > dPrices[i]) && (x.Value.Max() > price_time[dPrices[i]].Min()) ).ToList();

                foreach(KeyValuePair<int, List<int>> kvp in potentialSales)
                {
                    if(max < (kvp.Key - dPrices[i]))
                    {
                        max = (kvp.Key - dPrices[i]);
                    }
                }

            }
            */





            /************
             * LAZY ALGO: Brute force
             ************
            //iterate through each buying point

            for(int i = 0; i< dPrices.Length; i++ )
            {
                for(int j= dPrices.Length-1; j > i; j--)
                {
                    
                }
            }
            */

            /*********
            BAD ALGO 1: Tried some level of bi-directional bredth first search. Not theoretically sound because .
            **********
            int buyIndex = 0;
            int sellIndex = dPrices.Length - 1;

            //get most opportune time of lowest and highest price
            int buyTime = price_time[dPrices[buyIndex]].Min();
            int sellTime = price_time[dPrices[sellIndex]].Max(); 

            while (buyIndex < sellIndex)
            {

                Console.WriteLine("Buy[Time:" + buyTime + "|Price:" + dPrices[buyIndex] +"]  Sell[Time: "+ sellTime +"|Prices " + dPrices[sellIndex] + "]");
                if(buyTime < sellTime)
                {
                    return dPrices[sellIndex] - dPrices[buyIndex];
                }

                // prepare next iteration. Determine which index to move forward

                // price change on buy side greater than price change on sell side
                Console.WriteLine("dBuy:" + (dPrices[buyIndex + 1] - dPrices[buyIndex]) );
                Console.WriteLine("dSell:" +(dPrices[sellIndex] - dPrices[sellIndex - 1]));
                if ((dPrices[buyIndex + 1 ] - dPrices[buyIndex]) > (dPrices[sellIndex] - dPrices[sellIndex - 1]))
                {
                    sellIndex--;
                    sellTime = price_time[dPrices[sellIndex]].Max();
                }
                else
                {
                    buyIndex++;
                    buyTime = price_time[dPrices[buyIndex]].Min();
                }
            }
            */

            return max;
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
