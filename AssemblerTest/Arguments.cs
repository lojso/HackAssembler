using System;
using HackAssembler;
using NUnit.Framework;

namespace AssemblerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] public void MultipleArguments()
        {
            string[] args = {"AssemblerTest.dll", "PlusOne"};
            
            var arguments = new Arguments(args);
            
            Assert.Pass();
        }

        [Test]
        public void FileInCurrentDirectory()
        {
            string[] args = {"AssemblerTest.dll"};
            
            var arguments = new Arguments(args);
            
            Assert.Pass();
        }

        [Test]
        public void RelativePathCurrentDirectory()
        {
            string[] args = {"../netcoreapp3.1/AssemblerTest.dll"};
            
            var arguments = new Arguments(args);
            
            Assert.Pass();
        }

        [Test]
        public void AbsolutePathDirectory()
        {
            string[] args = {@"E:\Repos\HackAssembler\AssemblerTest\bin\Debug\netcoreapp3.1\AssemblerTest.dll"};
            
            var arguments = new Arguments(args);
            
            Assert.Pass();
        }
        
        [Test]
        public void IncorrectPath()
        {
            Assert.Throws(typeof(ArgumentException), () => new Arguments(new[] {"Nope"}));
        }
        
        [Test]
        public void EmptyPath()
        {
            Assert.Throws(typeof(ArgumentException), () => new Arguments(new[] {""}));
        }
        
        [Test]
        public void EmptyArguments()
        {
            Assert.Throws(typeof(ArgumentException), () => new Arguments(new string[] {}));
        }
    }
}