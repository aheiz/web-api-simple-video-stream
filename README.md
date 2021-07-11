# web-api-simple-video-stream
Used to test html5 video element and asp.net core (net 5) simple file stream (FileStreamResult). 

## Flow:
1. The browser sends a http range header and requests only partial content (bytes) of the video. 
```
HTTP/1.1 200 OK
...
Accept-Ranges: bytes
Content-Length: 12345
```
2. The web api controller response is a FileStreamResult with the option "enableRangeProcessing" set to true.
```
[HttpGet("stream/{*path}")]
public FileStreamResult GetStreamFromPath(string path)
{
    string filepath = Path.Combine(this.webHostEnvironment.WebRootPath, "Content", path);

    return File(System.IO.File.OpenRead(filepath), "video/mp4", true);
}
```

The FileStreamResult type can take any stream to handle an HTTP range request.

Good blog post from KHALID ABUHAKMEH:
https://khalidabuhakmeh.com/partial-range-http-requests-with-aspnet-core
