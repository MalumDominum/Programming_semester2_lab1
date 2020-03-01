using System;
using System.IO;
using System.Text;

namespace Programming_semester2_lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] pathList = Directory.GetFiles(@"C:\Users\mihai\Source\repos\laba2programming\tests", "*.csv");
            string writePath = @"C:\Users\mihai\Source\repos\Programming_semester2_lab1\Out_File.csv";
            using (FileStream fs = File.Create(writePath)) // создаем файл с предварительной разметкой столбцов
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Country,SumVotes,Score\n");
                fs.Write(info, 0, info.Length);
            }

            foreach (var path in pathList) // проходимся по всем файлам *.csv
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
