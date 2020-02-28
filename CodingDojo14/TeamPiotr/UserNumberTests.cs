using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamPiotr
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
        [TestMethod]
        public void FirstTest(int result, int usersCount)
        {
            Assert.AreEqual(result, _sut.GetNumber(usersCount));
        }
    }
}