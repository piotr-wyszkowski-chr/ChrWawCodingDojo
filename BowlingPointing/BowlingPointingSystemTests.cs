using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingPointing
{
    [TestClass]
    public class BowlingPointingSystemTests
    {
        private BowlingPointingSystem _sut;
        private IFixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new BowlingPointingSystem();
            _fixture = new Fixture();

        }
        [TestMethod]
        public void CalculatePoints_CorrectAmountOfFrames_ReturnsValue()
        {
            var frames = _fixture.CreateMany<Frame>(BowlingPointingSystem.AmountOfFrames).ToArray();
            var result = _sut.CalculatePoints(frames);
            result.Should().BeGreaterThan(0);
        }
    }
}
