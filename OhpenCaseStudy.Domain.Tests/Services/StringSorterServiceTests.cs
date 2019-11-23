using System;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OhpenCaseStudy.Domain.Common;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Domain.SortAlgorithms;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Tests.Services
{
    [TestFixture]
    public class StringSorterServiceTests
    {
        private Mock<IOptions<StringSettings>> _mockStringSettings;
        private StringSortService _stringSorterService;
        private Mock<SortAlgorithmFactory> _mockSortAlgorithmFactory;
        private Mock<IServiceProvider> _mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            _mockStringSettings = new Mock<IOptions<StringSettings>>();
            _mockStringSettings.Setup(m => m.Value).Returns(new StringSettings { Separators = new[] { " ", @"\.", ",", "\n" } });

            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockSortAlgorithmFactory = new Mock<SortAlgorithmFactory>(_mockServiceProvider.Object);
            _stringSorterService = new StringSortService(_mockSortAlgorithmFactory.Object, _mockStringSettings.Object);
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
