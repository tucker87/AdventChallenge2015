using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    internal class Day6
    {
        public static int Solve(List<string> input)
        {
            var grid = RunActions(input);
            return FindBrightness(grid);
        }

        public static int Solve2(List<string> input)
        {
            input = FixTranslation(input);
            var grid = RunActions(input);
            return FindBrightness(grid);
        }

        private static int FindBrightness(int[,] grid)
        {
            var count = 0;
            for (var r = 0; r < 1000; r++)
                for (var c = 0; c < 1000; c++)
                    count += grid[r,c];

            return count;
        }

        private static List<string> FixTranslation(IEnumerable<string> input)
        {
            return input.Select(x => x.Replace("turn on", "add"))
                .Select(x => x.Replace("toggle", "add two"))
                .Select(x => x.Replace("turn off", "subtract"))
                .ToList();
        }

        private static int[,] RunActions(IEnumerable<string> input)
        {
            var grid = new int[1000,1000];

            foreach (var instruction in input)
            {
                var function = GetFunction(instruction);
                var coord = GetCoord(instruction);
                TakeAction(grid, coord, function);
            }
            return grid;
        }

        private static Func<int, int> GetFunction(string instruction)
        {
            if (instruction.Contains("turn off"))
                return i => 0;

            if (instruction.Contains("turn on"))
                return i => 1;

            if (instruction.Contains("toggle"))
                return i => i == 0 ? 1 : 0;

            if (instruction.Contains("subtract"))
                return i =>
                {
                    if (i > 0)
                        return --i;

                    return i;
                };

            if (instruction.Contains("add"))
                return i => ++i;

            if (instruction.Contains("add two"))
                return i => i + 2;

            throw new Exception("Command not found!");
        }

        private static Coord GetCoord(string instruction)
        {
            return new Coord(instruction.Split(' ')
                .Where(x => x.Contains(','))
                .SelectMany(x => x.Split(','))
                .Select(x => Convert.ToInt32(x)).ToList());
        }

        private static void TakeAction(int[,] grid, Coord coord, Func<int, int> function)
        {
            for (var r = coord.X; r <= coord.X2; r++)
                for (var c = coord.Y; c <= coord.Y2; c++)
                    grid[r,c] = function.Invoke(grid[r,c]);
        }
    }

    class Coord
    {
        public Coord(List<int> coords)
        {
            X = coords[0];
            Y = coords[1];
            X2 = coords[2];
            Y2 = coords[3];
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}