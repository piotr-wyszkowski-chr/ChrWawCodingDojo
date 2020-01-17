using System.Drawing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LargestRoomArea
{
    [TestClass]
    public class LargestRoomAreaCalculatorTests
    {
        private LargestRoomAreaCalculator _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new LargestRoomAreaCalculator();
        }

        [TestMethod]
        public void FirstTest()
        {
            var input = new[, ] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };

            _sut.GetLargestRoomSize(input).Should().Be(12);
        }

        [TestMethod]
        public void SecondTest()
        {
            var input = new[,] {
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1 },
            };

            _sut.GetLargestRoomSize(input).Should().Be(0);
        }

        [TestMethod]
        public void FindNextEmpty_ShouldReturnNotNull()
        {
            var input = new[,] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };
            _sut.FindNextEmpty(input, new Point(0, 0)).Should().BeEquivalentTo(new Point(0,1));

        }
        [TestMethod]
        public void FindNextEmpty_ShouldReturnNull()
        {
            var input = new[,] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };
            _sut.FindNextEmpty(input, new Point(6, 5)).Should().BeNull();

        }

        [TestMethod]
        public void FindNextEmpty_ShouldReturnNextPoint()
        {
            var input = new[,] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };
            _sut.FindNextEmpty(input, new Point(1, 2)).Should().BeEquivalentTo(new Point(1, 6));

        }

        [TestMethod]
        public void CalculateRoomSize_ShouldReturn11()
        {
            var input = new[,] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };
            _sut.CalculateRoomSize(input, new Point(0, 1)).Should().Be(12);

        }
        [TestMethod]
        public void CalculateRoomSize_ShouldReturn7()
        {
            var input = new[,] {
                {1, 0, 0, 0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
                {0, 1, 1, 1, 1, 1, 0, 1 },
                {0, 0, 1, 1, 1, 0, 0, 1 },
                {0, 0, 1, 1, 1, 1, 0, 1 },
            };
            _sut.CalculateRoomSize(input, new Point(2, 1)).Should().Be(7);

        }
    }
}
