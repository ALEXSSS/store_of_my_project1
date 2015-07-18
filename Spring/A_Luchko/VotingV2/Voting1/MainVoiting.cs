using System;
using Voting;
using System.IO;

namespace ValueVotings
{
    class MainVoiting
    {//происходит ввод информации, вызов генерирующих вероятностное распределение функций, подсчёт результатов
        static void Main(string[] args)
        {
            int numcandidates;
            int numpeople;
            Exception exParse;
            do
            {
                try
                {
                    exParse = null;
                    Console.Write("How many candidates? Enter the number: ");
                    numcandidates = int.Parse(Console.ReadLine());
                    Console.Write("How many votes? Enter the number: ");
                    numpeople = int.Parse(Console.ReadLine());
                    //Создали выборы
                    Votes votes = new Votes(numcandidates, numpeople);
                    votes.ShowVotes();
               }
                catch (Exception exc)
                {
                    exParse = exc;
                    Console.WriteLine("Repeat please.");
                }
            } while (exParse != null);
        }
    }
}
