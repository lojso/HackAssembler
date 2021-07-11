using System;
using HackAssembler;
using NUnit.Framework;

namespace AssemblerTest
{
    public class Arguments
    {
        [Test]
        public void MultipleArguments()
        {
            string[] args = {"AssemblerTest.dll", "PlusOne"};
            
            var arguments = new HackAssembler.Arguments(args);
            
            Assert.True(arguments.Path.Equals("AssemblerTest.dll"));
        }

        [Test]
        public void FileInCurrentDirectory()
        {
            string[] args = {"AssemblerTest.dll"};
            
            var arguments = new HackAssembler.Arguments(args);
            
            Assert.Pass();
        }

        [Test]
        public void RelativePathCurrentDirectory()
        {
            string[] args = {"../netcoreapp3.1/AssemblerTest.dll"};
            
            var arguments = new HackAssembler.Arguments(args);
            
            Assert.Pass();
        }

        [Test]
        public void AbsolutePathDirectory()
        {
            string[] args = {@"E:\Repos\HackAssembler\AssemblerTest\bin\Debug\netcoreapp3.1\AssemblerTest.dll"};
            
            var arguments = new HackAssembler.Arguments(args);
            
            Assert.Pass();
        }
        
        [Test]
        public void IncorrectPath()
        {
            Assert.Throws(typeof(ArgumentException), () => new HackAssembler.Arguments(new[] {"Nope"}));
        }
        
        [Test]
        public void EmptyPath()
        {
            Assert.Throws(typeof(ArgumentException), () => new HackAssembler.Arguments(new[] {""}));
        }
        
        
        
        [Test]
        public void EmptyArguments()
        {
            Assert.Throws(typeof(ArgumentException), () => new HackAssembler.Arguments(new string[] {}));
        }
    }
}