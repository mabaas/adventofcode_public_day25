namespace SeaCucumber.Services.Interfaces
{
    public interface IFileReaderService
    {
        public char[,] ReadFile(string cucumberdata);
    }
}