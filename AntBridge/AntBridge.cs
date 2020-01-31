using System;
using System.Linq;

namespace AntBridge
{
    public class AntBridge
    {
        public string Bridge(string ants, string terrain)
        {
            terrain = terrain.Replace(".-.", "...");
            var gaps = GetGapsSum(terrain);

            // Your code here!
            return GetShift(gaps,ants);
        }

        public int GetGapsSum(string terrain)
        {
            var gaps =
                terrain.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
            var gapsCount = gaps.Sum(x => x.Length + 2);
            return gapsCount;
        }

        public string GetShift(int count, string ants)
        {
            var shiftLength = count % ants.Length;
            var rightSide = ants.Substring(ants.Length - shiftLength, shiftLength);
            var leftSide = ants.Substring(0, ants.Length- shiftLength);
            return rightSide + leftSide;
        }
    }
}