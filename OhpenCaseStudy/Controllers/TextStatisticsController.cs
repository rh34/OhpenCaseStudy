using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TextStatisticsOutputDto> GenerateStatistics(string text)
        {
            var result = _textStatisticsService.GenerateStatistics(text);
            return Ok(result);
        }
    }
}