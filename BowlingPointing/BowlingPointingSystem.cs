using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingPointing
{
    public class BowlingGame
    {
        private BowlingPointingSystem _bowlingPointingSystem = new BowlingPointingSystem();

        public int AddRound(int first, int second, int third = default)
        {
            Round round = new Round
            {
                First = first,
                Second = second,
                Third = third
            };
            _bowlingPointingSystem.AddRound(round);
            return _bowlingPointingSystem.TotalPoints;
        }
    }

    public class BowlingPointingSystem
    {
        private List<Round> _rounds = new List<Round>(10);
        private Round _lastRound = null;
        public static int AmountOfFrames => 10;

        public int TotalPoints
        {
            get { return _rounds.Sum(round => round.TotalResult); }
        }

        public void AddRound(Round round)
        {
            round.PreviousRound = _lastRound;
            _rounds.Add(round);
            _lastRound = round;
            CalculatePoints(round);
        }

        private void CalculatePoints(Round round)
        {
            round.TotalResult = round.First + round.Second + round.Third;

            if (round.PreviousRound?.PreviousRound?.ResultRoundType == ResultRoundType.Strike &&
                round.PreviousRound.ResultRoundType == ResultRoundType.Strike)
            {
                round.PreviousRound.PreviousRound.TotalResult += round.First;
            }

            if (round.PreviousRound?.ResultRoundType == ResultRoundType.Strike)
            {
                round.PreviousRound.TotalResult += round.First + round.Second;
            }

            if (round.PreviousRound?.ResultRoundType == ResultRoundType.Spare)
            {
                round.PreviousRound.TotalResult += round.First;
            }
            
        }
    }

    
    public class Round
    {
        public int Number { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
        public int Third { get; set; }

        public ResultRoundType ResultRoundType
        {
            get
            {
                if (First == 10)
                {
                    return ResultRoundType.Strike;
                }

                if (First + Second == 10)
                {
                    return ResultRoundType.Spare;
                }

                return ResultRoundType.Normal;
            }
        }

        public Round PreviousRound { get; set; }

        public int TotalResult { get; set; }
    }

    public enum ResultRoundType
    {
        Normal,
        Strike,
        Spare
    }

   
}
