using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public VideoController(
            ILogger<VideoController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("stream/{*path}")]
        public FileStreamResult GetStreamFromPath(string path)
        {
            string filepath = Path.Combine("Content", path);

            return File(System.IO.File.OpenRead(filepath), "video/mp4", true);
        }
    }
}
