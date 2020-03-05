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
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
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
                dictionary.Add(maxIndex, maxElement);
                list.RemoveAt(maxIndex);
            }
            for (int i = 0; i < vote.Length; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < vote.Length; j++)
                    if (vote[j] > vote[maxIndex])
                        maxIndex = j;
                if (i != maxIndex)
                {
                    var temp = vote[i];
                    vote[i] = vote[maxIndex];
                    vote[maxIndex] = temp;
                }
            }
            for (int k = 0; k < vote.Length; k++)
            {
                if (k == 0)
                    Scores[k] = 12;

                else if (k == 1)
                    Scores[k] = 10;

                else if (k <= 9)
                    Scores[k] = 10 - k;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Country: " + this.Name);

            Console.Write("Votes: ");
            foreach (var element in this.Vote)
                Console.Write("{0,7}", element);
            Console.WriteLine();
            Console.Write("Scores: ");
            foreach (var score in Scores)
            {
                Console.Write(score + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Final Score: " + FinalScore + "\n");
        }
        /*public static Country[] ProcessVotes(Country[] countries)
        {
            for (int i = 0; i < countries.Length; i++) // сортировка по значению SumVote
            {
                int maxIndex = i;
                for (int j = i + 1; j < countries.Length; j++)
                    if (countries[j].SumVote > countries[maxIndex].SumVote)
                        maxIndex = j;
                if (i != maxIndex)
                {
                    Country temp = countries[i];
                    countries[i] = countries[maxIndex];
                    countries[maxIndex] = temp;
                }

            }
            for (int k = 0; k < countries.Length; k++) // Выдача странам значения Score
            {
                if (k == 0)
                    countries[k].Score = 12;
                
                else if (k == 1)
                    countries[k].Score = 10;

                else if (k <= 9)
                    countries[k].Score = 10 - k;
            }

            return countries;
        }*/

//        public static void WriteIntoFile(string writePath, Country[] countries)
//        {
//            using StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default);
//            foreach (var country in countries)
//            {
//                sw.WriteLine(country.Name + "," + country.SumVote + "," + country.Score);
//            }
//        }
    }
}
