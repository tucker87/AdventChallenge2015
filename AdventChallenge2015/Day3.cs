using System;
using System.Collections.Generic;

namespace AdventChallenege2015
{
    static class Day3
    {
        //2565
        public static int Solve1(string input)
        {
            var santa = new Position(0, 0);
            var houses = new HashSet<Tuple<int, int>> { new Tuple<int, int>(0, 0) };
            foreach (var direction in input)
                santa.Move(direction).DeliverPresent(houses);

            return houses.Count;
        }

        public static int Solve2(string input)
        {
            var santa = new Position(0, 0);
            var robot = new Position(0, 0);
            var houses = new HashSet<Tuple<int, int>> { new Tuple<int, int>(0, 0) };

            var moveSanta = true;
            foreach (var direction in input)
            {
                if(moveSanta)
                    santa.Move(direction).DeliverPresent(houses);
                else
                    robot.Move(direction).DeliverPresent(houses);

                moveSanta = !moveSanta;
            }
            return houses.Count;
        }

        private static Position Move(this Position position, char direction)
        {
            switch (direction)
            {
                case '<':
                    position.X--;
                    break;
                case '>':
                    position.X++;
                    break;
                case '^':
                    position.Y--;
                    break;
                case 'v':
                    position.Y++;
                    break;
                default:
                    throw new Exception("WTF?");
            }
            return position;
        }

        private static void DeliverPresent(this Position position, HashSet<Tuple<int, int>> visited)
        {
            visited.Add(new Tuple<int, int>(position.X, position.Y));
        }
    }

    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
