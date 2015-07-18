using System;

namespace Voting
{
    static class Probabilityofselection
    {
        public static Voter random_probability(int numcandidates, Random procentcandidates)
        {
            int saveprocent = 0;
            int[] procent = new int[numcandidates];
            for (int i = 0; i < numcandidates - 1; i++)
            {
                procent[i] = procentcandidates.Next(100 - numcandidates + i - saveprocent + 1);
                saveprocent += procent[i];
            }
            procent[numcandidates - 1] = 100 - saveprocent;
            Voter vote;
            vote.percent_for_candidates = procent;
            return vote;
        }
    }
}
