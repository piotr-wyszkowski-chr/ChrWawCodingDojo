using System;
using System.Collections.Generic;
using System.Linq;
namespace RomanNumbers
{
    public class RomanNumbers
    {
        private readonly Dictionary<string, int> Symbols;

        public Dictionary<string, int> Ones { get; }

        public Dictionary<string, int> Tens { get; }
        public Dictionary<string, int> Hundreds { get; }

        public RomanNumbers()
        {
            Symbols = new Dictionary<string, int>(){
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000},

            };

            Ones = new Dictionary<string, int>(){
                {"I", 1},
                {"II", 2},
                {"III", 3},
                {"IV", 4},
                {"V", 5},
                {"VI", 6},
                {"VII", 7},
                {"VIII", 8},
                {"IX", 9}
            };

            Tens = new Dictionary<string, int>(){
                {"X", 10},
                {"XX", 20},
                {"XXX", 30},
                {"XL", 40},
                {"L", 50},
                {"LX", 60},
                {"LXX", 70},
                {"LXXX", 80},
                {"XC", 90}
            };

            Hundreds = new Dictionary<string, int>(){
                {"C", 100},
                {"CC", 200},
                {"CCC", 300},
                {"CD", 400},
                {"D", 500},
                {"DC", 600},
                {"DCC", 700},
                {"DCCC", 800},
                {"CM", 900}
            };
        }

        /// <param name="romanNumber">number in Roman format e.g. IV, V, X etc.</param>
        /// <returns>Arabic number</returns>
        public int Exchange(string romanNumber)
        {
            int number = 0;
            //here we wll calc no of Ms and this will be no of thousands - next one will do it
            int msCount = romanNumber.TakeWhile(z => z.Equals('M')).Count();
            number = msCount * 1000;
            romanNumber = romanNumber.Substring(msCount, romanNumber.Length-msCount);

            var houndreds = GetNumber(romanNumber, Hundreds);
            if (houndreds.HasValue)
            {
                romanNumber = romanNumber.Substring(houndreds.Value.symbol.Length);
                number += houndreds.Value.value;
            }
            var tens = GetNumber(romanNumber, Tens);
            if (tens.HasValue)
            {
                romanNumber = romanNumber.Substring(tens.Value.symbol.Length);
                number += tens.Value.value;
            }
            var ones = GetNumber(romanNumber, Ones);
            if (ones.HasValue)
            {
                romanNumber = romanNumber.Substring(ones.Value.symbol.Length);
                number += ones.Value.value;
            }

            if (romanNumber.Any())
            {
                throw new ArgumentException("Invalid roman number!");
            }

            return number;
        }

        private (string symbol , int value)? GetNumber(string romanNUmber, Dictionary<string, int> symbolsDict)
        {
            var orderedSymoblsDict = symbolsDict.OrderByDescending(x => x.Key.Length);
            var foundSymbol = orderedSymoblsDict
                .FirstOrDefault(x => romanNUmber.StartsWith(x.Key));
            if(string.IsNullOrEmpty(foundSymbol.Key))
            {
                return null;
            }
            return (foundSymbol.Key, foundSymbol.Value);
        }
    }
}