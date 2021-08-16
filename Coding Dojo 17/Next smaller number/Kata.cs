using System;
using System.Collections.Generic;
using System.Linq;

namespace Next_smaller_number
{
    public class Kata
    {
        public static long NextSmallerNumber(long n)
        {
            if (n < 0)
            {
                return -1;
            }

            var digits = n.ToString().Select(n => int.Parse(n.ToString())).ToArray();

            if (digits.Distinct().Count() == 1)
            {
                return -1;
            }

            List<int> result = new List<int>();
            List<int> digitsToUse = new List<int>()
            {
                digits.Last()
            };

            int firstLower = 0;
            for (int i = digits.Length - 2; i>=0; i--)
            {
                int currentDigit = digits[i];

                if (digitsToUse.Any(x => x < currentDigit))
                {
                    firstLower = digitsToUse.First(f => f < currentDigit);
                    digitsToUse.Add(currentDigit);
                    digitsToUse.Remove(firstLower);
                    break;
                }

                digitsToUse.Add(currentDigit);
            }

            result.AddRange(digits.Take(digits.Length - digitsToUse.Count - 1));

            result.Add(firstLower);

            result.AddRange(digitsToUse.OrderByDescending(x=>x));

            if (result[0] == 0)
            {
                return -1;
            }

            return long.Parse(string.Join("", result));
        }
    }
}