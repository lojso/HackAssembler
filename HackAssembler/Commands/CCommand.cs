namespace HackAssembler.Commands
{
    public class CCommand : Command
    {
        private const string CInstructionPrefix = "111";
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
            var codeMap = new CInstructionsBytecodeMap();
            return CInstructionPrefix + codeMap.GetCompByteCode(_comp) + codeMap.GetDestBytecode(_dest) +
                   codeMap.GetJumpBytecode(_jump);
        }
    }
}