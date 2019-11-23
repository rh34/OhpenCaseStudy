using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OhpenCaseStudy.Domain.SortAlgorithms;

namespace OhpenCaseStudy.Domain.Tests.SortAlgorithms
{
    [TestFixture]
    public class CharacterWithinWordSorterTests
    {

        private static readonly string[] Separators = new[] { " ", @"\.", ",", "\n" };
        private CharacterWithinWordSorter _characterWithinWordSorter;

        [SetUp]
        public void SetUp()
        {
            _characterWithinWordSorter = new CharacterWithinWordSorter();
        }


        [TestCase("alkan kaya abc abd bbb edde", new[] { "aakln", "aaky", "abc", "abd", "bbb", "ddee" })]
        public void When_AlphabeticalWordSorterIsUsed_ReturnsCorrectResponse(string text, string[] expected)
        {
            var sorted = _characterWithinWordSorter.Sort(text, Separators);
            sorted.Should().BeEquivalentTo(expected);
            sorted.SequenceEqual(expected).Should().BeTrue();
        }
    }
}
