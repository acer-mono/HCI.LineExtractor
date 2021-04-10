using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HCI.LineExtractor.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Parse_AmountOfArgumentsLessThanThree_ThrowArgumentsException()
        {
            var args = new[] {string.Empty, string.Empty};

            Assert.That(() => CommandLineArgumentsParser.Parse(args), Throws.ArgumentException);
        }

        [Test]
        public void Parse_OneOfLineNotANumber_ThrowArgumentsException()
        {
            var args = new[] {string.Empty, string.Empty, string.Empty};

            Assert.That(() => CommandLineArgumentsParser.Parse(args), Throws.ArgumentException);
        }
        
        [Test]
        public void Parse_OneOfLineNumberIsNotPositive_ThrowArgumentsException()
        {
            var args = new[] {string.Empty, string.Empty, "-1"};

            Assert.That(() => CommandLineArgumentsParser.Parse(args), Throws.ArgumentException);
        }

        [Test]
        public void Parse_AllArgumentsAreValid_ReturnFileHandlerParameters()
        {
            var parameters = new FileHandlerParameters(String.Empty, string.Empty, new List<int>() {1});
            var args = new[] {string.Empty, string.Empty, "1"};

            var result = CommandLineArgumentsParser.Parse(args);

            Assert.That(result.InputPath, Is.EqualTo(parameters.InputPath));
            Assert.That(result.OutputPath, Is.EqualTo(parameters.OutputPath));
            Assert.That(result.Lines, Is.EqualTo(parameters.Lines));
        }
    }
}