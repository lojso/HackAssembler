using System;
using System.Collections.Generic;
using HackAssembler.Commands;

namespace HackAssembler
{
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

            return byteCode.TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}