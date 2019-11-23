using NUnit.Framework;
using OhpenCaseStudy.Domain.Services;
using System;
using FluentAssertions;
using Moq;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Domain.SortAlgorithms;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Tests
{
    [TestFixture]
    public class StringSorterServiceTests
    {
        private StringSortService _stringSorterService;
        private Mock<SortAlgorithmFactory> _mockSortAlgorithmFactory;
        private Mock<IServiceProvider> _mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockSortAlgorithmFactory = new Mock<SortAlgorithmFactory>(_mockServiceProvider.Object);
            _stringSorterService = new StringSortService(_mockSortAlgorithmFactory.Object);
        }

        [Test]
        [Ignore("dummy test")]
        public void When_StringServiceIsInitiated()
        {
            _stringSorterService.Should().NotBeNull();
        }

        [TestCase("alkan kaya abc abd bbb dde", new[] { "abc", "abd", "alkan", "bbb", "dde", "kaya" })]
        public void When_AlphabeticalWordSorterIsUsed_ReturnsCorrectResponse(string text, string[] expected)
        {
            _mockSortAlgorithmFactory.Setup(m => m.GetSorter(It.IsAny<SortEnum>())).Returns(new AlphabeticalSorter());
            _stringSorterService.Sort(text, SortEnum.AlphabeticalSortAlgorithm).SortedList.Should()
                .BeEquivalentTo(expected);
        }
    }
}
