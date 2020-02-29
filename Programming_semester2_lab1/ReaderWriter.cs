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
        public int Size { get; }
        public string[] CountryName { get; }
        public int[,] Vote { get; }
        public ReaderWriter(string path)
        {
            using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            var list = new List<List<string>>();
            Size = Convert.ToInt32(sr.ReadLine());
            while ((line = sr.ReadLine()) != null)
                list.Add((line.Split(',')).ToList());
            CountryName = new string[Size];
            Vote = new int[Size, 20];
            for (int i = 0; i < Size; i++)
                CountryName[i] = list[i][0];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < 20; j++)
                    Vote[i, j] = Convert.ToInt32(list[i][j + 1]);
            
//            for (int i = 0; i < vote.GetUpperBound(0) + 1; i++)
//            {
//                for (int j = 0; j < vote.GetUpperBound(1) + 1; j++)
//                {
//                    Console.Write("{0,8}", vote[i, j]);
//                }
//                Console.WriteLine();
//            }
        }
    }
}
