using System;
using Xunit;

namespace RomanNumbers
{
    public class RomanNumbersTest
    {
        private RomanNumbers _sut = new RomanNumbers();

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("VIII", 8)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        [InlineData("CM",900)]
        [InlineData("MCDXLIV",1444)]
        [InlineData("MMMCDXLIV",3444)]
        public void Exchange_CorrectRomanNumber_CorrectNumber(string input, int expected)
        {
            var result = _sut.Exchange(input);
            Assert.Equal(expected, result);
        }

        public void Exchange_IncorrectRomanNumber_ThrowException(string input)
        {
            var result = _sut.Exchange(input);
            Assert.Throws<ArgumentException>(() => _sut.Exchange(input));
        }

    }
}
