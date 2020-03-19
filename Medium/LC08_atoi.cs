using System.Collections.Generic;
using System;

namespace LeetCode_CS
{
	public class LC08_atoi.Medium
	{
		public static void runner()
        {

			String[] strAR = { "0-1", "-   234", "-2147483649", "-2147483648","-2147483647", "2147483646", "   +0 123", "   -42", "42", "4193 with words", "words and 987", "-91283472332", "+-2" };

			foreach (String s in strAR) {
                Console.WriteLine();
				Console.WriteLine(s + "|" + MyAtoi(s)) ;
				
			}

        }


		public static int MyAtoi(string str)
		{

			if (str.Length == 0) return 0;

			char[] charAR = str.ToCharArray();
			int i = 0;
			int charVal;
			int outbuff = 0;
			bool isNegative = false;
			int isPlusMinus = 0;
			bool numStart = false;

			while ( i < str.Length )
            {
				charVal = charAR[i];
				switch (charVal)
				{

					case int n when n > 47 && n < 58: // is numeric
						numStart = true;
						if (outbuff >= Int32.MaxValue / 10)
						{
							if (outbuff == Int32.MaxValue / 10)
							{

								if (isNegative && charVal > 55) return Int32.MinValue;
								if (!isNegative && charVal > 54) return Int32.MaxValue;
							}
							else
							{
								return isNegative ? Int32.MinValue : Int32.MaxValue;

							}

						}


						outbuff = outbuff * 10 + charVal -48;

						if (outbuff < 10 && (i > 0 && charAR[i - 1] == '-')) isNegative = true;

						break;

					case int n when n == 32 && !numStart : // is white space
						break;

					case int n when (n == 43 || n == 45) && !numStart: // is plus or minus
						numStart = true;
						isPlusMinus++;
						if (isPlusMinus > 1) return 0;
						break;

					default:
						if (outbuff != 0) return isNegative ? outbuff * -1 : outbuff;
						return 0;

				}

				

				Console.WriteLine(i + "|" + charAR[i] +"|" + charVal);
				i++;
				
			}
			return isNegative ? outbuff * -1 : outbuff;
		}


		public static int MyAtoi_NoEdgeCases(string str) {
			if (str.Length == 0) return 0;

			char[] charAR = str.ToCharArray();
			int i = 0;
			int charVal;

			int outbuff = 0;

			bool isNum = true;
			bool isNegative = false;
			bool isWhite = true;
			int isPlusMinus = 0;

			while (i < str.Length && (isWhite || isNum || isPlusMinus < 2))
			{

				charVal = charAR[i] - 48;
				isNum = charVal > -1 && charVal < 10;
				isWhite = charVal == -16;

				if (charVal == -5 || charVal == -3) isPlusMinus++;
				if (isPlusMinus > 1) return 0;

				if (isNum)
				{

					if (outbuff >= Int32.MaxValue / 10)
					{
						if (outbuff == Int32.MaxValue / 10)
						{
							if (charVal > 7) return isNegative ? Int32.MinValue : Int32.MaxValue;
						}
						else
						{
							return isNegative ? Int32.MinValue : Int32.MaxValue;

						}

					}


					outbuff = outbuff * 10 + charVal;

					if (outbuff < 10 && (i > 0 && charAR[i - 1] == '-')) isNegative = true;



				}
				Console.WriteLine(i + "|" + charAR[i] + "|" + charVal);
				i++;

			}

			if (isNegative) outbuff *= -1;

			return outbuff;


		}
	}

}

