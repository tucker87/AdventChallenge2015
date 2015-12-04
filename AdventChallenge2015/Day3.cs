using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventChallenege2015
{
    class Day3
    {
        public static HashSet<Tuple<int, int>> Visited { get; set; }

        public static int Solve1(string input)
        {
            var x = 0;
            var y = 0;
            foreach (var direction in input)
            {
                switch (direction)
                {
                    case '<':
                        x--;
                        Insert(x, y);
                        break;
                    case '>':
                        x++;
                        break;
                    case '^':
                        y--;
                        break;
                    case 'v':
                        y++;
                        break;
                }
            }
            return Visited.Count;

        }

        private static void Insert(int x, int y)
        {
            Visited.Add(new Tuple<int, int>(x, y));
        }
    }
}
