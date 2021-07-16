using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class SymbolsTable
    {
        private const int StartPosition = 16;
        private readonly SymbolParser _symbolParser;
        private int _position;
        private Dictionary<string, int> _table;

        public SymbolsTable(IEnumerable<string> codeLines)
        {
            _table = GetDefaultSymbols();
            _symbolParser = new SymbolParser();
            _position = StartPosition;
            ParseCodeForLabelSymbols(codeLines);
        }

        private void ParseCodeForLabelSymbols(IEnumerable<string> codeLines)
        {
            var lineIndex = 0;
            foreach (var codeLine in codeLines)
            {
                if (_symbolParser.IsLabelSymbol(codeLine))
                {
                    var symbol = _symbolParser.GetLabelSymbol(codeLine);
                    AddLabelSymbol(symbol, lineIndex);
                    continue;
                }

                lineIndex++;
            }
        }

        private void AddLabelSymbol(string symbol, int lineIndex)
        {
            if (_table.ContainsKey(symbol))
                throw new FormatException($"{symbol} label duplicate at line {lineIndex}");

            _table[symbol] = lineIndex;
        }

        private Dictionary<string, int> GetDefaultSymbols() =>
            new Dictionary<string, int>
            {
                {"R0", 0},
                {"R1", 1},
                {"R2", 2},
                {"R3", 3},
                {"R4", 4},
                {"R5", 5},
                {"R6", 6},
                {"R7", 7},
                {"R8", 8},
                {"R9", 9},
                {"R10", 10},
                {"R11", 11},
                {"R12", 12},
                {"R13", 13},
                {"R14", 14},
                {"R15", 15},
                {"SCREEN", 16384},
                {"KBD", 24576},
                {"SP", 0},
                {"LCL", 1},
                {"ARG", 2},
                {"THIS", 4},
                {"THAT", 5},
            };

        public bool ContainSymbol(string symbol) =>
            _table.ContainsKey(symbol);

        public int GetSymbolValue(string symbol) =>
            _table[symbol];

        public void AddSymbol(string symbol)
        {
            if (ContainSymbol(symbol))
                throw new ArgumentException($"Table already contains symbol {symbol}");

            _table[symbol] = GetNexPosition();
        }

        private int GetNexPosition() =>
            _position++;
    }
}