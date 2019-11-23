using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Services
{
    public interface IStringSortService
    {
        SortResult Sort(string text, SortEnum sortEnum);
    }
}
