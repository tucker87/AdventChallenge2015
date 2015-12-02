using System.Linq;

namespace AdventChallenege2015
{
    internal class Day1
    {
        //138
        public static int Solve(string input)
        {
            return input
                .ToCharArray()
                .Select(x => x == '(' ? 1 : -1)
                .Sum();
        }
    }
}