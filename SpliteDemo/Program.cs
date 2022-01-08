using System;

namespace SpliteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "amir,amiri,12";
            string[] data = line.Split(",");
            Console.WriteLine(data[0]);
            Console.WriteLine(data[1]);
            Console.WriteLine(data[2]);


        }
    }
}
