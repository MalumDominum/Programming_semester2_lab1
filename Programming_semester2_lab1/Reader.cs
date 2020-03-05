using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Programming_semester2_lab1
{
    class Reader
    {
        private List<List<string>> List { get; }
        public int Size { get; }
        public Reader(string[] paths)
        {
            List = new List<List<string>>();
            for (int i = 0; i < paths.Length; i++)
            {
                using StreamReader sr = new StreamReader(paths[i], System.Text.Encoding.Default);
                string line;
                Size += Convert.ToInt32(sr.ReadLine());
                while ((line = sr.ReadLine()) != null)
                    List.Add((line.Split(',')).ToList());
            }
        }
        public Country[] ParseStringsToCountries()
        {
            Country[] countries = new Country[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                string name = this.List[i][0];
                int[] vote = new int[Size];
                for (int j = 0; j < Size; j++)
                    vote[j] = Convert.ToInt32(this.List[i][j + 1]);
                Country country = new Country(name, vote, this.Size);
                countries[i] = country;
            }

            return countries;
        }
    }
}
