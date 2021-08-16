using FluentAssertions;
using Xunit;

namespace Next_smaller_number
{
    public class KataTests
    {
        [Theory]
        [InlineData(9, -1)]
        [InlineData(111, -1)]
        [InlineData(135, -1)]
        [InlineData(1027, -1)]
        [InlineData(1234560, 1234506)]
        [InlineData(123456, -1)]
        [InlineData(long.MaxValue, 9223372036854775780)]
        [InlineData(20, -1)]
        [InlineData(-1, -1)]
        [InlineData(71, 17)]
        [InlineData(531, 513)]
        public void NextSmallerNumber(long input, long expected)
        {
            Kata.NextSmallerNumber(input).Should().Be(expected);
        }
    }
}