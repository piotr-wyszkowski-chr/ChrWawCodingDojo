using System;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        /// <param name="number">input number</param>
        /// <returns>
        /// fizz - for number divisible by 3
        /// buzz - for number divisible by 5
        /// fizzbuzz - for number divisible by 3 and 5
        /// inputNumber - for number not divisible by 3 and 5
        /// </returns>
        public string Check(int number)
        {
            string resultValue = string.Empty;
            bool isDivBy3 = number % 3 == 0;
            bool isDivBy5 = number % 5 == 0;


            if(isDivBy3 && isDivBy5){
                resultValue = "FIZZBUZZ";
            }
            else if(isDivBy3){
                resultValue = "FIZZ";
            }
            else if(isDivBy5){
                resultValue = "BUZZ";
            }
            else
            {
                resultValue = number.ToString();
            }

            return resultValue;
        }
    }
}