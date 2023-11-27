using System;
using SeaCucumber.Services;

namespace SeaCucumber
{
    class Program
    {
        static void Main()
        {
            var cucumberMoves = new CucumberService();
            int steps = cucumberMoves.CalculateSteps();
            Console.WriteLine("Amount of steps " + steps);
            Console.WriteLine("Press any key and Enter to end the program");
            Console.ReadLine();
        }
    }
}
