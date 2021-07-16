namespace HackAssembler.Commands
{
    public class CommandParser
    {
        public bool IsACommand(string codeLine) =>
            codeLine[0] == '@';

        public int ParseACommand(string codeLine) =>
            int.Parse(codeLine.Substring(1));

        public (string comp, string dest, string jump) ParseCCommand(string codeLine)
        {
            (var comp, var dest, var jump) = ("", "", "");
            var eqIndex = codeLine.IndexOf('=');
            var jmpIndex = codeLine.IndexOf(';');

            dest = eqIndex == -1 ? "" : codeLine.Substring(0, eqIndex);
            jump = jmpIndex == -1 ? "" : codeLine.Substring(jmpIndex + 1);
            var compIndexStart = eqIndex == -1 ? 0 : eqIndex + 1;
            var compLength = jmpIndex == -1 ? codeLine.Length - compIndexStart : jmpIndex - compIndexStart;
            comp = codeLine.Substring(compIndexStart, compLength);
            return (comp, dest, jump);
        }
    }
}