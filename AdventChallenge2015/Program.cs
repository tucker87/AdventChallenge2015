using System;
using System.IO;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day1.Solve(GetInputData().Day1));
            Console.WriteLine(Day2.Solve(GetInputData().Day2));
            Console.ReadLine();
        }

        public static JsonInput GetInputData()
        {
            return JsonConvert.DeserializeObject<JsonInput>(File.ReadAllText("input.json"));
        }
    }
}
