namespace SeaCucumber.Services.Interfaces
{
    public interface ICucumberService
    {
        public char[,] Init();
        public int CalculateSteps();
    }
}