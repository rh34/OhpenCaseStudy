using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Dtos;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Api.Controllers
{
    [ApiController]
    [Route("StringSort")]
    public class StringSortController : ControllerBase
    {
        private readonly ILogger<StringSortController> _logger;
        private readonly IStringSortService _stringSortService;


        public StringSortController(ILogger<StringSortController> logger, IStringSortService stringSortService)
        {
            _logger = logger;
            _stringSortService = stringSortService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]SortInput sortInput)
        {
            var sortResult = _stringSortService.Sort(sortInput.Text, sortInput.SortEnum);
            return Ok();
        }
    }
}
