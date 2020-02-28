using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTomasz
{
    [TestClass]
    public class UserNumberTests
    {
        private readonly UserNumber _sut = new UserNumber();

        [DataRow(1, 1)]
        [DataRow(5, 4)]
        [DataRow(10, 8)]
        [DataRow(12, 10)]
        [DataRow(25, 20)]
        [DataRow(875, 500)]
        [DataRow(1860, 1000)]
        [DataRow(303250, 100000)]
        [DataRow(155, 100)]
        [TestMethod]
        public void FirstTest(int result, int usersCount)
        {
            Assert.AreEqual(result, _sut.GetNumber(usersCount));
        }

        [DataRow(15, 17)]
        [DataRow(25, 31)]
        [DataRow(20, 24)]
        [DataRow(500, 764)]
        [TestMethod]
        public void DecToOctTest(int dec, int oct)
        {
            Assert.AreEqual(oct, _sut.DecToOct(dec));
        }

        [DataRow('1', "1")]
        [DataRow('4', "5")]
        [DataRow('7', "8")]
        [TestMethod]
        public void SubstituteNumberTest(char input, string res)
        {
            Assert.AreEqual(res, _sut.SubstituteNumber(input));
        }
    }
}