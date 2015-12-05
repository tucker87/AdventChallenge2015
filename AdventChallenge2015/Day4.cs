using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventChallenege2015
{
    static class Day4
    {
        //117946
        //3938038

        public static int Solve(string input, string condition)
        {
            var current = 0;
            var found = false;
            var hash = new Tuple<int, string>(0, "");
            while (!found)
            {
                hash = GetHash(input, current++);
                found = hash.Item2.Contains(condition);
            }
            return hash.Item1;
        }

        public static async Task<int> SolveAsync(string input, string condition)
        {
            var current = 0;
            const int step = 500;
            var found = false;
            var result = 0;
            while (!found)
            {
                var tasks = new List<Task<Dictionary<int, string>>>();
                for (var i = 0; i < 10; i++)
                    tasks.Add(GetHashesAsync(input, current + 1, current += step));

                await Task.WhenAll(tasks);

                foreach (var task in tasks)
                {
                    found = task.Result.Any(x => x.Value.Contains(condition));
                    if (found)
                    {
                        result = task.Result.First(x => x.Value.Contains(condition)).Key; 
                        break;
                    }
                }
            }

            return result;
        }

        public static Task<Dictionary<int, string>> GetHashesAsync(string input, int start, int stop)
        {
            return Task<Dictionary<int, string>>.Factory.StartNew(() => GetHashes(input, start, stop));
        }

        private static Dictionary<int, string> GetHashes(string input, int start, int stop)
        {
            var hashes = new Dictionary<int, string>();
            var current = start;
            while (current <= stop)
            {
                var hash = GetHash(input, current++);
                hashes.Add(hash.Item1, hash.Item2);
            }
            return hashes;
        } 

        private static Tuple<int, string> GetHash(string input, int step)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input + step));
                return new Tuple<int, string>(step, string.Join("", data.Take(3).Select(x => x.ToString("x2")).ToArray()));
            }
        }
    }
}
