using System.Collections.Generic;

namespace OhpenCaseStudy.Dtos.StringSort
{
    /// <summary>
    /// Sort result information based on sort action.
    /// </summary>
    public class SortResult
    {
        /// <summary>
        /// List of strings after sort action
        /// </summary>
        public IEnumerable<string> SortedList { get; set; }
    }
}
