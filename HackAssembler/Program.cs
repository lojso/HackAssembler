using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace HackAssembler
{
    class Program
    {
        private static Arguments _arguments;
        
        static void Main(string[] args)
        {
            _arguments = new Arguments(args);

            var hackParser = new HackParser(_arguments.Path);

            foreach (var line in hackParser.CodeListing())
            {
                Console.WriteLine(line);
            }
            





        }
    }

    public class HackParser
    {
        private readonly string _filePath;

        public HackParser(string filePath) => 
            _filePath = filePath;

        public IEnumerable<string> CodeListing()
        {
            using var file = new StreamReader(_filePath);
            string line; 
            while ((line = file.ReadLine()) != null)
            {
                yield return line;
            }
        }
        
        
    }
}
