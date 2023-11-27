using System;
using System.IO;
using SeaCucumber.Models;
using SeaCucumber.Services.Interfaces;

namespace SeaCucumber.Services
{
    public class CucumberService : ICucumberService
    {
        /// <summary>
        /// Initialize the cucumberfield with the data from an file.
        /// </summary>
        /// <returns>char[,,]</returns>
        public char[,] Init()
        {
            string cucumberdata = ".\\CucumberField.txt";
            var readerService = new FileReaderService();
            if (File.Exists(cucumberdata))
            {
                return readerService.ReadFile(cucumberdata);
            }
            else
            {
                Console.WriteLine("No CucumberField.txt file found in the SeaCucumber directory.");
            }
            return null;
        }

        /// <summary>
        /// Calculate the amount of steps before the Cucumberfield stops.
        /// </summary>
        /// <returns>int steps</returns>
        public int CalculateSteps()
        {
            int steps = 0;
            var herdService = new HerdService();
            var printFieldService = new PrintFieldService();
            var CucumberField = Init();

            if (CucumberField != null)
            {
                bool moveCucumbers = true;
                int rows = CucumberField.GetLength(0);
                int cols = CucumberField.GetLength(1);
                Seabed seabed = new();
                if (rows > 1000 || cols > 1000)
                {
                    Console.WriteLine("The seacucumberfield is too big.");
                    moveCucumbers = false;
                }
                else
                {
                    seabed.CucumberField = CucumberField;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Initial state:");
                    printFieldService.PrintField(seabed);
                }
                while (moveCucumbers != false)
                {
                    seabed = herdService.EastMovingHerd(seabed);
                    seabed = herdService.SouthMovingHerd(seabed);
                    steps++;
                    if (seabed.MovedEast == false && seabed.MovedSouth == false)
                    {
                        moveCucumbers = false;
                        Console.WriteLine("\nAfter step " + steps);
                        printFieldService.PrintField(seabed);
                    }
                    if(steps >= 5000)
                    {
                        moveCucumbers = false;
                        Console.WriteLine("The seacucumbers keep moving. The amout of steps exceeds 5000.\n" +
                            "The program has terminated.");
                    }
                }
            }
            return steps;
        }
    }
}
