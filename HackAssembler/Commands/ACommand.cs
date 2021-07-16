using System;

namespace HackAssembler.Commands
{
    public class ACommand : Command
    {
        private const char FillBytecodeWith = '0';
        private const int NumbersBase = 2;
        private const int ByteCodeWidth = 16;

        private int _address;

        public ACommand(string codeLine, SymbolsTable symbolsTable, SymbolParser symbolParser,
            CommandParser commandParser)
        {
            _address = symbolParser.IsVariableSymbol(codeLine)
                ? symbolsTable.GetSymbolValue(symbolParser.GetVariableSymbol(codeLine))
                : commandParser.ParseACommand(codeLine);
        }

        public override string ToString() =>
            $"@{_address}";

        public override string ToByteCode() =>
            Convert.ToString(_address, NumbersBase).PadLeft(ByteCodeWidth, FillBytecodeWith);
    }
}