using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Day1.Solve1(GetInputData().Day1));
            //Console.WriteLine(Day1.Solve2(GetInputData().Day1));
            //Console.WriteLine(Day2.Solve1(GetInputData().Day2));
            //Console.WriteLine(Day2.Solve2(GetInputData().Day2));
            //Console.WriteLine(Day3.Solve1(GetInputData().Day3));
            //Console.WriteLine(Day3.Solve2(GetInputData().Day3));
            //Console.WriteLine(Day4.Solve(GetInputData().Day4, "00000"));
            //Console.WriteLine(Day4.Solve(GetInputData().Day4, "000000"));
            //Console.WriteLine(Day4.Solve2(GetInputData().Day4, "00000"));
            //Console.WriteLine(Day4.Solve2(GetInputData().Day4, "000000"));
            //Console.WriteLine(Day5.Solve1(GetInputData().Day5));
            //Console.WriteLine(Day5.Solve2(GetInputData().Day5));
            Console.WriteLine(Day6.Solve(GetInputData().Day6));
            Console.WriteLine(Day6.Solve2(GetInputData().Day6));
            Console.WriteLine(new Day7().Solve1(GetInputData().Day7));
            Console.WriteLine(new Day7().Solve2(GetInputData().Day7));

            Console.ReadLine();
        }

        public static JsonInput GetInputData()
        {
            return JsonConvert.DeserializeObject<JsonInput>(File.ReadAllText("input.json"));
        }
    }
}
