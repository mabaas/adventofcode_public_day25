using System;
using System.IO;
using System.Text;
using SeaCucumber.Services.Interfaces;

namespace SeaCucumber.Services
{
    public class FileReaderService : IFileReaderService
    {
        public char[,] ReadFile(string cucumberdata)
        {
            bool first = true;
            const Int32 BufferSize = 128;
            var fileStream = File.OpenRead(cucumberdata);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string line = streamReader.ReadLine();
            int lineCount = File.ReadAllLines(cucumberdata).Length;
            int rows = 0;
            var cucumberField = new char[lineCount, line.Length];
            while (!streamReader.EndOfStream)
            {
                if (line != null)
                {
                    if (!first)
                    {
                        line = streamReader.ReadLine();
                    }
                    for (int x = 0; x < line.Length; x++)
                    {
                        cucumberField[rows, x] = line[x];
                    }
                    rows++;
                    first = false;
                }
            }
            return cucumberField;
        }
    }
}
