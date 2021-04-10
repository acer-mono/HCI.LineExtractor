using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HCI.LineExtractor
{
    public static class FileReaderWriter
    {
        public static void Handle(FileReaderWriterParameters parameters)
        {
            EnsureInputFileExists(parameters.InputPath);
            var fileLines = File.ReadLines(parameters.InputPath);
            var fileLinesAmount = fileLines.Count();
            var expectedLinesAmount = parameters.Lines.Max();
            EnsureMaxLineNumberInFileIsGreaterThanExpected(fileLinesAmount, expectedLinesAmount);
            WriteLinesInOutput(parameters, fileLines);
        }

        private static void EnsureInputFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Input file {path} not found");
            }
        }
        
        private static void EnsureMaxLineNumberInFileIsGreaterThanExpected(int fileLinesAmount, int expectedLinesAmount)
        {
            if (fileLinesAmount < expectedLinesAmount)
            {
                throw new InvalidOperationException(
                    "The number of lines in the file does not match the expected number");
            }
        }
        
        private static void WriteLinesInOutput(FileReaderWriterParameters parameters, IEnumerable<string> inputFileLines)
        {
            using StreamWriter streamWriter = new StreamWriter(parameters.OutputPath);

            var index = 1;
            foreach (var line in inputFileLines)
            {
                if (parameters.Lines.Contains(index))
                {
                    var numberOfRepetitions = parameters.Lines.Count(numberOfLine => numberOfLine == index);
                    var linesToWrite = RepeatLine(line, numberOfRepetitions);
                    streamWriter.WriteLine(linesToWrite);
                }
                index++;
            }
        }

        private static string RepeatLine(string line, int amount)
        {
            var strings = Enumerable.Repeat(line, amount);
            return strings
                .Aggregate(string.Empty, (current, str) => current + $"{str}{Environment.NewLine}")
                .Trim();
        }
    }
}