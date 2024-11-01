using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OefeningUserAgentMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ExampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("settings")]
        public ActionResult GetSettings()
        {
            var name = _configuration["ExampleSettings:ExampleName"];
            var password = _configuration["ExampleSettings:ExamplePassword"];

            return Ok(new { Username = name, Password = password });
        }
    }
}
