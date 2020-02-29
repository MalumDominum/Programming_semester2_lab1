using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_semester2_lab1
{
    class Country
    {
        private string Name { get; }
        private int[] Vote { get; }
        private int SumVote { get; }
        private int Score { get; set; }

        public Country(string countryName, int[] vote)
        {
            Name = countryName;
            Vote = vote;
            foreach (int element in vote)
                SumVote += element;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Country: " + this.Name);

            Console.Write("Votes: ");
            foreach (var element in this.Vote)
                Console.Write("{0,7}", element);

            Console.WriteLine();
            Console.WriteLine("Sum Votes: " + this.SumVote);
            Console.WriteLine("Score: " + this.Score + "\n");
        }
        public Country[] ProcessVotes(Country[] countries)
        {
            for (int i = 0; i < countries.Length; i++)
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
            for (int k = 0; k < countries.Length; k++)
            {
                if (k == 0)
                    countries[k].Score = 12;
                
                else if (k == 1)
                    countries[k].Score = 10;

                else if (k <= 9)
                    countries[k].Score = 10 - k;

            }

            return countries;
        }
    }
}
