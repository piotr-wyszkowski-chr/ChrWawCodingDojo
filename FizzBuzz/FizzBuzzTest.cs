using Xunit;

namespace FizzBuzz
{
    public class FizzBuzzTest
    {
        private FizzBuzz _sut = new FizzBuzz();

        [Theory]
        [InlineData(3, "FIZZ")]
        [InlineData(5, "BUZZ")]
        [InlineData(15, "FIZZBUZZ")]
        [InlineData(4, "4")]
        public void Check_Return_CorrectValue(int number, string expectedResult)
        {
            string returnValue = _sut.Check(number);
            Assert.NotNull(returnValue);
            Assert.NotEmpty(returnValue);
            Assert.Equal(expectedResult, returnValue.ToUpper());
        }
    }
}
