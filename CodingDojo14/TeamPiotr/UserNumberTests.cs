using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamPiotr
{
    [TestClass]
    public class UserNumberTests
    {
        private readonly UserNumber _sut = new UserNumber();

        [DataRow(1,1)]
        [DataRow(4,5)]
        [DataRow(8,10)]
        [DataRow(10,12)]
        [DataRow(20,25)]
        [DataRow(500,875)]
        [DataRow(1000,1860)]
        [DataRow(100000,303250)]
        [TestMethod]
        public void GetNumber(int userNumber, int expectedResult)
        {
            _sut.GetNumber(userNumber).Should().Be(expectedResult);
        }

        [DataRow(1, false)]
        [DataRow(4, true)]
        [DataRow(8, false)]
        [DataRow(10, false)]
        [DataRow(20, false)]
        [DataRow(500, false)]
        [TestMethod]
        public void CheckIfNumberContains4Or9(int input, bool expected)
        {
            _sut.CheckIfNumberContains4Or9(input).Should().Be(expected);
        }
    }
}