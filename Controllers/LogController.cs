using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Serilog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> LogInformation()
        {
            await Task.Delay(500);
            _logger.LogInformation("Used Logger for information");
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> LogError()
        {
            try
            {
                await Task.Delay(500);
                throw new Exception("There was an error");
            }
            catch (Exception ex)
            {
                _logger.LogError("Used Logger for error", $"{ex.Message} , {ex.StackTrace}");
                return BadRequest();
            }
        }

    }
}
