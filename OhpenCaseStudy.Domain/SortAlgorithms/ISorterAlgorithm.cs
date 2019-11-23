using System.Collections.Generic;

namespace OhpenCaseStudy.Domain.SortAlgorithms
{
    public interface ISorterAlgorithm
    {
        IEnumerable<string> Sort(string text, string[] separators);
    }
}