using HackAssembler;
using NUnit.Framework;

namespace AssemblerTest
{
    [TestFixture]
    public class SymbolsParser
    {
        [Test]
        public void TestLabelRecognitionCorrect()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.True(symbolsParser.IsLabelSymbol("(aaaa)"));
        }
        
        [Test]
        public void TestLabelRecognitionIncorrectLabel()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.False(symbolsParser.IsLabelSymbol("(aaaa"));
        }
        
        [Test]
        public void TestLabelRecognitionVariable()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.False(symbolsParser.IsLabelSymbol("@aaaa"));
        }
        
        [Test]
        public void TestVariableRecognitionCorrect()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.True(symbolsParser.IsVariableSymbol("@aaaa"));
        }
        
        [Test]
        public void TestRecognitionIncorrectVariable()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.False(symbolsParser.IsVariableSymbol("aaaa"));
        }
        
        [Test]
        public void TestRecognitionVariableLabel()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.False(symbolsParser.IsVariableSymbol("@2"));
        }
        
        [Test]
        public void TestRecognitionVariableNumber()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.False(symbolsParser.IsVariableSymbol("(aaaa)"));
        }
        
        [Test]
        public void GetLabel()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.AreEqual(symbolsParser.GetLabelSymbol("(LABEL)"), "LABEL");
        }
        
        [Test]
        public void GetLabelOneChar()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.AreEqual(symbolsParser.GetLabelSymbol("(L)"), "L");
        }
        
        [Test]
        public void GetVariableOneChar()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.AreEqual(symbolsParser.GetVariableSymbol("@a"), "a");
        }

        [Test]
        public void GetVariable()
        {
            var symbolsParser = new SymbolParser();
            
            Assert.AreEqual(symbolsParser.GetVariableSymbol("@var"), "var");
        }
        
        
    }
    
    
}