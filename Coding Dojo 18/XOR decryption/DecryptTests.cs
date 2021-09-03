using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace XOR_decryption
{
    public class DecryptTests
    {
        [Theory]
        [InlineData("67", "C")]
        [InlineData("65,66,67", "ABC")]
        public void ConvertFromAscii_ReadsChar(string input, string expected)
        {
            var decripted = Decrypt.ConvertFromAscii(input);

            decripted.Should().Be(expected);
        }
        //65, asterisk (*) = 42, and lowercase k = 107.
        [Theory]
        [InlineData(65, 42, 107)]
        public void DecryptXorTest(int a, int b, int expected)
        {
            var output = Decrypt.DecryptXor(((char)a).ToString(), ((char)b).ToString());

            output.Should().Be(((char)expected).ToString());
        }

        [Fact]
        public void KeyGeneratorFirstResult_Contain_aaa()
        {
            var result = Decrypt.KeyGenerator().FirstOrDefault();
            result.Should().Be("aaa");
        }

        [Fact]
        public void KeyGeneratorFirstResult_Contain_zzz()
        {
            var result = Decrypt.KeyGenerator().LastOrDefault();
            result.Should().Be("zzz");
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("\u0000", false)]
        [InlineData("A B C S$%", true)]
        public void CheckCorrectChars(string input, bool expected)
        {
            var result = Decrypt.CheckCorrectChars(input);
            result.Should().Be(expected);
        }
        

    }
}