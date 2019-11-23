using NUnit.Framework;
using System.Linq;
using FluentAssertions;
using OhpenCaseStudy.Domain.SortAlgorithms;

namespace OhpenCaseStudy.Domain.Tests.SortAlgorithms
{
    [TestFixture]
    public class AlphabeticalSorterTests
    {
        private static readonly string[] Separators = new[] { " ", @"\.", ",", "\n" };
        private AlphabeticalSorter _alphabeticalSorter;

        [SetUp]
        public void SetUp()
        {
            _alphabeticalSorter = new AlphabeticalSorter();
        }


        [TestCase("alkan kaya abc abd bbb dde", new[] { "abc", "abd", "alkan", "bbb", "dde", "kaya" })]
        public void When_AlphabeticalWordSorterIsUsed_ReturnsCorrectResponse(string text, string[] expected)
        {
            var sorted = _alphabeticalSorter.Sort(text, Separators);
            sorted.Should().BeEquivalentTo(expected);
            sorted.SequenceEqual(expected).Should().BeTrue();
        }
    }
}
