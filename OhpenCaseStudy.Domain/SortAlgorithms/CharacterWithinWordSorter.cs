using System;
using System.Collections.Generic;
using System.Linq;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    /// <summary>
    /// String Sorter for SortEnum.CharacterWithinWordAlgorithm
    /// </summary>
    public class CharacterWithinWordSorter : ISorterAlgorithm
    {
        /// <summary>
        /// Sorts input word characters alphabetically, but keeps the words' orders.
        /// </summary>
        /// <param name="text">Text to sort</param>
        /// <param name="separators">Separator string array</param>
        /// <returns></returns>
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var result = new List<string>();

            var splitWords = text.Split(separators, StringSplitOptions.None);

            foreach (var splitWord in splitWords)
            {
                var sortedWord = new string(splitWord.ToCharArray().OrderBy(c => c).ToArray());
                result.Add(sortedWord);
            }

            return result;
        }
    }
}
