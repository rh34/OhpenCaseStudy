namespace OhpenCaseStudy.Dtos.StringSort
{
    /// <summary>
    /// Sort algorithms
    /// </summary>
    public enum SortEnum
    {
        /// <summary>
        /// To sort words alphabetically
        /// </summary>
        AlphabeticalSortAlgorithm = 1,

        /// <summary>
        /// To sort words based on their character length
        /// </summary>
        WordSizeSortAlgorithm = 2,

        /// <summary>
        /// To sort characters in every word
        /// </summary>
        CharacterWithinWordAlgorithm = 3
    }
}