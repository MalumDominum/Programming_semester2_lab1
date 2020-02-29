using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_semester2_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\mihai\\Source\\repos\\laba2programming\\tests\\eurovision1.csv";
            ReaderWriter reader = new ReaderWriter(path);
            Country[] countries = new Country[reader.Size];
            for (int i = 0; i < reader.Size; i++)
                countries[i] = ;
            Console.ReadKey();
        }
    }
}
