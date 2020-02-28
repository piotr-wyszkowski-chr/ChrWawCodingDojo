using System;

namespace TeamPiotr
{
    public class UserNumber
    {
        public int GetNumber(int input)
        {
            return GetNumberRecursive(input);
        }

        public int GetNumberRecursive(int input, int lastStop = 0)
        {
            var result = input;
            int found = 0;

            // Brute force simple loop (488)
            for (int i = lastStop; i <= input; i++)
            {
                if (CheckIfNumberContains4Or9(i))
                {
                    found ++;
                    result++;
                }
            }

            if (CheckIfNumberContains4Or9(result))
            {
                found++;
            }

            if (found <= 1)
                return result;

            return GetNumberRecursive(result, input);
        }

        public bool CheckIfNumberContains4Or9(int input)
        {
            var inputText = input.ToString();

            return inputText.Contains("4") || inputText.Contains("9");
        }
    }
}