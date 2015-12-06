using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventChallenege2015
{
    static class Day4
    {
        //117946
        //3938038
        public static int Solve(string input, string condition)
        {
            return NextHash(input).First(hash => FoundHash(hash.Item2, condition)).Item1;
        }

        public static int Solve2(string input, string condition)
        {
            return FindHashAsync(input, condition).Result;
        }

        private static async Task<int> FindHashAsync(string input, string condition)
        {
            var start = 0;
            const int batchSize = 250;
            var found = false;
            var tasks = new List<Task<int>>();
            for (var i = 0; i < 8; i++)
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    using (var md5 = MD5.Create())
                        while (!found)
                        {
                            var batch = NextHashBatch(md5, input, start++, start += batchSize);
                            if (batch.Count(x => FoundHash(x.Value, condition)) > 0)
                                return batch.First(x => FoundHash(x.Value, condition)).Key;
                        }
                    return -1;
                }));

            await Task.WhenAny(tasks);
            found = true;
            return tasks.First(x => x.Result != -1).Result;
        }

        private static bool FoundHash(string hash, string condition)
        {
            return hash.Contains(condition);
        }

        private static Dictionary<int, string> NextHashBatch(HashAlgorithm md5, string input, int start, int batchSize)
        {
            var hashBatch = new Dictionary<int, string>();
                for (var i = start; i < batchSize; i++)
                {
                    var hash = GetHash(md5, input, i);
                    hashBatch.Add(hash.Item1, hash.Item2);
                }
            return hashBatch;
        }

        private static IEnumerable<Tuple<int, string>> NextHash(string input)
        {
            using(var md5 = MD5.Create())
                for (var i = 0; i < int.MaxValue; i++)
                    yield return GetHash(md5, input, i);

            throw new Exception("Hit int max!");
        }

        private static Tuple<int, string> GetHash(HashAlgorithm md5, string input, int step)
        {
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input + step));
            return new Tuple<int, string>(step, string.Join("", data.Select(x => x.ToString("x2")).ToArray()));
        }
    }
}
