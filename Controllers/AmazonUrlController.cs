using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using amazon.Logics;

namespace amazon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonUrlController : ControllerBase
    {
        private readonly ILogger<AmazonUrlController> _logger;
        private readonly IAmazonUrlFilter _filter;
        public AmazonUrlController(ILogger<AmazonUrlController> logger, IAmazonUrlFilter filter)
        {
            _logger = logger;
            _filter = filter;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] string url)
        {
            try
            {

                return Ok(_filter.Apply(url));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}