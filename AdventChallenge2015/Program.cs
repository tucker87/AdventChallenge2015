using System;
using System.IO;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day1.Solve1(GetInputData().Day1));
            Console.WriteLine(Day1.Solve2(GetInputData().Day1));
            Console.WriteLine(Day2.Solve1(GetInputData().Day2));
            Console.WriteLine(Day2.Solve2(GetInputData().Day2));
            Console.WriteLine(Day3.Solve1(GetInputData().Day3));
            Console.WriteLine(Day3.Solve2(GetInputData().Day3));
            Console.WriteLine(Day4.SolveAsync(GetInputData().Day4, "00000").Result);
            Console.WriteLine(Day4.SolveAsync(GetInputData().Day4, "000000").Result);

            Console.ReadLine();
        }

        public static JsonInput GetInputData()
        {
            return JsonConvert.DeserializeObject<JsonInput>(File.ReadAllText("input.json"));
        }
    }
}
