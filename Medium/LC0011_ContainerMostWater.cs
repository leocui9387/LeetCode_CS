using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0011_ContainerMostWater
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 1, 3, 2, 5, 25, 24, 5 });
            tc.Add(new int[] { 2, 3, 4, 5, 18, 17, 6 });
            tc.Add(new int[] { 8,10,14,0,13,10,9,9,11,11 });
            tc.Add(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            tc.Add(new int[] { 1,2,1 });
            


            //tc.Add(new int[] { });

            foreach (int[] c in tc)
            {
                Console.WriteLine("NEW CAST ++++++++++++++++++++");
                Utility.PrintIterable<int>(c);
                Console.WriteLine(MaxArea(c));
                Console.WriteLine("END +++++++++++++++++++++++++");
            }
        }
        public static int MaxArea(int[] height) {

            int i = 0;
            int j = height.Length - 1;

            int area;
            int max = 0;

            do
            {
                area = (j - i);
                if (height[i] < height[j]) area *= height[i];
                else area *= height[j];


                if (max < area) max = area;

                //Console.WriteLine(area);


                if (height[i] < height[i + 1] || height[i] < height[j]) { i++; }
                else { j--; }

                //Console.WriteLine("i:" + i + "|j:" + j + "|area:" + area);

            } while (i < j);

            return max;
        }
        public static int MaxArea_1(int[] height)
        {

            /* 
             * calculate max potential
             * calculate min loss
             * 
             */

            int hL = height.Length;
            int areaBuff;
            // max potential 

            Dictionary<int, int> AreaIndex = new Dictionary<int, int>();
            

            
            for (int i = hL - 1, j=0; i > -1; i--, j++)
            {
                
                areaBuff = i * height[i];
                if (!AreaIndex.ContainsKey(areaBuff)) AreaIndex.Add(areaBuff, i);

                areaBuff = -(hL - 1 - j) * height[j];
                if (!AreaIndex.ContainsKey(areaBuff)) AreaIndex.Add(areaBuff, j);
            }

            SortedList<int, int> AI = new SortedList<int, int>(AreaIndex);
           
            // max retention
            /*
            for (int i = 0; i < hL; i++)
            {
                areaBuff = -(hL - 1 - i) * height[i];
                if (!retention_AreaIndex.ContainsKey(areaBuff)) retention_AreaIndex.Add(areaBuff, i);

            }
            */

            Console.WriteLine("POTENTIAL");

            foreach (KeyValuePair<int, int> kvp in AI)
            {
                Console.Write("KEY:" + kvp.Key + "|VAL:" + kvp.Value);
                Console.WriteLine();
            }
            /*
            Console.WriteLine("RETENTION");
            foreach (KeyValuePair<int, int> kvp in rAI)
            {
                Console.Write("KEY:" + kvp.Key + "|VAL:" + kvp.Value);
                Console.WriteLine();
            }
            */
            // iterate through retention/potential based on which next step has the highest value

            int max = 0;

            int r = 0, p = AreaIndex.Count - 1;
            int rIndex, pIndex;

            
            while (max > -AI.Keys[p] && -max > AI.Keys[r])
            {
                rIndex = AI.Values[r];
                pIndex = AI.Values[p];

                areaBuff = Math.Min(height[rIndex], height[pIndex]) * Math.Abs(pIndex - rIndex);

                Console.WriteLine("p:" + p + "|r:" + r + "|area:" + areaBuff);
                if (max < areaBuff) max = areaBuff;

                if (AI.Values[r + 1] < AI.Values[r]) r++;
                else if (-AI.Keys[r] > AI.Keys[p]) r++;
                else p--;

                Console.WriteLine("p:" + p + "|r:" + r + "|area:" + areaBuff);

            }

            

            return max;
        }

        public static int MaxArea_0(int[] height)
        {

            /* 
             * calculate max potential
             * calculate min loss
             * 
             */

            int hL = height.Length;
            int areaBuff;
            // max potential 
            int[] pArea = new int[hL];
            Dictionary<int, int> potential_AreaIndex = new Dictionary<int, int>();
            for (int i = hL-1; i > -1; i--) 
            {
                areaBuff = -i* height[i];
                pArea[i] = areaBuff;
                if (!potential_AreaIndex.ContainsKey(areaBuff)) potential_AreaIndex.Add(areaBuff,i);
                
            }

            // max retention
            Dictionary<int, int> retention_AreaIndex = new Dictionary<int, int>();
            int[] rArea = new int[hL];
            for (int i = 0 ; i < hL; i++) 
            {
                areaBuff = -(hL-1 - i) * height[i];
                rArea[i] = areaBuff;
                if (!retention_AreaIndex.ContainsKey(areaBuff)) retention_AreaIndex.Add(areaBuff, i);
                
            }

            Console.WriteLine("POTENTIAL");

            foreach(KeyValuePair<int, int> kvp in potential_AreaIndex)
            {
                Console.Write("KEY:" + kvp.Key + "|VAL:"+ kvp.Value);
                Console.WriteLine();
            }
            Console.WriteLine("RETENTION");
            foreach (KeyValuePair<int, int> kvp in retention_AreaIndex)
            {
                Console.Write("KEY:" + kvp.Key + "|VAL:" + kvp.Value);
                Console.WriteLine();
            }

            // iterate through retention/potential based on which next step has the highest value

            int max = 0;

            Array.Sort(rArea);
            Console.WriteLine("Retention");
            Utility.PrintIterable<int>(rArea);

            Array.Sort(pArea);
            Console.WriteLine("Potential");
            Utility.PrintIterable<int>(pArea);

            int r = 0, p = 0;
            int rIndex, pIndex;

            while(-max > rArea[r] && -max > pArea[p])
            {
                rIndex = retention_AreaIndex[rArea[r]];
                pIndex = potential_AreaIndex[pArea[p]];

                areaBuff = Math.Min(height[rIndex],height[pIndex]) * Math.Abs(pIndex - rIndex);

                Console.WriteLine("p:" + p + "|r:" + r + "|area:" + areaBuff);
                if (max < areaBuff) max = areaBuff;

                if (retention_AreaIndex[rArea[r + 1]] < retention_AreaIndex[rArea[r]]) r++;
                else if (rArea[r] < pArea[p]) r++;
                else p++;

                Console.WriteLine("p:" + p + "|r:" + r + "|area:" + areaBuff);

            }
            


            return max;
        }

    }
}
