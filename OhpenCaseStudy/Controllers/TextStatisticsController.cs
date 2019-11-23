using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Dtos.TextStatistics;

namespace OhpenCaseStudy.Api.Controllers
{
    /// <summary>
    /// Generates statistics for a given texts
    /// </summary>
    [Route("api/TextStatistics")]
    [ApiController]
    public class TextStatisticsController : ControllerBase
    {
        private readonly ITextStatisticsService _textStatisticsService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textStatisticsService"></param>
        public TextStatisticsController(ITextStatisticsService textStatisticsService)
        {
            _textStatisticsService = textStatisticsService;
        }

        /// <summary>
        /// Generates statistics for Hyphen, Word and Space counts.
        /// </summary>
        /// <param name="input">Input to generate statistics for</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TextStatistics> GenerateStatistics(TextStatisticsInputDto input)
        {
            var result = _textStatisticsService.GenerateStatistics(input.Text);
            return Ok(result);
        }
    }
}