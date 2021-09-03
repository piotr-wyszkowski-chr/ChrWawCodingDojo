using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XOR_decryption
{
    public class Decrypt
    {
        public static string ConvertFromAscii(string fileContent)
        {
            return string.Concat(fileContent.Split(',').Select(int.Parse).Select(x => (char)x));
        }

        public static string DecryptXor(string value, string key)
        {
            var sb = new StringBuilder();
            var keyIndex = 0;
            foreach (var t in value)
            {
                var result = (char)(t ^ key[keyIndex]);
                sb.Append(result);

                keyIndex++;
                if (keyIndex == key.Length)
                {
                    keyIndex = 0;
                }
            }

            return sb.ToString();
        }

        public static IEnumerable<string> KeyGenerator()
        {
            for (int i = (int)'a'; i <= (int)'z'; i++)
            {
                for (int j = (int)'a'; j <= (int)'z'; j++)
                {
                    for (int k = (int)'a'; k <= (int)'z'; k++)
                    {
                        yield return $"{(char)i}{(char)j}{(char)k}";
                    }
                }
            }
        }

        public static bool CheckCorrectChars(string value)
        {
            return value.Contains(" the ");
            //return Regex.IsMatch(value, @"^[\sa-zA-Z]*$");
            return Regex.IsMatch(value, @"^[\w\d\s\.\(\)\{\}\[\]""\'\,\:\;\,\+\-_=\!\?]*$");
        }
    }
}