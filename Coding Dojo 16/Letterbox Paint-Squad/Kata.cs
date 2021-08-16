using System;
using System.Collections.Generic;
using System.Linq;

namespace Letterbox_Paint_Squad
{
    public class Kata
    {
        public static IEnumerable<int> PaintLetterBoxes(int start, int end)
        {
            if (start <= 0 || end < start)
            {
                throw new ArgumentException();
            }

            var result = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            var res = Enumerable
                .Range(start, end - start + 1)
                .SelectMany(GetDigits)
                .GroupBy(digits => digits);

            foreach (var digitGrouping in res)
            {
                result[digitGrouping.Key] = digitGrouping.Count();
            }

            return result;
        }

        public static IEnumerable<int> GetDigits(int value)
        {
            if (value == 0)
            {
                yield return 0;
                yield break;
            }

            while (value > 0) 
            {
                var digit = value % 10;
                yield return digit;
                value = value / 10;
            }
        }
    }
}