using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OhpenCaseStudy.Domain.Common;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Dtos.TextStatistics;

namespace OhpenCaseStudy.Domain.Tests.Services
{
    [TestFixture]
    public class TextStatisticsServiceTests
    {
        private Mock<IOptions<StringSettings>> _mockStringSettings;
        private TextStatisticsService _textStatisticsService;

        [SetUp]
        public void SetUp()
        {
            _mockStringSettings = new Mock<IOptions<StringSettings>>();
            _mockStringSettings.Setup(m => m.Value).Returns(new StringSettings { Separators = new[] { " ", @"\.", ",", "\n", "-" } });

            _textStatisticsService = new TextStatisticsService(_mockStringSettings.Object);
        }

        [TestCase("alkan  - -kaya-abc abd bbb dde", 3, 6, 6)]
        [TestCase("alkan--- -kaya-abc abd bbb ddealkan  - -kaya-abc abd bbb dde", 8, 11, 10)]
        public void When_StatiscsAreQueried_ReturnsCorrectResponse(string text, int hyphenCount, int wordCount, int spaceCount)
        {
            _textStatisticsService.GenerateStatistics(text).Should().BeEquivalentTo(new TextStatisticsOutputDto()
            {
                HyphenCount = hyphenCount,
                WordCount = wordCount,
                SpaceCount = spaceCount
            });
        }
    }
}
