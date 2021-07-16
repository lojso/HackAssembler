using System.IO;
using HackAssembler.Commands;

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

            OutputByteCode(codeListing);
        }

        private static void OutputByteCode(CodeListing codeListing)
        {
            string byteCodeListing = codeListing.ToByteCode();
            var directoryName = Path.GetDirectoryName(_arguments.Path);
            var listingFileName = Path.GetFileNameWithoutExtension(_arguments.Path);
            var outputFile = Path.Combine(directoryName, listingFileName) + ".hack";
            File.WriteAllText(outputFile, byteCodeListing);
        }
    }
}