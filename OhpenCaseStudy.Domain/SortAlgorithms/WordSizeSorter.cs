using System;
using System.Collections.Generic;
using System.Linq;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    public class WordSizeSorter : ISorterAlgorithm
    {
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var sorted = text.Split(separators, StringSplitOptions.None);
            return sorted.OrderBy(t => t.Length).ToArray();
        }
    }
}