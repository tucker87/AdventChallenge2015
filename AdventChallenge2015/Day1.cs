using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    internal class Day1
    {
        //138
        public static int Solve1(string input)
        {
            return ParseInput(input).Sum();
        }

        //1771
        public static int Solve2(string input)
        {
            var dataSet = ParseInput(input);
            var answer = 0;
            var i = 0;
            while(answer >= 0)
                answer += dataSet[++i - 1];

            return i;
        }

        public static List<int> ParseInput(string input)
        {
            return input
                .ToCharArray()
                .Select(x => x == '(' ? 1 : -1).ToList();
        } 
    }
}