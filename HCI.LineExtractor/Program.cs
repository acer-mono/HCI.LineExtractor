using System;

namespace HCI.LineExtractor
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileHandler = new InputOutputFileHandler(args);
                fileHandler.Handle();
                Console.WriteLine("Loaded");
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}