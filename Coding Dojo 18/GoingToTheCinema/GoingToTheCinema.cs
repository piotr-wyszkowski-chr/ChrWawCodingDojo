using System;

namespace GoingToTheCinema
{
    public class GoingToTheCinema
    {
        public static int Movie(int card, int ticket, double perc)
        {
            int entrance = 0;
            double SumA = 0.0;
            double SumB = 0.0;

            do
            {
                entrance++;
                SumA = calculateSumA(entrance, ticket);
                SumB = Math.Ceiling(calculateSumB(entrance, card, ticket, perc));
            }
            while (SumA <= SumB);

            return entrance;
        }

        private static double calculateSumA(int entrance, int ticket)
        {
            return entrance * ticket;
        }

        private static double calculateSumB(int entrance, int card, int ticket, double perc)
        {
            double sumB = 0.0;
            sumB = card;

            for (int i = 1; i <= entrance; i++)
            {
                sumB += ticket * Math.Pow(perc, i);
            }
            return sumB;
        }
    }
}
