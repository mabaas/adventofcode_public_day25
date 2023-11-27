using SeaCucumber.Models;
using SeaCucumber.Services.Interfaces;

namespace SeaCucumber.Services
{
    public class HerdService : IHerdService
    {
        /// <summary>
        /// Move seacucumber herd East
        /// </summary>
        /// <param name="seabed"></param>
        /// <returns>Seabed</returns>
        public Seabed EastMovingHerd(Seabed seabed)
        {
            var movedField = (char[,])seabed.CucumberField.Clone();
            int rows = seabed.CucumberField.GetLength(0) - 1;
            int cols = seabed.CucumberField.GetLength(1) - 1;
            seabed.MovedEast = false;
            for (int y = 0; y <= rows; y++)
            {
                for (int x = 1; x <= cols + 1; x++)
                {
                    int newXindex = x;
                    if (x == cols + 1)
                    {
                        newXindex = 0;
                    }
                    char pos1 = seabed.CucumberField[y, x - 1];
                    char pos2 = seabed.CucumberField[y, newXindex];
                    if (pos1 == '>' && pos2 == '.')
                    {
                        movedField[y, x - 1] = '.';
                        movedField[y, newXindex] = '>';
                        seabed.MovedEast = true;
                    }
                }
            }
            // Copy cloned fields to the orginal
            seabed.CucumberField = movedField;
            return seabed;
        }

        /// <summary>
        /// Moving seacucumber herd South
        /// </summary>
        /// <param name="seabed"></param>
        /// <returns>Seabed</returns>
        public Seabed SouthMovingHerd(Seabed seabed)
        {
            var movedField = (char[,])seabed.CucumberField.Clone();
            int rows = seabed.CucumberField.GetLength(0) - 1;
            int cols = seabed.CucumberField.GetLength(1) - 1;
            seabed.MovedSouth = false;
            for (int x = 0; x <= cols; x++)
            {
                for (int y = 1; y <= rows + 1; y++)
                {
                    int newYindex = y;
                    if (y == rows + 1)
                    {
                        newYindex = 0;
                    }
                    char pos1 = seabed.CucumberField[y - 1, x];
                    char pos2 = seabed.CucumberField[newYindex, x];
                    if (pos1 == 'v' && pos2 == '.')
                    {
                        movedField[y - 1, x] = '.';
                        movedField[newYindex, x] = 'v';
                        seabed.MovedSouth = true;
                    }
                }
            }
            // Copy cloned fields to the orginal
            seabed.CucumberField = movedField;
            return seabed;
        }
    }
}
