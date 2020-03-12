using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarParkEscape
{
    [TestClass]
    public class CarParkEscapeTest
    {
        private CarParkEscape _sut = new CarParkEscape();

        [TestMethod]
        public void BasicTest1()
        {
            int[,] carpark = new int[,] { { 1, 0, 0, 0, 2 },
                                          { 0, 0, 0, 0, 0 } };
            string[] result = new string[] { "L4", "D1", "R4" };
            Assert.AreEqual(result, _sut.Escape(carpark));
        }

        [TestMethod]
        public void BasicTest2()
        {
            int[,] carpark = new int[,] { { 2, 0, 0, 1, 0 },
                                          { 0, 0, 0, 1, 0 },
                                          { 0, 0, 0, 0, 0 } };
            string[] result = new string[] { "R3", "D2", "R1" };
            Assert.AreEqual(result, _sut.Escape(carpark));
        }

        [TestMethod]
        public void BasicTest3()
        {
            int[,] carpark = new int[,] { { 0, 2, 0, 0, 1 },
                                          { 0, 0, 0, 0, 1 },
                                          { 0, 0, 0, 0, 1 },
                                          { 0, 0, 0, 0, 0 } };
            string[] result = new string[] { "R3", "D3" };
            Assert.AreEqual(result, _sut.Escape(carpark));
        }

        [TestMethod]
        public void BasicTest4()
        {
            int[,] carpark = new int[,] { { 1, 0, 0, 0, 2 },
                                          { 0, 0, 0, 0, 1 },
                                          { 1, 0, 0, 0, 0 },
                                          { 0, 0, 0, 0, 0 } };
            string[] result = new string[] { "L4", "D1", "R4", "D1", "L4", "D1", "R4" };
            Assert.AreEqual(result, _sut.Escape(carpark));
        }

        [TestMethod]
        public void BasicTest5()
        {
            int[,] carpark = new int[,] { { 0, 0, 0, 0, 2 } };
            string[] result = new string[] { };
            Assert.AreEqual(result, _sut.Escape(carpark));
        }

    }
}
