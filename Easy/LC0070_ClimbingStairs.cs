using System;

namespace LeetCode_CS.Easy
{
    class LC0070_ClimbingStairs
    {
        public static void runner()
        {
            int[] tc = new int[] {4,5,6,7};
            
            foreach(int c in tc)
            {

                Console.WriteLine("CASE: " + c);
                Console.WriteLine("answer:" + ClimbStairs(c));
                Console.WriteLine("END--------");

            }

        }
        public static int ClimbStairs(int n) {

            int left=0, right=1;

            for(int i = 0;  i< n; i++)
            {

                if (left < right) left += right ;
                else right += left ;

            }

            return left<right ? right:  left;
        }
        public static int ClimbStairs_dynamic(int n) 
        {
            int oneZ = n % 2;
            int final = 1;
            int positions = n / 2 + oneZ;
            

            if (oneZ != 0) { final = positions; }

            long num = final;
            while (positions <= n)
            {
                oneZ += 2;
                positions++;


                Console.WriteLine($"positions|{positions}");
                Console.WriteLine($"flip position|{positions - oneZ}");
                Console.WriteLine($"ones|{oneZ}");

                num = num * positions * (positions - oneZ+1) / (oneZ * (oneZ - 1));
                Console.WriteLine($"num|{num}");
                Console.WriteLine("----------------------------------------------");
                final += (int)num;
            }

            return final;

        }

        public static int ClimbStairs_BF2(int n)
        {
            // combined the inner for loops
            int twoZ = n / 2;
            int oneZ = n % 2;

            int final = 0;

            int positions = twoZ + oneZ;

            // base case, there are no oneZ, i.e. n is even
            if (oneZ == 0) final++;
            if (oneZ == 1) { final = positions; }
            //based one 1 as the main thing to look at

            double num;

            while (twoZ > 0)
            {
                //Console.WriteLine($"START|i:{i}|tierPositions:{tierPositions}|positions:{positions}|orders:{orders}|final:{final}");

                twoZ--;
                oneZ += 2;

                positions = twoZ + oneZ;
                num = 1;

                Console.WriteLine($"positions:{positions}|onez:{oneZ}");
                for (int i = positions, j = 1; (positions - i) < oneZ; i--, j++)
                {

                    Console.WriteLine($"i:{i}|j:{j}");

                    num *= i;
                    if (j <= oneZ)
                    {
                        num /= j;
                    }
                }

                Console.WriteLine($"num:{num}");

                final += (int) num ;

                //Console.WriteLine($"END|i:{i}|tierPositions:{tierPositions}|positions:{positions}|orders:{orders}|final:{final}");

            }

            return final;
        }



        public static int ClimbStairs_BruteForce(int n)
        {

            int twoZ = n / 2;
            int oneZ = n % 2;

            int final = 0;
            
            int positions = twoZ + oneZ;

            // base case, there are no oneZ, i.e. n is even
            if (oneZ == 0) final++;
            if (oneZ == 1) { final = positions; }
            //based one 1 as the main thing to look at

            int num, denom;

            while(twoZ > 0)
            {
                //Console.WriteLine($"START|i:{i}|tierPositions:{tierPositions}|positions:{positions}|orders:{orders}|final:{final}");

                twoZ--;
                oneZ += 2;

                positions = twoZ + oneZ;
                num = denom = 1;

                Console.WriteLine($"positions:{positions}|onez:{oneZ}");
                for (int i = positions; (positions - i) < oneZ; i--) 
                { 
                    num *= i; 
                }
                
                for(int i = 1; i <= oneZ; i++) { denom *= i; }
                
                Console.WriteLine($"num:{num}|denom:{denom}");

                final += num / denom;

                //Console.WriteLine($"END|i:{i}|tierPositions:{tierPositions}|positions:{positions}|orders:{orders}|final:{final}");
                
            }

            return final;
        }

    }
}
