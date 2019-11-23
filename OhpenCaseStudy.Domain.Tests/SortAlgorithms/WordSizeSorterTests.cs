﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using OhpenCaseStudy.Domain.SortAlgorithms;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Tests.SortAlgorithms
{
    [TestFixture]
    public class WordSizeSorterTests
    {
        private static readonly string[] Separators = new[] { " ", @"\.", ",", "\n" };
        private WordSizeSorter _wordSizeSorter;

        [SetUp]
        public void SetUp()
        {
            _wordSizeSorter = new WordSizeSorter();
        }


        [TestCase("alkan kaya abc abd bbb dde", new[] { "abc", "abd", "bbb", "dde", "kaya", "alkan" })]
        public void When_WordSizeSorterIsUsed_ReturnsCorrectResponse(string text, string[] expected)
        {
            var sorted = _wordSizeSorter.Sort(text, Separators);
            sorted.Should().BeEquivalentTo(expected);
            sorted.SequenceEqual(expected).Should().BeTrue();
        }
    }
}
