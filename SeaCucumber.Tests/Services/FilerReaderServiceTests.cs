using Xunit;
using Moq;
using SeaCucumber.Services;
using SeaCucumber.Services.Interfaces;


namespace SeaCucumber.Tests.Services
{
    public class FilerReaderServiceTests
    {
        private FileReaderService fileReaderService;
        
        public FilerReaderServiceTests()
        {
            fileReaderService = new FileReaderService();
        }
        

        [Fact]
        public void ReadFile()
        {
            // Arrange
            char[,] dummyFile = new char[,]
            {
              { 'v','.','.','.','>','>','.','v','v','>', },
              { '.','v','v','>','>','.','v','v','.','.', },
              { '>','>','.','>','v','>','.','.','.','v', },
              { '>','>','v','>','>','.','>','.','v','.', },
              { 'v','>','v','.','v','v','.','v','.','.', },
              { '>','.','>','>','.','.','v','.','.','.', },
              { '.','v','v','.','.','>','.','>','v','.', },
              { 'v','.','v','.','.','>','>','v','.','v', },
              { '.','.','.','.','v','.','.','v','.','>' }
            };

            string file = "C:\\Temp\\DemoCucumberField.txt";
            var mockFileReader = new Mock<IFileReaderService>();
            mockFileReader.Setup(x => x.ReadFile(file)).Returns(dummyFile);
            // Act
            fileReaderService = new FileReaderService();
            var readFile = fileReaderService.ReadFile(file);
            // Assert
            Assert.Equal(dummyFile, readFile);
        }
    }
}
