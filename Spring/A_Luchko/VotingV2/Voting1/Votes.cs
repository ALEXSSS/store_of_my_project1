using System;

namespace Voting
{
    public class Votes
    {
        private Voter[] people;
        private int numcandidates;
        public Votes(int numcandidates, int numpeople)
        {
            this.numcandidates = numcandidates;
            people = new Voter[numpeople];
            for (int i = 0; i < numpeople; i++)
            {
                people[i] = new Voter(numcandidates);
            }
        }
        private int[] ValueVotes()
        {
            Console.WriteLine("First tour!");
            int[] value_votes = new int[numcandidates];
            for (int i = 0; i < people.Length; i++)
            {
                value_votes[people[i].Vote()]++;
            }
            Console.WriteLine();
            return value_votes;
        }
        private int FirstTour(int[] value_votes)
        {
            int candidat_win1 = 0;
            int max = 0;
            int[] mass = value_votes;
            for (int i = 0; i < mass.Length; i++)
            {
                if (max < mass[i])
                {
                    max = mass[i];
                    candidat_win1 = i;
                }
            }
            return candidat_win1;
        }
        private void SecondTour(int[] value_votes)
        {
            Console.WriteLine("Second tour!!!");
            Console.WriteLine();
            int max = 0, candidat = 0, max1 = 0, candidat1 = 0;
            for (int i = 0; i < numcandidates; i++)
            {
                if (value_votes[i] == max)
                {
                    max1 = value_votes[i];
                    candidat1 = i;
                }
                else
                {
                    if (value_votes[i] > max)
                    {
                        max1 = max;
                        candidat1 = candidat;
                        candidat = i;
                        max = value_votes[i];
                    }
                    else
                    {
                        if (value_votes[i] > max1)
                        {
                            max1 = value_votes[i];
                            candidat1 = i;
                        }
                    }
                }
            }
            int[] value_votes2 = new int[2];
            for (int i = 0; i < people.Length; i++)
            {
                value_votes2[people[i].Vote2(candidat, candidat1)]++;
            }
            Console.WriteLine("{0}){1}  {2}){3}", candidat + 1, (double)value_votes2[0] / (double)people.Length, candidat1 + 1, (double)value_votes2[1] / (double)people.Length);
            if(value_votes2[0]>value_votes2[1])
            {
                Console.WriteLine("Win {0}", candidat + 1);
            }
            else
            {
                Console.WriteLine("Win {0}", candidat1 + 1);
            }
        }
        public void ShowVotes()
        {
            int[] value_votes = ValueVotes();
            for (int i = 0; i < numcandidates; i++)
            {
                Console.Write("{0}){1} ", i + 1, (double)value_votes[i] / (double)people.Length);
            }
            Console.WriteLine();
            int first_tour = FirstTour(value_votes);
            if (value_votes[first_tour] >= (people.Length / 2))
            {
                Console.WriteLine("Win {0}", first_tour + 1);
            }
            else
            {
                SecondTour(value_votes);
            }
            Console.ReadKey();
        }
    }
}
