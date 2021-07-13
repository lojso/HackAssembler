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
                new CommandFactory(symbolParser, _symbolsTable),
                _symbolsTable
            );

            string byteCodeListing = codeListing.ToByteCode();
        }
    }

    public class CodeListing
    {
        private List<Command> _commands = new List<Command>();

        public CodeListing(IEnumerable<string> codeListing, SymbolParser symbolParser, CommandFactory factory,
            SymbolsTable table)
        {
            foreach (var codeLine in codeListing)
            {
                if (symbolParser.IsLabelSymbol(codeLine))
                    continue;

                AddVariableSymbol(symbolParser, table, codeLine);

                _commands.Add(factory.CreateCommand(codeLine));
            }
        }

        private static void AddVariableSymbol(SymbolParser symbolParser, SymbolsTable table, string codeLine)
        {
            if (!symbolParser.IsVariableSymbol(codeLine))
                return;

            var symbol = symbolParser.GetVariableSymbol(codeLine);
            if (table.ContainSymbol(symbol) == false)
                table.AddSymbol(symbol);
        }

        public string ToByteCode()
        {
            string byteCode = "";
            foreach (var command in _commands)
                byteCode += command.ToByteCode() + Environment.NewLine;

            byteCode.TrimEnd();

            return byteCode;
        }
    }
}