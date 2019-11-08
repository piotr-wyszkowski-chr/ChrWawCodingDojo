using System.Collections.Generic;
using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuValidator
{
    [TestClass]
    public class SudokuValidatorTests
    {
        private SudokuValidator _sut;
        private int[][] _incorrect = new[]
        {
            new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
            new[] {6, 7, 2, 1, 9, 0, 3, 4, 8},
            new[] {1, 0, 0, 3, 4, 2, 5, 6, 0},
            new[] {8, 5, 9, 7, 6, 1, 0, 2, 0},
            new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
            new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
            new[] {9, 0, 1, 5, 3, 7, 2, 1, 4},
            new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
            new[] { 3, 0, 0, 4, 8, 1, 1, 7, 9 }
        };

        private int[][] _correct = new[]
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


        [TestInitialize]
        public void Initialize()
        {
            _sut = new SudokuValidator();
        }

        [TestMethod]
        public void Validate_CorrectSudoku_true()
        {

            _sut.Validate(_correct).Should().BeTrue();
        }

        [TestMethod]
        public void Validate_IncorrectSudoku_false()
        {

            _sut.Validate(_incorrect).Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_LengthLessThan9_false()
        {
            var input = new int[] { 1, 2 };
            _sut.IsValid(input).Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_LengthGreaterThan9_false()
        {
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            _sut.IsValid(input).Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_LengthEqual9_true()
        {
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _sut.IsValid(input).Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_AreElementsInRange_true()
        {
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _sut.IsValid(input).Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_AreElementsNotInRange_false()
        {
            var input = new[] { 1, -1, 66, 3, 4, 5, 6, 7, 8 };
            _sut.IsValid(input).Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_AreElementsUnique_true()
        {
            var input = new[] { 1, 2, 3, 4, 6, 7, 8, 9, 5 };
            _sut.IsValid(input).Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_AreElementsUnique_false()
        {
            var input = new[] { 1, 1, 3, 4, 6, 7, 8, 9, 5 };
            _sut.IsValid(input).Should().BeFalse();
        }

        [TestMethod]
        public void GetRows_CorrectNumberOfRows()
        {
            _sut.GetRows(_correct).Should().HaveCount(9);
        }

        [TestMethod]
        public void GetRows_CorrectRowsData()
        {
            var expectedResult = new List<int[]>
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
            var resultList = _sut.GetRows(_correct);
            resultList.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void GetColumns_CorrectNumberOfColumns()
        {
            _sut.GetColumns(_correct).Should().HaveCount(9);
        }

        [TestMethod]
        public void GetColumns_CorrectColumnsData()
        {
            var input = new int[][]
            {
                new[] {5, 3, 4},
                new[] {6, 7, 2},
                new[] {1, 9, 8}
            };

            var expectedResult = new List<int[]>
            {
                new[] {5, 6, 1},
                new[] {3, 7, 9},
                new[] {4, 2, 8}
            };
            var resultList = _sut.GetColumns(input);
            resultList.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void GetSectors_CorrectNumberOfSectors()
        {
            _sut.GetSectors(_correct).Should().HaveCount(9);
        }

        [TestMethod]
        public void GetSectors_CorrectSectorsData()
        {
            var input = new int[][]
            {
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
                new []{1,2,3,4,5,6,7,8,9},
            };

            var expectedResult = new List<int[]>
            {
                new[] {1,2,3,1,2,3,1,2,3},
                new[] {1,2,3,1,2,3,1,2,3},
                new[] {1,2,3,1,2,3,1,2,3},
                new[] {4,5,6, 4,5,6,4,5,6},
                new[] {4,5,6, 4,5,6,4,5,6},
                new[] {4,5,6, 4,5,6,4,5,6},
                new[] {7,8,9,7,8,9,7,8,9},
                new[] {7,8,9,7,8,9,7,8,9},
                new[] {7,8,9,7,8, 9, 7,8,9}
            };
            var resultList = _sut.GetSectors(input);
            resultList.Should().BeEquivalentTo(expectedResult);
        }


    }
}
