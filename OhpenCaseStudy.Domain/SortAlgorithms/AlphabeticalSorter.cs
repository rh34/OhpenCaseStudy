using System;
using System.Collections.Generic;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    /// <summary>
    /// String Sorter for SortEnum.AlphabeticalSortAlgorithm
    /// </summary>
    public class AlphabeticalSorter : ISorterAlgorithm
    {
        /// <summary>
        /// Sorts input alphabetically
        /// </summary>
        /// <param name="text">Text to sort</param>
        /// <param name="separators">Separator string array</param>
        /// <returns></returns>
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var sorted = text.Split(separators, StringSplitOptions.None);
            Array.Sort(sorted);
            return sorted;
        }
    }
}