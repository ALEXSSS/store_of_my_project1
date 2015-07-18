using System;

namespace Voting
{
    public static class Votes
    {
        public static int[][] create_voting(int numcandidates, int numpeople)
        {
            int[][] Votings = new int[numpeople][];
            Random percentage = new Random();
            for (int i = 0; i < numpeople; i++)
            {
                Votings[i] = Probabilityofselection.random_probability(numcandidates, percentage).percent_for_candidates;
            }
            return Votings;
        }
    }
    struct Voter
    {
        public int[] percent_for_candidates;
    }
}
