using System;
using System.Collections.Generic;
using System.Linq;
namespace RomanNumbers
{
    public class RomanNumbers
    {
        private readonly Dictionary<string, int> Symbols;

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
        }

        /// <param name="romanNumber">number in Roman format e.g. IV, V, X etc.</param>
        /// <returns>Arabic number</returns>
        public int Exchange(string romanNumber)
        {
            var charArray = romanNumber.Reverse().ToArray();
                    var char0 = charArray[0];
                    int val0 = Symbols[char0.ToString()];

            int result = val0;

            for (int i = 0; i < charArray.Length-1; i++)
            {
                if (i <= charArray.Length)
                {
                    var firstChar = charArray[i];
                    var secondChar = charArray[i + 1];
                    
                    int firstVal = Symbols[firstChar.ToString()];
                    int secondVal = Symbols[secondChar.ToString()];

                    if(firstVal <= secondVal)
                    {
                        result += secondVal;
                    }
                    else
                    {
                        result -= secondVal;
                    }
                }
                
            }


           return result;


        }
    }
}