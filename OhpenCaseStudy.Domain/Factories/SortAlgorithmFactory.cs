using System;
using OhpenCaseStudy.Dtos.StringSort;
using Microsoft.Extensions.DependencyInjection;
using OhpenCaseStudy.Domain.SortAlgorithms;

namespace OhpenCaseStudy.Domain.Factories
{
    public class SortAlgorithmFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SortAlgorithmFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Returns a sorter algorithm instance based on sortEnum input
        /// </summary>
        /// <param name="sortEnum">Sort algorithm choice</param>
        /// <returns></returns>
        public virtual ISorterAlgorithm GetSorter(SortEnum sortEnum)
        {
            switch (sortEnum)
            {
                case SortEnum.AlphabeticalSortAlgorithm:
                    return _serviceProvider.GetRequiredService<AlphabeticalSorter>();
                case SortEnum.WordSizeSortAlgorithm:
                    return _serviceProvider.GetRequiredService<WordSizeSorter>();
                case SortEnum.CharacterWithinWordAlgorithm:
                    return _serviceProvider.GetRequiredService<CharacterWithinWordSorter>();
                default:  
                    throw new NotImplementedException($"Sorter Algorithm is not implemented for SortEnum: {sortEnum}");
            }
        }
    }
}