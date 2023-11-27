using System;
using SeaCucumber.Models;
using SeaCucumber.Services.Interfaces;

namespace SeaCucumber.Services
{
    public class PrintFieldService : IPrintFieldService
    {
        /// <summary>
        /// Display the seacucumber field
        /// </summary>
        /// <param name="seabed"></param>
        public void PrintField(Seabed seabed)
        {
            int rows = seabed.CucumberField.GetLength(0);
            int cols = seabed.CucumberField.GetLength(1);
            for (int yy = 0; yy < rows; yy++)
            {
                for (int xx = 0; xx < cols; xx++)
                {
                    Console.Write(seabed.CucumberField[yy, xx]);
                }
                Console.Write("\n");
            }
        }
    }
}
