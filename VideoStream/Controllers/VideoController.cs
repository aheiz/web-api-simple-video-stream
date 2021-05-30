using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

namespace VideoStream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;

        public VideoController(
            ILogger<VideoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("stream/{*path}")]
        public FileResult GetStreamFromPath(string path)
        {
            string filepath = Path.Combine("Content", path);

            return new VirtualFileResult(filepath, "video/mp4");
        }
    }
}
