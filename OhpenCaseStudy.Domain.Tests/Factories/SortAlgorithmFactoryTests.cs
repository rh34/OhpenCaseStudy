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

            _sortAlgorithmFactory = new SortAlgorithmFactory(_mockServiceProvider.Object);
        }

        [TestCase(SortEnum.AlphabeticalSortAlgorithm, typeof(AlphabeticalSorter))]
        [TestCase(SortEnum.WordSizeSortAlgorithm, typeof(WordSizeSorter))]
        public void WhenEnumIsProvided_FactoryReturnsCorrectSorter(SortEnum sortEnum, Type type)
        {
            var sorter = _sortAlgorithmFactory.GetSorter(sortEnum);
            sorter.Should().BeOfType(type);
        }

        [Test]
        public void WhenEnumIsNotFound_ThrowsNotImplementedException()
        {
            _sortAlgorithmFactory.Invoking(t=>t.GetSorter(SortEnum.None)).Should().Throw<NotImplementedException>();
        }
    }
}
