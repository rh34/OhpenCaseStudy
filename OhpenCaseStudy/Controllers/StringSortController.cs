using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OhpenCaseStudy.Api.Controllers
{
    [ApiController]
    [Route("StringSort")]
    public class StringSortController : ControllerBase
    {
        private readonly ILogger<StringSortController> _logger;

        public StringSortController(ILogger<StringSortController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
