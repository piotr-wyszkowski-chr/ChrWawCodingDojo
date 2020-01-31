using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntBridge
{
    [TestClass]
    public class AntBridgeTests
    {
        private AntBridge _sut = new AntBridge();

        [TestMethod]
        public void Bridge_Example()
        {
            _sut.Bridge("GFEDCBA", "------------...-----------").Should().Be("EDCBAGF");
        }

        [TestMethod]
        public void Bridge_NoGaps()
        {
            _sut.Bridge("GFEDCBA", "-----------------------").Should().Be("GFEDCBA");
        }

        [TestMethod]
        public void Bridge_Example2()
        {
            _sut.Bridge("GFEDCBA", "----..-----....---------").Should().Be("CBAGFED");
        }


        [TestMethod]
        [DataRow("----------------", 0)]
        [DataRow("----..-----....---------", 10)]
        [DataRow("----..--...--....----...----", 20)]
        public void GetGaps(string terrain, int expected)
        {
            _sut.GetGapsSum(terrain).Should().Be(expected);
        }

        [TestMethod]
        [DataRow("ABCDEF", 0, "ABCDEF")]
        [DataRow("ABCDEF", 3, "DEFABC")]
        [DataRow("ABCDEF", 4, "CDEFAB")]
        public void GetShiftTest(string ants, int gaps, string expectedAnts)
        {
            _sut.GetShift(gaps, ants).Should().Be(expectedAnts);
        }

    }
}