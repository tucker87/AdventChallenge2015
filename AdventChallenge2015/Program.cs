using System;
using System.IO;
using Newtonsoft.Json;

namespace AdventChallenege2015
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // The name of the file to open.
            const string fileName = "advent2Test.txt";

            // This will reference one line at a time

            try
            {
                // FileReader reads text files in the default encoding.
                using (var file = File.OpenText(fileName))
                {
                    double totalArea = 0;
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var maths = line;
                        var stringArray = maths.Split('x');
                        var intArray = new int[stringArray.Length];
                        for (var i = 0; i < stringArray.Length; i++)
                        {
                            var numberAsString = stringArray[i];
                            intArray[i] = int.Parse(numberAsString);
                        }
                        double sideLength = intArray[0];
                        double sideHeight = intArray[1];
                        double sideWidth = intArray[2];
                        double smallestSideArea;


                        var side1 = (2*(sideLength*sideWidth));
                        var side2 = (2*(sideHeight*sideWidth));
                        var side3 = (2*(sideLength*sideHeight));
                        if ((side1/2) < (side2/2))
                        {
                            smallestSideArea = Math.Min((side1/2), (side3/2));
                        }
                        else
                        {
                            smallestSideArea = Math.Min((side2/2), (side3/2));
                        }
                        var giftArea = (side1 + side2 + side3 + smallestSideArea);
                        totalArea = totalArea + giftArea;
                        Console.WriteLine(sideLength + " + " + sideHeight + " + " + sideWidth + " = " + giftArea);
                        Console.WriteLine(side1 + " + " + side2 + " * " + side3 + " + " + smallestSideArea + " = " +
                                          giftArea);
                        Console.WriteLine(totalArea);
                        Console.WriteLine("\n");
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Unable to open file '{0}'", fileName);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file '{0}'", fileName);
            }
            Console.ReadLine();
        }
    }
}
