namespace OhpenCaseStudy.Dtos.StringSort
{
    /// <summary>
    /// Input dto for the sort controller method
    /// </summary>
    public class SortInput
    {
        /// <summary>
        /// String value to sort
        /// </summary>
        public string  Text { get; set; }

        /// <summary>
        /// Algorithm of choice to sort the given Text
        /// </summary>
        public SortEnum SortEnum { get; set; }
    }
}
