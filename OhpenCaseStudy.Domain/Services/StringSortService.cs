using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Services
{
    public class StringSortService : IStringSortService
    {
        private readonly SortAlgorithmFactory _sortAlgorithmFactory;
        private static readonly string[] Separators = new[] { " ", @"\.", ",", "\n" };

        public StringSortService(SortAlgorithmFactory sortAlgorithmFactory)
        {
            _sortAlgorithmFactory = sortAlgorithmFactory;
        }

        public SortResult Sort(string text, SortEnum sortEnum)
        {
            var sorterAlgorithm = _sortAlgorithmFactory.GetSorter(sortEnum);
            var sortedText = sorterAlgorithm.Sort(text, Separators);
            return new SortResult() {SortedList = sortedText};
        }
    }
}
