using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day1.Solve1(GetInputData().Day1));
            Console.WriteLine(Day1.Solve2(GetInputData().Day1));
            Console.WriteLine(Day2.Solve1(GetInputData().Day2));
            Console.WriteLine(Day2.Solve2(GetInputData().Day2));
            Console.ReadLine();
        }

        public static JsonInput GetInputData()
        {
            return JsonConvert.DeserializeObject<JsonInput>(File.ReadAllText("input.json"));
        }
    }
}
