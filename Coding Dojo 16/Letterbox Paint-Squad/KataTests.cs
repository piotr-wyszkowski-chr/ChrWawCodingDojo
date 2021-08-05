using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Letterbox_Paint_Squad
{
    public class KataTests
    {
        [Fact]
        public void Test1()
        {
            var expected = new int[] {1,9,6,3,0,1,1,1,1,1};
            var result = Kata.PaintLetterBoxes(125, 132).ToArray();
            expected.Should().BeEquivalentTo(result);
        }
    }
}
