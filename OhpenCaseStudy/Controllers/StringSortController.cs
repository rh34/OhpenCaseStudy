using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Api.Controllers
{
    /// <summary>
    /// String sort controller
    /// </summary>
    [ApiController]
    [Route("api/StringSort")]
    public class StringSortController : ControllerBase
    {
        private readonly IStringSortService _stringSortService;


        /// <summary>
        /// String Sort Controller Constructor
        /// </summary>
        /// <param name="stringSortService">String sort service reference </param>
        public StringSortController(IStringSortService stringSortService)
        {
            _stringSortService = stringSortService;
        }

        /// <summary>
        /// Takes a text and sorting algorithm of your choice to process the result.
        /// </summary>
        /// <param name="sortInput">Holds the text and the desired sorting algorithm input</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody]SortInput sortInput)
        {
            var sortResult = _stringSortService.Sort(sortInput.Text, sortInput.SortEnum);
            return Ok(sortResult);
        }
    }
}
