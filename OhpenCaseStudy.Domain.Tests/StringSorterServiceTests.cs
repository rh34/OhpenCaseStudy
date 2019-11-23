using NUnit.Framework;
using OhpenCaseStudy.Domain.Services;
using System;
using FluentAssertions;

namespace OhpenCaseStudy.Domain.Tests
{
    [TestFixture]
    public class StringSorterServiceTests
    {
        private StringSortService _stringSorterService;
        
        [SetUp]
        public void SetUp()
        {
            _stringSorterService = new StringSortService();
        }

        [Test][Ignore("dummy test")]
        public void When_StringServiceIsInitiated()
        {
            _stringSorterService.Should().NotBeNull();
        }
    }
}
