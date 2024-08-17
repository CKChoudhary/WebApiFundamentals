using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider )
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ??
                                                throw new System.ArgumentNullException(
                                                    nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {

            const string pathToFile = "README.md";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            string? contentType;
            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
