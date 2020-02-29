using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_semester2_lab1
{
    class Country
    {
        public string CountryName { get; }
        public int[] Vote { get; }
        public int FinalVote { get; }
        public int Score { get; }
        public Country(string countryName, int[] vote)
        {
            CountryName = countryName;
            Vote = vote;
            foreach (int element in vote)
                FinalVote += element;
        }
    }
}
