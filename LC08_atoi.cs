using System.Collections.Generic;
using System;

namespace LeetCode_CS
{
	public class LC08_atoi
	{
		public static void runner()
        {

			String[] strAR = { "42","   -42", "4193 with words", "words and 987", "-91283472332" };

			foreach (String s in strAR) {
                Console.WriteLine();
				Console.WriteLine(s + "|" + MyAtoi(s)) ;
				
			}

        }


		public static int MyAtoi(string str)
		{

			char[] charAR = str.ToCharArray();
			int i = 0;
			int charVal = 0;
			int outbuff = 0;
			bool numStart = false;
			bool numEnd = false;

            while (!numStart || isNum(charAR[i]))
            {

				if (isNum(charAR[i]))
                {

					outbuff *= 10;
					outbuff += Convert.ToInt32(charAR[i]);

					if(outbuff < 10 && (i > 0 && charAR[i - 1] == '-'))
                    {
						outbuff *= -1;
						numStart = true;
                    }

                }

				i++;
            }



			return 0;
		}

		private static bool isNum(Char p_c)
        {
			if(Int32.Parse(p_c) > 47 && Int32.Parse(p_c) < 58)
            {
				return true;
            }

			return false;
        }
	}

}

