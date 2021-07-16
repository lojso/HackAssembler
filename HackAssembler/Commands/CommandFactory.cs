namespace HackAssembler.Commands
{
    public class CommandFactory
    {
        private readonly CommandParser _commandParser = new CommandParser();
        private readonly SymbolParser _symbolParser;
        private readonly SymbolsTable _symbolsTable;

        public CommandFactory(SymbolParser symbolParser, SymbolsTable symbolsTable)
        {
            _symbolParser = symbolParser;
            _symbolsTable = symbolsTable;
        }

        public Command CreateCommand(string codeLine)
        {
            if (_commandParser.IsACommand(codeLine))
                return new ACommand(codeLine, _symbolsTable, _symbolParser, _commandParser);
            return new CCommand(codeLine, _commandParser);
        }
    }
}