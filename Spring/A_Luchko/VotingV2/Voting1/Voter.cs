using System;

namespace Voting
{
    class Voter
    {
        private int[] percent_for_candidates;
        private int numcandidates;
        static Random percentage = new Random();

        public Voter(int numcandidates)
        {
            this.numcandidates = numcandidates;
            percent_for_candidates = RandomProbability();
        }

        private int[] RandomProbability()
        {

            int save_procent = 0;
            int[] percent = new int[numcandidates];
            for (int i = 0; i < numcandidates - 1; i++)
            {
                percent[i] = percentage.Next(100 - numcandidates + i - save_procent + 1);
                save_procent += percent[i];
            }
            percent[numcandidates - 1] = 100 - save_procent;
            return percent;
        }
        public int Vote()
        {
            int vote = percentage.Next(100);
            int save_value = 0;
            int save_candidates = 0;
            for (int i = 0; i < numcandidates; i++)
            {
                save_value += percent_for_candidates[i];
                if (save_value <= vote)
                {
                    save_candidates++;
                }
                else
                {
                    break;
                }
            }
            return save_candidates;
        }
        public int Vote2(int candidat, int candidat1)
        {
            int summ_percent = percent_for_candidates[candidat] + percent_for_candidates[candidat1];
            if (((double)(percent_for_candidates[candidat] / (double)summ_percent) * 100 >= percentage.NextDouble() * 100))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
