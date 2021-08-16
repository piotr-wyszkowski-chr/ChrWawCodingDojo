using System;
using System.Linq;

namespace Next_bigger_number
{
    public class Kata
    {
        public static long NextBigger(long n)
        {
            if (n < 0)
            {
                return -1;
            }

            var number = n.ToString().ToArray();
            var sortedNumber = string.Concat(number.OrderByDescending(x => x));
            if (sortedNumber == string.Concat(number))
            {
                return -1;
            }

            int foundIndex = -1;
            for (int i = number.Length - 1; i > 0; i--)
            {
                var memoryNum = number[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    if (number[j] < memoryNum)
                    {
                        var newNumber = number[j];
                        number[j] = number[i];
                        number[i] = newNumber;
                        foundIndex = j;
                        break;
                    }
                }
                if (foundIndex > -1)
                {
                    break;
                }
            }

            var left = number[..(foundIndex + 1)];
            var right = number[(foundIndex + 1)..];

            Array.Sort(right);

            return long.Parse(string.Concat(left.Concat(right)));
        }
    }
}