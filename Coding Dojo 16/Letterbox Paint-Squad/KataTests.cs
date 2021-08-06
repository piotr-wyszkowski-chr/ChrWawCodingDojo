using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Letterbox_Paint_Squad
{
    public class KataTests
    {
        [Theory]
        [MemberData(nameof(Should_CrashOnBadInput_Data))]
        public void Should_CrashOnBadInput(int from, int to)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Kata.PaintLetterBoxes(from, to);
            });
        }
        public static IEnumerable<object[]> Should_CrashOnBadInput_Data => new[]
        {
            new object[] {0, 1},
            new object[] {0, 10},
            new object[] {0, 0},
            new object[] {10, 0},
            new object[] {-1, 10},
            new object[] {-1, -1},
            new object[] {-1, -2},
            new object[] {-3, -2},
            new object[] {10, 1},
        };

        [Theory]
        [MemberData(nameof(Should_PaintLetterbox_Data))]
        public void Should_PaintLetterbox(int from, int to, int[] expected)
        {
            var result = Kata.PaintLetterBoxes(from, to).ToArray();
            expected.Should().BeEquivalentTo(result);
        }

        [Theory]
        [MemberData(nameof(Should_GetDigits_Data))]
        public void Should_GetDigits(int number, int[] expectedArr)
        {
            // Act
            var result = Kata.GetDigits(number);

            // Assert
            result.Should().BeEquivalentTo(expectedArr);
        }

        public static IEnumerable<object[]> Should_PaintLetterbox_Data => new[]
        {
            new object[] {1, 1, new[] {0,1,0,0,0,0,0,0,0,0}},
            new object[] {5,5, new[] {0,0,0,0,0,1,0,0,0,0}},
            new object[] {1,9, new[] {0,1,1,1,1,1,1,1,1,1}},
            new object[] {1,10, new[] {1,2,1,1,1,1,1,1,1,1}},
        };

        public static IEnumerable<object[]> Should_GetDigits_Data => new[]
        {
            new object[] {0, new[] {0}},
            new object[] {10, new[] {0,1}},
            new object[] {5, new[] {5}},
            new object[] {123, new[] {1,2,3}},
            new object[] {101, new[] {1,0,1}},
            new object[] {12345, new[] {1,2,3,4,5}},
            new object[] {12345, new[] {5,4,3,2,1}},
        };
    }
}
