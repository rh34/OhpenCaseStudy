using Microsoft.Extensions.Options;
using OhpenCaseStudy.Domain.Common;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Services
{
    public class StringSortService : IStringSortService
    {
        private readonly SortAlgorithmFactory _sortAlgorithmFactory;
        private readonly StringSettings _stringSettings;

        public StringSortService(SortAlgorithmFactory sortAlgorithmFactory, IOptions<StringSettings> stringSettings)
        {
            _sortAlgorithmFactory = sortAlgorithmFactory;
            _stringSettings = stringSettings.Value;
        }

        public SortResult Sort(string text, SortEnum sortEnum)
        {
            var sorterAlgorithm = _sortAlgorithmFactory.GetSorter(sortEnum);
            var sortedText = sorterAlgorithm.Sort(text, _stringSettings.Separators);
            return new SortResult() {SortedList = sortedText};
        }
    }
}
