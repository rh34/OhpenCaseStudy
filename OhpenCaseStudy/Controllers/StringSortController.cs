using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OhpenCaseStudy.Controllers
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
