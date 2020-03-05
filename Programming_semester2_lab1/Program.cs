using System;
using System.IO;
using System.Text;

namespace Programming_semester2_lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write path to directory to scan files:");
            string pathToFile = Console.ReadLine();
            string[] pathList = Directory.GetFiles(pathToFile ?? throw new InvalidOperationException(), "*.csv");
            //C:\Users\mihai\Source\repos\Introduction-To-Programming\labs_spring_2020\examples_2\var1 путь для копирования
            string writePath = @"C:\Users\mihai\Source\repos\Programming_semester2_lab1\Out_File.csv";
            using (FileStream fs = File.Create(writePath)) // создаем файл с предварительной разметкой столбцов
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Country,Score\n");
                fs.Write(info, 0, info.Length);
            }

            Reader reader = new Reader(pathList);
            Country[] countries = reader.ParseStringsToCountries();
            countries = Country.ProcessVotes(countries);
            foreach (var country in countries)
            {
                country.ShowInfo();
            }

            Country.WriteIntoFile(writePath, countries);

            Console.ReadKey();
        }
    }
}
