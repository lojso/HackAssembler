namespace HackAssembler
{
    public class SymbolParser
    {
        public bool IsLabelSymbol(string codeLine) =>
            codeLine[0] == '(' && codeLine[^1] == ')';

        public bool IsVariableSymbol(string codeLine)
        {
            if (codeLine[0] != '@')
                return false;

            if (int.TryParse(codeLine.Substring(1), out _))
                return false;

            return true;
        }

        public string GetLabelSymbol(string codeLine) =>
            codeLine.Substring(1, codeLine.Length - 2);

        public string GetVariableSymbol(string codeLine) =>
            codeLine.Substring(1, codeLine.Length - 1);

        public void AddVariableSymbol(string symbol)
        {
            throw new System.NotImplementedException();
        }
    }
}