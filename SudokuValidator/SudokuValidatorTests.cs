using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuValidator
{
    [TestClass]
    public class SudokuValidatorTests
    {
        private SudokuValidator _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new SudokuValidator();
        }

        [TestMethod]
        public void Validate_CorrectSudoku_true()
        {
            var input = new[]
            {
                new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
            };

            _sut.Validate(input).Should().BeTrue();
        }
    }
}
