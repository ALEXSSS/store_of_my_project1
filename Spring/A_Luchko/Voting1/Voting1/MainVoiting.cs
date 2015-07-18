using System;
using Voting;

namespace ValueVotings
{
    class MainVoiting
    {//происходит ввод информации, вызов генерирующих вероятностное распределение функций, подсчёт результатов
        static void Main(string[] args)
        {
            int numcandidates;
            int numpeople;
            Exception exParse;
            bool firsttour = false;
            do
            {
                try
                {
                    exParse = null;
                    Console.Write("How many candidates? Enter the number: ");
                    numcandidates = int.Parse(Console.ReadLine());
                    Console.Write("How many votes? Enter the number: ");
                    numpeople = int.Parse(Console.ReadLine());
                    if ((numpeople <= 0) || (numcandidates <= 0)) throw exParse;
                    int[][] votesinf = Votes.create_voting(numcandidates, numpeople);
                    double[] infpercent = FirstTour.percent_inf_for_candidat(votesinf);
                    for (int i = 0; i < numcandidates; i++)
                    {
                        Console.Write(" " + infpercent[i]);
                    }
                    Console.WriteLine();
                    for (int i = 0; i < numcandidates; i++)
                    {
                        if (infpercent[i] > 50)
                        {
                            Console.WriteLine("Win {0}", i + 1);
                            firsttour = true;
                            break;
                        }
                    }
                    Console.ReadKey();
                    if (firsttour != true)
                    {
                        int max = 0, max1 = 0;
                        double maxvalue = 0;//*
                        double maxvalue1 = 0;
                        for (int j = 0; j < infpercent.Length; j++)
                        {
                            if (maxvalue <= infpercent[j])
                            {
                                if (maxvalue == infpercent[j])
                                {
                                    max1 = j;
                                }
                                else
                                {
                                    max1 = max;
                                    max = j;
                                    maxvalue = infpercent[j];
                                }
                            }
                            else
                            {
                                if (maxvalue1 < infpercent[j])
                                {
                                    max1 = j;
                                    maxvalue1 = infpercent[j];
                                }
                            }
                        }
                        Random voit = new Random();
                        double[] newinfcandidat = Secondtour.second_tour(votesinf, max, max1, voit);
                        Console.WriteLine();
                        Console.WriteLine("Second tour: candidat {0}){1}  candidat {2}){3}", ++max, newinfcandidat[0], ++max1, newinfcandidat[1]);
                        if (newinfcandidat[0] >= newinfcandidat[1])
                        {
                            Console.WriteLine("Win {0}!", max);
                        }
                        else
                        {
                            Console.WriteLine("Win {0}!", max1);
                        }
                        Console.ReadKey();
                    }
                }
                catch (Exception exc)
                {
                    exParse = exc;
                    Console.WriteLine("Repead please.");
                }
            } while (exParse != null);
        }
    }
}
