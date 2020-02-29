using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_semester2_lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] pathList = Directory.GetFiles(@"C:\Users\mihai\Source\repos\laba2programming\tests", "*.csv");
            string writePath = @"C:\Users\mihai\Source\repos\Programming_semester2_lab1\Out_File.csv";
            using (FileStream fs = File.Create(writePath)) { }

            foreach (var path in pathList)
            {
                Reader reader = new Reader(path);
                Country[] countries = reader.ParseStringsToCountries();
                countries = Country.ProcessVotes(countries);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Path to File: ");
                Console.WriteLine(path + "\n");
                Console.ResetColor();
                foreach (var country in countries)
                {
                    country.ShowInfo();
                }

                Country.WriteIntoFile(writePath, countries);
            }

            Console.ReadKey();
        }
    }
}
