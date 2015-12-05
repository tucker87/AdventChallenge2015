using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventChallenege2015
{
    internal class Day5
    {
        static readonly string[] Restricted = { "ab", "cd", "pq", "xy" };
        const string Vowels = "aeiou";

        public static int Solve1(List<string> input)
        {
            //return input.Select(Judge).Count(x => x);
            return input.Select(JudgeRegex).Count(x => x);
        }

        private static bool JudgeRegex(string child)
        {
            var hasThreeVowels = Regex.Match(child, @"([aeiou].*){3,}").Success;
            var hasDoubleUp = Regex.Match(child, @"(.)\1").Success;
            var hasRestricted = Regex.Match(child, @"(ab|cd|pq|xy)").Success;
            return (hasThreeVowels && hasDoubleUp && !hasRestricted);
        }

        //Replaced this with Regex version.
        private static bool Judge(string child)
        {
            bool hasDoubleUp = false, hasRestricted = false;
            
            var hasThreeVowels = child.Count(chr => Vowels.Contains(char.ToLowerInvariant(chr))) >= 3;

            for (var i = 0; i < child.Length - 1; i++)
            {
                if (child[i] == child[i + 1])
                {
                    hasDoubleUp = true;
                    break;
                }
            }
            
            if (Restricted.Any(child.Contains))
                hasRestricted = true;

            return (hasThreeVowels && hasDoubleUp && !hasRestricted);
        }

        public static int Solve2(List<string> input)
        {
            return input.Select(Judge2).Count(x => x);
        }

        private static bool Judge2(string child)
        {
            var hasCouple = Regex.Match(child, @"(.{2}).*\1").Success;
            var hasSplit = Regex.Match(child, @"(.).\1").Success;

            return (hasCouple && hasSplit);
        }
    }
}