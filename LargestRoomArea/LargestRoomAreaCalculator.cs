using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace LargestRoomArea
{
    public class LargestRoomAreaCalculator
    {
        public int GetLargestRoomSize(int[,] matrix)
        {
            Point? startingPoint = new Point(0,0);
            int biggestSize = 0;

            while ((startingPoint = FindNextEmpty(matrix, startingPoint)) != null) 
            {
              var size=  CalculateRoomSize(matrix, startingPoint);

              if (size > biggestSize)
              {
                  biggestSize = size;
              }
            }

            return biggestSize;
        }

        public Point? FindNextEmpty(int[,] matrix, Point? start)
        {
            if (start == null)
            {
                return null;
            }

            for(int i=start.Value.X; i< matrix.GetLength(0); i++)
            {
                for (int j = start.Value.Y; j< matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        return new Point(i, j);
                }
            }
            return null;
        }

        public int CalculateRoomSize(int[,] matrix, Point? roomStart)
        {
            if (roomStart == null)
            {
                return 0;
            }

            if (roomStart.Value.X < 0 || roomStart.Value.Y < 0 || roomStart.Value.X >= matrix.GetLength(0) || roomStart.Value.Y >= matrix.GetLength(1))
            {
                return 0;
            }

            if (matrix[roomStart.Value.X, roomStart.Value.Y] > 0)
                return 0;

            int roomSize = 1;

            matrix[roomStart.Value.X, roomStart.Value.Y] = 2;

            roomSize += CalculateRoomSize(matrix, new Point(roomStart.Value.X + 1, roomStart.Value.Y));

            roomSize += CalculateRoomSize(matrix, new Point(roomStart.Value.X, roomStart.Value.Y+1));

            roomSize += CalculateRoomSize(matrix, new Point(roomStart.Value.X -1, roomStart.Value.Y));
            roomSize += CalculateRoomSize(matrix, new Point(roomStart.Value.X , roomStart.Value.Y-1));

            return roomSize;
        }
    }
}