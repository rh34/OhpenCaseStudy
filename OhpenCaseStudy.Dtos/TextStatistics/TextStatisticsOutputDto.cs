namespace OhpenCaseStudy.Dtos.TextStatistics
{
    /// <summary>
    /// Holds statistics for a given text
    /// </summary>
    public class TextStatisticsOutputDto
    {
        /// <summary>
        /// Hyphen count in a given text 
        /// </summary>
        public int HyphenCount { get; set; }

        /// <summary>
        /// Word count in a given text 
        /// </summary>
        public int WordCount { get; set; }

        /// <summary>
        /// Space count in a given text 
        /// </summary>
        public int SpaceCount { get; set; }
    }
}
