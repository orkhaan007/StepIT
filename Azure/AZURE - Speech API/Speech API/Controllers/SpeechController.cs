using Microsoft.AspNetCore.Mvc;
using Speech_API.Services;

namespace Speech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechController : ControllerBase
    {
        private readonly SpeechApiService _speechApiService;

        public SpeechController(SpeechApiService speechApiService)
        {
            _speechApiService = speechApiService;
        }

        [HttpPost("recognize")]
        public async Task<IActionResult> RecognizeSpeech([FromForm] IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("Audio file is required.");
            }

            try
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await audioFile.CopyToAsync(stream);
                }

                var result = await _speechApiService.RecognizeSpeechAsync(filePath);
                return Ok(new { Transcription = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
