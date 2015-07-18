using System;


namespace ValueVotings
{
    static class FirstTour
    {
        public static double[] percent_inf_for_candidat(int[][] votes)
        {
            //возвратит проценты проголосовавших по каждому кандидату
            double[] infforcandidat = new double[votes[0].Length];
            //значение проголосования по каждому кандидату
            int[] ValueforVoting = new int[votes[0].Length];
            for (int i = 0; i < votes[0].Length; i++) ValueforVoting[i] = 0;
            int vote;//какой-то выбор
            Random Randomvote = new Random();
            for (int i = 0; i < votes.Length; i++)
            {
                int candidat = 0;
                vote = Randomvote.Next(100);
                int summ = 0;
                while ((candidat <= votes[0].Length - 1) && (vote >= (votes[i][candidat] + summ)))
                {
                    summ += votes[i][candidat];
                    candidat++;
                }
                ValueforVoting[candidat]++;
            }
            for (int i = 0; i < votes[0].Length; i++) infforcandidat[i] = (((double)ValueforVoting[i]) / ((double)votes.Length)) * 100;
            return infforcandidat;
        }
    }
}
