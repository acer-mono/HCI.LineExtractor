using System.Collections.Generic;

namespace HCI.LineExtractor
{
    public class FileHandlerParameters
    {
        public FileHandlerParameters(string inputPath, string outputPath, List<int> lines)
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