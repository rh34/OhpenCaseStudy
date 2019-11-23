using System;
using System.Collections.Generic;
using System.Linq;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    public class CharacterWithinWordSorter : ISorterAlgorithm
    {
        public IEnumerable<string> Sort(string text, string[] separators)
        {
            var result = new List<string>();

            var splitWords = text.Split(separators, StringSplitOptions.None);

            foreach (var splitWord in splitWords)
            {
                result.Add(new string(splitWord.ToCharArray().OrderBy(c => c).ToArray()));
            }

            return result;
        }
    }
}
