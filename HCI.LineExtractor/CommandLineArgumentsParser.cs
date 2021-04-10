using System;
using System.Collections.Generic;

namespace HCI.LineExtractor
{
    public static class CommandLineArgumentsParser
    {
        public static FileReaderWriterParameters Parse(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("Amount of arguments less than 3");
            }
            
            var inputPath = args[0];
            var outputPath = args[1];
            var lines = new List<int>();

            for (var index = 2; index < args.Length; index++)
            {
                if (!int.TryParse(args[index], out var line))
                {
                    throw new ArgumentException("Line must be a number");
                }

                if (line <= 0)
                {
                    throw new ArgumentException("Incorrect line number");
                }
                
                lines.Add(line);
            }
            
            return new FileReaderWriterParameters(inputPath, outputPath, lines);
        }
    }
}