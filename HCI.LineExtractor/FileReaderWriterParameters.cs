using System.Collections.Generic;

namespace HCI.LineExtractor
{
    public class FileReaderWriterParameters
    {
        public FileReaderWriterParameters(string inputPath, string outputPath, IReadOnlyList<int> lines)
        {
            InputPath = inputPath;
            OutputPath = outputPath;
            Lines = lines;
        }

        public string InputPath { get; }
        public string OutputPath { get; }
        public IReadOnlyList<int> Lines { get; }
    }
}