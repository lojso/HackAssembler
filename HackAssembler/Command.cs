using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public abstract class Command
    {
        public abstract string ToByteCode();
    }

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

    public class CCommand : Command
    {
        private string _comp;
        private string _dest;
        private string _jump;

        public CCommand(string codeLine, CommandParser commandParser)
        {
            (_comp, _dest, _jump) = commandParser.ParseCCommand(codeLine);
        }

        public override string ToString() =>
            $"{_dest}={_comp};{_jump}";

        public override string ToByteCode()
        {
        }
    }

    public class CInstructionsBytecodeMap
    {
        private readonly Dictionary<string, string> CompMap = new Dictionary<string, string>()
        {
            {"0", "101010"},
            {"1", "111111"},
            {"-1", "111010"},
            {"D", "001100"},
            {"A", "110000"},
            {"!D", "001101"},
            {"!A", "110001"},
            {"-D", "001111"},
            {"-A", "110011"},
            {"D+1", "011111"},
            {"A+1", "110111"},
            {"D-1", "001110"},
            {"A-1", "110010"},
            {"D+A", "000010"},
            {"D-A", "010011"},
            {"A-D", "000111"},
            {"D&A", "000000"},
            {"D|A", "010101"},
        };

        private readonly Dictionary<string, string> DestinationMap = new Dictionary<string, string>()
        {
            {"", "000"},
            {"M", "001"},
            {"D", "010"},
            {"MD", "011"},
            {"A", "100"},
            {"AM", "101"},
            {"AD", "110"},
            {"AMD", "111"},
        };

        private readonly Dictionary<string, string> JumpMap = new Dictionary<string, string>()
        {
            {"", "000"},
            {"JGT", "001"},
            {"JEQ", "010"},
            {"JGE", "011"},
            {"JLT", "100"},
            {"JNE", "101"},
            {"JLE", "110"},
            {"JMP", "111"},
        };
    }
}