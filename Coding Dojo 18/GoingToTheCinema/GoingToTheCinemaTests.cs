using FluentAssertions;
using Xunit;

namespace GoingToTheCinema
{
    public class GoingToTheCinemaTests
    {
        [Theory]
        [InlineData(2, 1, 0.1, 4)]
        [InlineData(500, 15, 0.9, 43)]
        [InlineData(100, 10, 0.95, 24)]
        public void BasicTest(int card, int ticket, double perc, int result)
        {
            GoingToTheCinema.Movie(card, ticket, perc).Should().Be(result);
        }
    }
}
