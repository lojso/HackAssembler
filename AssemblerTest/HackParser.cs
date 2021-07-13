using HackAssembler;
using NUnit.Framework;

namespace AssemblerTest
{
    [TestFixture]
    public class Parser
    {
        [Test]
        public void RemoveComments()
        {
            var parser = new HackParser(@"E:\Repos\HackAssembler\AssemblerTest\TestFiles\Comments.asm");

            using var listingEnumerator = parser.CodeListing().GetEnumerator();
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("@2"));
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("@a"));
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("0;"));
            Assert.False(listingEnumerator.MoveNext());
        }

        [Test]
        public void RemoveWhitespaces()
        {
            var parser = new HackParser(@"E:\Repos\HackAssembler\AssemblerTest\TestFiles\Spaces.asm");

            using var listingEnumerator = parser.CodeListing().GetEnumerator();
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("@2"));
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("@a"));
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("0;JMP"));
            Assert.False(listingEnumerator.MoveNext());
        }

        [Test]
        public void RemoveExcessiveLines()
        {
            var parser = new HackParser(@"E:\Repos\HackAssembler\AssemblerTest\TestFiles\ExcessiveLines.asm");

            using var listingEnumerator = parser.CodeListing().GetEnumerator();
            listingEnumerator.MoveNext();

            Assert.True(listingEnumerator.Current.Equals("@42"));
            Assert.False(listingEnumerator.MoveNext());
        }
    }
}