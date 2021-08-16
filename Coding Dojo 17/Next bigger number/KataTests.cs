using FluentAssertions;
using Xunit;

namespace Next_bigger_number
{
    public class KataTests
    {        
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(1, -1)]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(414, 441)]
        [InlineData(144, 414)]
        [InlineData(543, -1)]
        [InlineData(987654321, -1)]
        [InlineData(76281, 76812)]
        [InlineData(564321, 612345)]
        public void Test1(long n, long result)
        {
            Kata.NextBigger(n).Should().Be(result);
        }
    }
}