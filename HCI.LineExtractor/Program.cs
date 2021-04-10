using System;

namespace HCI.LineExtractor
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parameters = CommandLineArgumentsParser.Parse(args);
                FileReaderWriter.Handle(parameters);
                Console.WriteLine("Loaded");
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}