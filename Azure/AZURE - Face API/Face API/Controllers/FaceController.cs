using Face_API.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FaceController : ControllerBase
{
    private readonly FaceApiService _faceApiService;

    public FaceController(FaceApiService faceApiService)
    {
        _faceApiService = faceApiService;
    }

    [HttpPost("detect")]
    public async Task<IActionResult> DetectFaces([FromBody] string imageUrl)
    {
        try
        {
            var result = await _faceApiService.DetectFacesAsync(imageUrl);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}