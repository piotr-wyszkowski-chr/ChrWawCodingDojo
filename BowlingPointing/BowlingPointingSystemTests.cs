using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingPointing
{
    [TestClass]
    public class BowlingGameTests
    {
        private BowlingGame _sut;
        private IFixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new BowlingGame();
            _fixture = new Fixture();

        }
        [TestMethod]
        public void OneThrow_Not10_CorrectTotalPoints()
        {
            var totalPoints = _sut.AddRound(5, 0);
            totalPoints.Should().Be(5);
        }

        [TestMethod]
        public void OneRound_Strike_CorrectTotalPoints()
        {
            var totalPoints = _sut.AddRound(10, 0);
            totalPoints.Should().Be(10);
        }

        [TestMethod]
        public void OneRound_Spare_CorrectTotalPoints()
        {
            var totalPoints = _sut.AddRound(2, 8);
            totalPoints.Should().Be(10);
        }

        [TestMethod]
        public void ThreeRound_CorrectTotalPoints()
        {
            _sut.AddRound(1, 8);
            _sut.AddRound(3, 2);
            var totalPoints =_sut.AddRound(3, 2);
            totalPoints.Should().Be(19);

        }

        [TestMethod]
        public void ThreeRound_Spare_Spare_Normal_CorrectTotalPoints()
        {
            _sut.AddRound(2, 8); //10+3
            _sut.AddRound(3, 7); //10+3
            var totalPoints = _sut.AddRound(3, 2); //5
            totalPoints.Should().Be(31);

        }

        [TestMethod]
        public void Max_CorrectTotalPoints()
        {
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            _sut.AddRound(10, 0); //10+3
            var totalPoints = _sut.AddRound(10, 10, 10); //5
            totalPoints.Should().Be(300);

        }

        [TestMethod]
        public void Round_Should_Be_Strike()
        {
            var round = new Round()
            {
                First = 10
            };
            round.ResultRoundType.Should().Be(ResultRoundType.Strike);
        }

        [TestMethod]
        public void Round_Should_Be_Spare()
        {
            var round = new Round()
            {
                First = 8,
                Second = 2
            };
            round.ResultRoundType.Should().Be(ResultRoundType.Spare);
        }

        [TestMethod]
        public void Round_Should_Be_Normal()
        {
            var round = new Round()
            {
                First = 1,
                Second = 2
            };
            round.ResultRoundType.Should().Be(ResultRoundType.Normal);
        }

    }
}
