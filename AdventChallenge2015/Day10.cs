using System.Linq;
using System.Text.RegularExpressions;

namespace AdventChallenege2015
{
    public class Day10
    {
        //492982
        public static int Solve1(string input)
        {
            return RunALot(input, 40);
        }

        public static int Solve2(string input)
        {
            return RunALot(input, 50);
        }

        public static int RunALot(string input, int count)
        {
            for (var i = 1; i <= count; i++)
                input = LookAndSay(input);

            return input.Length;
        }

        public static string LookAndSay(string input)
        {
            var captures = Regex.Match(input, @"((.)\2*)*").Groups[1].Captures.Cast<Capture>();
            return string.Concat(captures.Select(x => "" + x.Value.Length + x.Value.First()));
        }
    }
}