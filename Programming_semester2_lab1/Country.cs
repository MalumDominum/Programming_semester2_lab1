using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Programming_semester2_lab1
{
    class Country
    {
        private string Name { get; }
        private int[] Vote { get; }
        private int[] Scores { get; set; }
        private int FinalScore { get; set; }

        public Country(string countryName, int[] vote, int size)
        {
            Name = countryName;
            Vote = vote;
            Scores = new int[size];
            List<int> list = new List<int>(vote);

            for (int i = 0; i < vote.Length; i++)
            {
                int maxIndex = 0;
                int maxElement = list[0];
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] > maxElement)
                    {
                        maxIndex = j;
                        maxElement = list[j];
                    }
                }
                if (i == 0)
                    Scores[Array.IndexOf(vote, maxElement)] = 12;

                else if (i == 1)
                    Scores[Array.IndexOf(vote, maxElement)] = 10;

                else if (i <= 9)
                    Scores[Array.IndexOf(vote, maxElement)] = 10 - i;


                list.RemoveAt(maxIndex);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Country: " + this.Name);

            Console.Write("Votes: ");
            foreach (var element in this.Vote)
                Console.Write("{0,7}", element);
            Console.WriteLine();
            Console.Write("Scores:");
            foreach (var score in Scores)
            {
                Console.Write("{0,7}", score);
            }
            Console.WriteLine();
            Console.WriteLine("Final Score: " + FinalScore + "\n");
        }
        public static Country[] ProcessVotes(Country[] countries)
        {
            for (int i = 0; i < countries.Length; i++)
            {
                for (int j = 0; j < countries.Length; j++)
                {
                    countries[j].FinalScore += countries[i].Scores[j];
                }
            }

            return countries;
        }
        public static void WriteIntoFile(string writePath, Country[] countries)
        {
            for (int i = 0; i < countries.Length; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < countries.Length; j++)
                    if (countries[j].FinalScore > countries[maxIndex].FinalScore)
                        maxIndex = j;
                if (i != maxIndex)
                {
                    Country temp = countries[i];
                    countries[i] = countries[maxIndex];
                    countries[maxIndex] = temp;
                }
            }
            using StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default);
            foreach (var country in countries)
            {
                sw.WriteLine(country.Name + "," + country.FinalScore);
            }
        }
    }
}
