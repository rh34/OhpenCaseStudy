using System;
using System.Collections.Generic;
using System.Linq;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    /// <summary>
    /// String Sorter for SortEnum.WordSizeSortAlgorithm
    /// </summary>
    public class WordSizeSorter : ISorterAlgorithm
    {
        /// <summary>
        /// Sorts input text based on the word lengths in an ascending order.
        /// </summary>
        /// <param name="text">Text to sort</param>
        /// <param name="separators">Separator string array</param>
        /// <returns></returns>
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var sorted = text.Split(separators, StringSplitOptions.None);
            return sorted.OrderBy(t => t.Length).ToArray();
        }
    }
}