using System;

namespace BowlingPointing
{
    public class BowlingPointingSystem
    {
        public static int AmountOfFrames => 10;

        public int CalculatePoints(Round frame)
        {
            frame.TotalResult = frame.First + frame.Second + frame.Third;

            if (frame.PreviousRound?.PreviousRound?.ResultRoundType == ResultRoundType.Strike &&
                frame.PreviousRound.ResultRoundType == ResultRoundType.Strike)
            {
                frame.PreviousRound.PreviousRound.TotalResult += frame.First;
            }

            if (frame.PreviousRound?.ResultRoundType == ResultRoundType.Strike)
            {
                frame.PreviousRound.TotalResult += frame.First + frame.Second;
            }

            if (frame.PreviousRound?.ResultRoundType == ResultRoundType.Spare)
            {
                frame.PreviousRound.TotalResult += frame.First;
            }
            //if (frame.PreviousRound != null)
            //{
            //    Round previous = frame.PreviousRound;
            //    if (previous.ResultRoundType == ResultRoundType.Strike)
            //    {
            //        previous.TotalResult += frame.First+frame.Second;
            //        Round prevPreviousRound = previous.PreviousRound;
            //        if (prevPreviousRound != null)
            //        {
            //            if (prevPreviousRound.ResultRoundType == ResultRoundType.Strike)
            //            {
            //                prevPreviousRound.TotalResult += frame.First + frame.Second;
            //            }
            //        }
            //    }

            //}
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
