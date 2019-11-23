using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Dtos;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Api.Controllers
{
    /// <summary>
    /// String sort controller
    /// </summary>
    [ApiController]
    [Route("StringSort")]
    public class StringSortController : ControllerBase
    {
        private readonly ILogger<StringSortController> _logger;
        private readonly IStringSortService _stringSortService;


        /// <summary>
        /// String Sort Controller Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="stringSortService">String sort service reference </param>
        public StringSortController(ILogger<StringSortController> logger, IStringSortService stringSortService)
        {
            _logger = logger;
            _stringSortService = stringSortService;
        }

        /// <summary>
        /// Takes a text and sorting algorithm of your choice to process the result.
        /// </summary>
        /// <param name="sortInput">Holds the text and the desired sorting algorithm input</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]SortInput sortInput)
        {
            var sortResult = _stringSortService.Sort(sortInput.Text, sortInput.SortEnum);
            return Ok(sortResult);
        }
    }
}
