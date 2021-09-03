using System;
using System.IO;

namespace XOR_decryption
{
    public static class Program
    {
        public static void Main()
        {
            var fileContent = File.ReadAllText("p059_cipher.txt");
            var convertedString = Decrypt.ConvertFromAscii(fileContent);
            var generatedKeys = Decrypt.KeyGenerator();
            foreach (var key in generatedKeys)
            {
                var decrypted = Decrypt.DecryptXor(convertedString, key);
                if (!Decrypt.CheckCorrectChars(decrypted))
                    continue;
                Console.WriteLine(decrypted);
                Console.WriteLine($"Passsword is: {key}");
            }

            Console.WriteLine("the end");
            Console.ReadLine();
        }


    }
}