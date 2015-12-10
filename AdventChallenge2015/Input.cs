using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    internal class Input
    {
        //private static Dictionary<int, string> _inputData;

        public static List<string> GetTextInputData()
        {
            return File.ReadAllLines("day8.txt").ToList();
        }

        public static JsonInput GetInputData()
        {
            return JsonConvert.DeserializeObject<JsonInput>(File.ReadAllText("input.json"));
        }

        //public static string GetDayInput(int i)
        //{
        //    if (_inputData == null)
        //        _inputData = SetupInputData();

        //    return _inputData.
        //}

        //private static Dictionary<int, object> SetupInputData()
        //{
        //    var data = GetInputData();
        //    return new Dictionary<int, object>
        //    {
        //        {1, data.Day1 },
        //        {2, data.Day2 },
        //        {3, data.Day3 },
        //        {4, data.Day4 },
        //        {5, data.Day5 },
        //        {6, data.Day6 },
        //        {7, data.Day7 },
        //        {8, GetTextInputData() },
        //        {9, data.Day9 },
        //        {10, data.Day10 }
        //    };
        //}
    }
}
