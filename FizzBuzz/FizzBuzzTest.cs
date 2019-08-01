using Xunit;

namespace FizzBuzz
{
    public class FizzBuzzTest
    {
        private FizzBuzz _sut = new FizzBuzz();

        [Fact]
        public void tc1()
        {
            int number = 3;
            string returnValue = _sut.Check(number);
            Assert.NotNull(returnValue);
            Assert.NotEmpty(returnValue);
            Assert.Equal("FIZZ", returnValue.ToUpper());
        }

        [Fact]
        public void tc2()
        {
            int number = 5;
            string returnValue = _sut.Check(number);
            Assert.NotNull(returnValue);
            Assert.NotEmpty(returnValue);
            Assert.Equal("BUZZ", returnValue.ToUpper());
        }

                [Fact]
        public void tc3()
        {
            int number = 15;
            string returnValue = _sut.Check(number);
            Assert.NotNull(returnValue);
            Assert.NotEmpty(returnValue);
            Assert.Equal("FIZZBUZZ", returnValue.ToUpper());
        }

                        [Fact]
        public void tc4()
        {
            int number = 4;
            string returnValue = _sut.Check(number);
            Assert.NotNull(returnValue);
            Assert.NotEmpty(returnValue);
            Assert.Equal("4", returnValue.ToUpper());
        }
    }
}
