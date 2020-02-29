using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_semester2_lab1
{
    class Country
    {
        public string Name { get; }
        public int[] Vote { get; }
        public int SumVote { get; }
        public int Score { get; }
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
            for (int i = 0; i < this.Vote.Length; i++)
            {
                Console.Write("{0,7}", this.Vote[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Sum Votes: " + SumVote);
            Console.WriteLine();
        }
    }
}
