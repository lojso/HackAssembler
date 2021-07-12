namespace HackAssembler
{
    public class Command
    {
    }

    public class ACommand : Command
    {
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
    }
}