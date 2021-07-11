using System;
using System.Collections;
using Microsoft.VisualBasic.FileIO;

namespace HackAssembler
{
    static class Program
    {
        private static Arguments _arguments;
        private static SymbolsTable _symbolsTable;
        
        static void Main(string[] args)
        {
            _arguments = new Arguments(args);
            
            var hackParser = new HackParser(_arguments.Path);

            _symbolsTable = new SymbolsTable(hackParser.CodeListing());
        }
    }
}
