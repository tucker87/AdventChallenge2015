using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventChallenege2015
{
    class FirstPart
    {
        private static void Main(string[] args)
        {
            var i = 0;
            var floor = 0;
            Console.WriteLine("Enter the code: ");
            var entry = Console.ReadLine();
            while (i < entry.Length)
            {
                if (entry[i] == '(')
                {
                    floor++;
                }
                else if (entry[i] == ')')
                {
                    floor--;
                    if (floor == -1)
                    {
                        Console.WriteLine("Basement entered at: " + (i + 1));
                    }
                }
                i++;
            }
            Console.WriteLine("Floor: " + floor);
        }
    }
}
