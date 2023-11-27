namespace SeaCucumber.Models
{
    public class Seabed
    {
        private static int Rows { get; set; }
        private static int Cols { get; set; }
        public char[,] CucumberField { get; set; } = new char[Cols,Rows];
        public bool MovedEast { get; set; }
        public bool MovedSouth { get; set; }
    }
}
