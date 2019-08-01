using Xunit;

namespace WordWrap
{
    public class WordWrapTest
    {
        private WordWrap _sut = new WordWrap();

        [Fact]
        public void tc1()
        {
            string test = "test";
            int colLength = 7;

            string res = _sut.Wrap(test, colLength);

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal("test", res);
        }

        [Fact]
        public void tc2()
        {
            string test = "hello world";
            int colLength = 7;

            string res = _sut.Wrap(test, colLength);

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal("hello--world", res);
        }

        [Fact]
        public void tc3()
        {
            string test = "a lot of words for a single line";
            int colLength = 10;

            string res = _sut.Wrap(test, colLength);

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal("a lot of--words for--a single--line", res);
        }
    }
}
