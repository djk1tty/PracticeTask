using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.ActionClass;
using FileExchangerAPI.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileExchangerAPI.Models;
using File = FileExchangerAPI.Models.File;

namespace FileExchangerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFile _IFile;

        public FileController(IFile iFile)
        {
            _IFile = iFile;
        }

        [HttpPost("AddFile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public List<string> Post(FileCreate file)
        {
            return _IFile.AddFile(file);
        }

        [HttpGet("GetFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<File> Get()
        {
            return _IFile.GetFiles();
        }

        [HttpGet("GetFileById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<File> Get(int id)
        {
            return _IFile.GetFileById(id);
        }
        [HttpDelete("DeleteFile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public List<string> Delete(int id)
        {
            return _IFile.DeleteFile(id);
        }

        [HttpPatch("UpdateFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<string> Patch(int id, UpdateFileDTO file)
        {
            return _IFile.UpdateFile(id, file);
        }
    }
}
