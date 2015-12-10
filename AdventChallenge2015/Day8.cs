using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventChallenege2015
{
    static class Day8
    {
        public static int Solve1(List<string> input)
        {
            var originalLength = input.Sum(x => x.Length);
            var escapedLength =
                input.Select(x => x.Trim('"').Replace("\\\"", "\"").Replace("\\\\", "\\"))
                    .Select(x => Regex.Replace(x, "\\\\x[a-f0-9]{2}", "!"))
                    .Sum(x => x.Length);

            return originalLength - escapedLength;
        }

        public static int Solve2(List<string> input)
        {
            var originalLength = input.Sum(x => x.Length);
            var unescapedLength =
                input.Select(x => x.Replace("\\", "\\\\").Replace("\"", "\\\""))
                    .Select(x => $"\"{x}\"")
                    .Sum(x => x.Length);

            return unescapedLength - originalLength;
        }
    }
}