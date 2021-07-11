using System;
using System.Collections;
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
}
