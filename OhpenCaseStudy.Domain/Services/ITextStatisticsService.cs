using OhpenCaseStudy.Dtos.TextStatistics;

namespace OhpenCaseStudy.Domain.Services
{
    public interface ITextStatisticsService
    {
        TextStatisticsOutputDto GenerateStatistics(string text);
    }
}
