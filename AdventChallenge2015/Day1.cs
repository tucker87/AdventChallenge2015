using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    internal class Day1
    {
        //138
        public static string Solve1<TIn>(TIn input)
        {
            return ParseInput(input.ToString()).Sum().ToString();
        }

        //1771
        public static string Solve2<TIn>(TIn input)
        {
            var dataSet = ParseInput(input.ToString());
            var answer = 0;
            var i = 0;
            while(answer >= 0)
                answer += dataSet[++i - 1];

            return i.ToString();
        }

        public static List<int> ParseInput(string input)
        {
            return input
                .ToCharArray()
                .Select(x => x == '(' ? 1 : -1).ToList();
        } 
    }
}