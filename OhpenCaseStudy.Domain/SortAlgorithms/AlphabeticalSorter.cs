using System;
using System.Collections.Generic;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    public class AlphabeticalSorter : ISorterAlgorithm
    {
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var sorted = text.Split(separators, StringSplitOptions.None);
            Array.Sort(sorted);
            return sorted;
        }
    }
}