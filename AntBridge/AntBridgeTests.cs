using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntBridge
{
    [TestClass]
    public class AntBridgeTests
    {
        private AntBridge _sut = new AntBridge();

        [TestMethod]
        public void Example()
        {
            _sut.Bridge("GFEDCBA", "------------...-----------").Should().Be("EDCBAGF");
        }

        [TestMethod]
        public void NoGaps()
        {
            _sut.Bridge("GFEDCBA", "-----------------------").Should().Be("GFEDCBA");
        }

        [TestMethod]
        public void Example2()
        {
            _sut.Bridge("GFEDCBA", "----..-----....---------").Should().Be("CBAGFED");
        }
    }
}