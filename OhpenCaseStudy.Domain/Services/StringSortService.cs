using Microsoft.Extensions.Options;
using OhpenCaseStudy.Domain.Common;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Services
{
    /// <summary>
    /// String Sorting Service
    /// </summary>
    public class StringSortService : IStringSortService
    {
        private readonly SortAlgorithmFactory _sortAlgorithmFactory;
        private readonly StringSettings _stringSettings;

        /// <summary>
        /// String Sort Service constructor
        /// </summary>
        /// <param name="sortAlgorithmFactory"></param>
        /// <param name="stringSettings"></param>
        public StringSortService(SortAlgorithmFactory sortAlgorithmFactory, IOptions<StringSettings> stringSettings)
        {
            _sortAlgorithmFactory = sortAlgorithmFactory;
            _stringSettings = stringSettings.Value;
        }

        /// <summary>
        /// Sorts input text based on a sortEnum value
        /// </summary>
        /// <param name="text">Input text to be used for sorting</param>
        /// <param name="sortEnum">Sorting algorithm of choice</param>
        /// <returns></returns>
        public SortResult Sort(string text, SortEnum sortEnum)
        {
            var sorterAlgorithm = _sortAlgorithmFactory.GetSorter(sortEnum);
            var sortedText = sorterAlgorithm.Sort(text, _stringSettings.Separators);
            return new SortResult() {SortedList = sortedText};
        }
    }
}
