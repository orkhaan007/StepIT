using Docker_Volume.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeVolumeTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestVolumeController : ControllerBase
    {
        private const string errorVolumePath = "/app/errors.txt";
        private const string infosVolumePath = "/app/infos.txt";
        private readonly IFileService _fileService;

        public TestVolumeController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("test-volume")]
        public async Task<IEnumerable<string>> Get()
        {
            await _fileService.AppendInfoAsync(infosVolumePath, "INFO");
            await _fileService.AppendInfoAsync(errorVolumePath, "ERROR");
            var errorLogs = await _fileService.GetInfoAsync(errorVolumePath);
            var infoLogs = await _fileService.GetInfoAsync(infosVolumePath);
            return new string[] { $"Errors: {errorLogs} .", $"Infos: {infoLogs} " };
        }

        [HttpGet("test-volume/{num}")]
        public async Task<string> Get(int num)
        {
            try
            {
                if (num < 0) throw new ArgumentOutOfRangeException("Cant be Zero!");
                await _fileService.AppendInfoAsync(infosVolumePath, "Info Worked");
                return "OK!";
            }
            catch (Exception ex)
            {
                await _fileService.AppendInfoAsync(errorVolumePath, string.Concat("Error Worked!"));
                throw;
            }
        }
    }
}