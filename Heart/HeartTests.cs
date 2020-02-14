using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heart
{
    [TestClass]
    public class UnitTest1
    {
        private Heart _sut = new Heart();

        private string heart6 =
            "◢█◣◢█◣" +
            "██████" +
            "◥████◤" +
            "　◥██◤　" +
            "　　◥◤　　";

        private string heart8 =
            "◢██◣◢██◣" +
            "████████" +
            "◥██████◤" +
            "　◥████◤　" +
            "　　◥██◤　　" +
            "　　　◥◤　　　";


        private string heart10 =
            "◢███◣◢███◣" +
            "██████████" +
            "◥████████◤" +
            "　◥██████◤　" +
            "　　◥████◤　　" +
            "　　　◥██◤　　　" +
            "　　　　◥◤　　　　";


        private string heart12 =
            "◢████◣◢████◣" +
            "████████████" +
            "████████████" +
            "◥██████████◤" +
            "　◥████████◤　" +
            "　　◥██████◤　　" +
            "　　　◥████◤　　　" +
            "　　　　◥██◤　　　　" +
            "　　　　　◥◤　　　　　";

        private string heart18 =
            "◢███████◣◢███████◣" +
            "██████████████████" +
            "██████████████████" +
            "██████████████████" +
            "◥████████████████◤" +
            "　◥██████████████◤　" +
            "　　◥████████████◤　　" +
            "　　　◥██████████◤　　　" +
            "　　　　◥████████◤　　　　" +
            "　　　　　◥██████◤　　　　　" +
            "　　　　　　◥████◤　　　　　　" +
            "　　　　　　　◥██◤　　　　　　　" +
            "　　　　　　　　◥◤　　　　　　　　";

        [TestMethod]
        [DataRow(6, "◢█◣◢█◣")]
        [DataRow(8, "◢██◣◢██◣")]
        [DataRow(10, "◢███◣◢███◣")]
        [DataRow(12, "◢████◣◢████◣")]
        [DataRow(18, "◢███████◣◢███████◣")]
        public void DrawTop(int width, string expectedResult)
        {
            _sut.DrawTop(width).Should().Be(expectedResult);

        }
        [TestMethod]
        [DataRow(6, 1)]
        [DataRow(8, 1)]
        [DataRow(10, 1)]
        [DataRow(12, 2)]
        [DataRow(18, 3)]
        public void DrawMiddle(int width, int expectedLineCount)
        {
            var result = _sut.DrawMiddle(width)
                .Split(Environment.NewLine);
            result.Should().HaveCount(expectedLineCount);
            result.ToList().ForEach(x=>x.Should().HaveLength((width)));
        }

        [TestMethod]
        [DataRow(6, @"◥████◤
　◥██◤　
　　◥◤　　")]
        [DataRow(8, @"　◥██████◤　
　　◥████◤　　
　　　◥██◤　　　
　　　　◥◤　　　　")]
        [DataRow(10, @"◥████████◤
　◥██████◤　
　　◥████◤　　
　　　◥██◤　　　
　　　　◥◤　　　　")]
        [DataRow(12, @"◥██████████◤
　◥████████◤　
　　◥██████◤　　
　　　◥████◤　　　
　　　　◥██◤　　　　
　　　　　◥◤　　　　　")]
        [DataRow(18, @"◥████████████████◤
　◥██████████████◤　
　　◥████████████◤　　
　　　◥██████████◤　　　
　　　　◥████████◤　　　　
　　　　　◥██████◤　　　　　
　　　　　　◥████◤　　　　　　
　　　　　　　◥██◤　　　　　　　
　　　　　　　　◥◤　　　　　　　　")]
        public void DrawBottom(int width, string expectedResult)
        {
            _sut.DrawBottom(width).Should().Be(expectedResult);
        }
    }
}
