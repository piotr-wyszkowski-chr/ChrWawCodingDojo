using System;
using System.Text;
using System.Linq;

namespace TeamTomasz
{
    public class UserNumber
    {
        int[] valuesTable = new int[] { 0, 1, 2, 3, 5, 6, 7, 8 };
        public int GetNumber(int input)
        {
            #region OneLineVersion
            //return int.Parse(String.Join("", Convert.ToString(input, 8)
            //    .Select(x => ((new int[] { 0, 1, 2, 3, 5, 6, 7, 8 })[int.Parse(x.ToString())]).ToString())));
            #endregion

            var octNumber = DecToOct(input).ToString();
            var stringBuilder = new StringBuilder();
            foreach (var character in octNumber)
            {
                stringBuilder.Append(SubstituteNumber(character));
            }
            return int.Parse(stringBuilder.ToString());
        }

        public string SubstituteNumber(char input)
        {
            var index = int.Parse(input.ToString());
            return valuesTable[index].ToString();
        }

        public int DecToOct(int value)
        {
            return int.Parse(Convert.ToString(value, 8));
        }


    }
}