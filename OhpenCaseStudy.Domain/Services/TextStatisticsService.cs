using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using OhpenCaseStudy.Domain.Common;
using OhpenCaseStudy.Dtos.TextStatistics;

namespace OhpenCaseStudy.Domain.Services
{
    /// <summary>
    /// Statistics generator service
    /// </summary>
    public class TextStatisticsService : ITextStatisticsService
    {
        private readonly StringSettings _stringSettings;

        public TextStatisticsService(IOptions<StringSettings> stringSettings)
        {
            _stringSettings = stringSettings.Value;
        }

        /// <summary>
        /// Generates statistics for a given text
        /// </summary>
        /// <param name="text">String input to generate statistics for</param>
        /// <returns></returns>
        public TextStatistics GenerateStatistics(string text)
        {
            var separators = _stringSettings.Separators;
            //var matches = Regex.Matches(text, @"\s|-");

            var result = new TextStatistics
            {
                HyphenCount = Regex.Matches(text, @"-").Count,
                WordCount = text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length,
                SpaceCount = Regex.Matches(text, @"\s").Count
            };

            return result;
        }
    }
}