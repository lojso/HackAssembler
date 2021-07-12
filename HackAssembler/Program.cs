using System;
using System.Collections.Generic;

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
            var symbolParser = new SymbolParser();
            var codeListing = new CodeListing(
                hackParser.CodeListing(),
                symbolParser,
                new CommandFactory(symbolParser, _symbolsTable));
        }
    }

    public class CodeListing
    {
        private readonly SymbolParser _symbolParser;

        private List<Command> _commands = new List<Command>();
        private CommandFactory _factory;

        public CodeListing(IEnumerable<string> codeListing, SymbolParser symbolParser, CommandFactory factory)
        {
            _symbolParser = symbolParser;
            _factory = factory;

            foreach (var codeLine in codeListing)
            {
                Console.WriteLine(_factory.CreateCommand(codeLine).ToString());
            }
        }
    }
}