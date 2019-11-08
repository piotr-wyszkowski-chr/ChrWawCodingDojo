using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuValidator
{
    public class SudokuValidator
    {
        public bool Validate(int[][] input)
        {
            return GetRows(input).All(IsValid) && GetColumns(input).All(IsValid) && GetSectors(input).All(IsValid);
        }

        public bool IsValid(int[] input)
        {
            if (input.Length != 9)
            {
                return false;
            }

            if (!input.All(x => x >= 1 && x <= 9))
            {
                return false;
            }

            if (input.Distinct().Count() != 9)
            {
                return false;
            }

            return true;
        }


        public List<int[]> GetRows(int[][] input)
        {
            return input.ToList();
        }

        public List<int[]> GetColumns(int[][] input)
        {
            var columns = new List<int[]>();
            for (int i = 0; i < input.Length; i++)
            {
                var revertedColumn = new int[input.Length];
                for (int j = 0; j < input[i].Length; j++)
                {
                    revertedColumn[j] = input[j][i];
                }
                columns.Add(revertedColumn);
            }

            return columns;
        }

        public List<int[]> GetSectors(int[][] input)
        {
            var sectors = new List<int[]>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sectors.Add(GetSector(input, i, j));
                }
            }

            return sectors;
        }

        private int[] GetSector(int[][] input, int sectorX, int sectorY)
        {
            var sector = new int[9];
            int sectorIndex = 0;
            for (int i = sectorX * 3; i < sectorX * 3 + 3; i++)
            {
                for (int j = sectorY * 3; j < sectorY * 3 + 3; j++)
                {
                    sector[sectorIndex++] = input[i][j];
                }
            }

            return sector;
        }
    }
}