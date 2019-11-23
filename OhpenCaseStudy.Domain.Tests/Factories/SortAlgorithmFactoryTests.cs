using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Domain.SortAlgorithms;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Tests.Factories
{
    [TestFixture]
    public class SortAlgorithmFactoryTests
    {
        private SortAlgorithmFactory _sortAlgorithmFactory;
        private Mock<IServiceProvider> _mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockServiceProvider.Setup(m => m.GetService(typeof(AlphabeticalSorter))).Returns(new AlphabeticalSorter());
            _mockServiceProvider.Setup(m => m.GetService(typeof(WordSizeSorter))).Returns(new WordSizeSorter());
            _mockServiceProvider.Setup(m => m.GetService(typeof(CharacterWithinWordSorter))).Returns(new CharacterWithinWordSorter());

            _sortAlgorithmFactory = new SortAlgorithmFactory(_mockServiceProvider.Object);
        }

        [TestCase(SortEnum.AlphabeticalSortAlgorithm, typeof(AlphabeticalSorter))]
        [TestCase(SortEnum.WordSizeSortAlgorithm, typeof(WordSizeSorter))]
        [TestCase(SortEnum.CharacterWithinWordAlgorithm, typeof(CharacterWithinWordSorter))]
        public void WhenEnumIsProvided_FactoryReturnsCorrectSorter(SortEnum sortEnum, Type type)
        {
            var sorter = _sortAlgorithmFactory.GetSorter(sortEnum);
            sorter.Should().BeOfType(type);
        }
    }
}
