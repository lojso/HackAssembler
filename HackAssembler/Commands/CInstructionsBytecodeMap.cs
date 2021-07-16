using System.Collections.Generic;

namespace HackAssembler.Commands
{
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

        public string GetJumpBytecode(string jmp) =>
            JumpMap[jmp];

        public string GetDestBytecode(string dest) =>
            DestinationMap[dest];

        public string GetCompByteCode(string comp)
        {
            var key = comp.Replace('M', 'A');
            string computationPrefix = comp.Contains('A') ? "0" : (comp.Contains('M') ? "1" : "0");
            return computationPrefix + CompMap[key];
        }
    }
}