using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HCI.LineExtractor
{
    public class InputOutputFileHandler
    {
        private readonly FileHandlerParameters _parameters;
        
        public InputOutputFileHandler(string[] args)
        {
            _parameters = CommandLineArgumentsParser.Parse(args);
        }
        public void Handle()
        {
            EnsureInputFileExists(_parameters.InputPath);
            var fileLines = File.ReadLines(_parameters.InputPath);
            EnsureMaxLineNumberInFileIsGreaterThanExpected(fileLines.Count());
            WriteLinesInOutput(fileLines);
        }

        private static void EnsureInputFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Input file {path} not found");
            }
        }
        
        private void EnsureMaxLineNumberInFileIsGreaterThanExpected(int maxLineNumberInFile)
        {
            var expectedMaxLine = _parameters.Lines.Max();
            if (maxLineNumberInFile < expectedMaxLine)
            {
                throw new InvalidOperationException(
                    "The number of lines in the file does not match the expected number");
            }
        }
        
        private void WriteLinesInOutput(IEnumerable<string> fileLines)
        {
            using StreamWriter streamWriter = new StreamWriter(_parameters.OutputPath);

            var index = 1;
            foreach (var line in fileLines)
            {
                if (_parameters.Lines.Contains(index))
                {
                    var amountOfLines = _parameters.Lines.Count(numberOfLine => numberOfLine == index);
                    Console.WriteLine(amountOfLines);
                    var lines = RepeatLine(line, amountOfLines);
                    streamWriter.WriteLine(lines);
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