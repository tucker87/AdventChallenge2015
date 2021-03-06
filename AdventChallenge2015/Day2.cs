﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    public class Day2
    {
        public Day2(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public int PaperAmount => (2*Side1) + (2*Side2) + (2*Side3) + new[] {Side1, Side2, Side3}.Min();

        public int RibbonAmount
            =>
                new[] {Length, Width, Height}.OrderBy(x => x).Take(2).Select(x => x*2).Sum() +
                (Length*Width*Height);

        public int Side1 => Length*Width;
        public int Side2 => Width*Height;
        public int Side3 => Height*Length;
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //1606483
        public static int Solve1(List<string> input)
        {
            return ParseInput(input)
                .Select(x => x.PaperAmount)
                .Sum();
        }

        //3842356
        public static int Solve2(List<string> input)
        {
            return ParseInput(input)
                .Select(x => x.RibbonAmount)
                .Sum();
        }

        public static List<Day2> ParseInput(List<string> input)
        {
            return input
                .Select(x => x.Split('x'))
                .Select(x => x.Select(y => Convert.ToInt32(y)).ToArray())
                .Select(x => new Day2(x[0], x[1], x[2]))
                .ToList();
        }
    }
}