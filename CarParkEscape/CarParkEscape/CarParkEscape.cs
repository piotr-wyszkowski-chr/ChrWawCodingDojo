using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarParkEscape
{
    public class CarParkEscape
    {
        public string[] Escape(int[,] carpark)
        {
            List<FloorReturn> list = new List<FloorReturn>();

            int startIndex = -1;
            for (int i = 0; i < carpark.GetLength(0); i++)
            {
                int[] floor = GetRow(carpark, i);
                var result = SolveFloor(floor, startIndex);
                startIndex = result.StartPosition;
                list.Add(result);
            }
            return GetFinalResult(list);
        }

        public string[] GetFinalResult(List<FloorReturn> list)
        {
            FloorReturn previous = null;
            List<string> finalResult = new List<string>();
            foreach (var result in list)
            {
                if (previous == null)
                {
                    finalResult.Add((result.Direction == Direction.Left ? "L" : "R") + result.StepCount);
                }
                else
                {
                    
                }
                previous = result;
            }

            return finalResult.ToArray();
        }

        public int[] GetRow(int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public FloorReturn SolveFloor(int[] floor,int start = -1)
        {
            var result = new FloorReturn();
            if (start >= 0)
            {
                result.StartPosition = start;
            }
            else
            {
                if (floor.Contains(2))
                {
                    result.StartPosition = Array.IndexOf(floor, 2);
                }
                else
                {
                    result.StepCount = 0;
                    return result;
                }

            }
            var stairIndex = Array.IndexOf(floor, 1);

            if (stairIndex < 0)
            {
                stairIndex = floor.Length - 1;
            }
            result.Direction = stairIndex < result.StartPosition ? Direction.Left : Direction.Right;

            result.StepCount = Math.Abs(stairIndex - result.StartPosition);
            result.StartPosition = stairIndex;

            return result;

        }
    }
    public class FloorReturn
    {
        public Direction Direction { get; set; }
        public int StepCount { get; set; }
        public int StartPosition { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var ext = (FloorReturn)obj;
            return this.Direction == ext.Direction &&
                    this.StartPosition == ext.StartPosition &&
                    this.StepCount == ext.StepCount;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public enum Direction
    {
        Left,
        Right
    }
}
