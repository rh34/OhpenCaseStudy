using OhpenCaseStudy.Dtos.TextStatistics;

namespace OhpenCaseStudy.Domain.Services
{
    public interface ITextStatisticsService
    {
        TextStatistics GenerateStatistics(string text);
    }
}
