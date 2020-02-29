using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programming_semester2_lab1
{
    class ReaderWriter
    {
        public List<List<string>> List { get; }
        public int Size { get; }
        public ReaderWriter(string path)
        {
            using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            List = new List<List<string>>();
            Size = Convert.ToInt32(sr.ReadLine());
            while ((line = sr.ReadLine()) != null)
                List.Add((line.Split(',')).ToList());
        }
        public Country[] ParseStringsToCountries(ReaderWriter strings)
        {
            Country[] countries = new Country[strings.Size];
            for (int i = 0; i < strings.Size; i++)
            {
                string name = strings.List[i][0];
                int[] vote = new int[20];
                for (int j = 0; j < 20; j++)
                    vote[j] = Convert.ToInt32(strings.List[i][j + 1]);
                Country country = new Country(name, vote);
                countries[i] = country;
            }

            return countries;
        }
    }
}
