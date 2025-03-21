using Microsoft.AspNetCore.Mvc;

namespace FileUploadTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadFileController : ControllerBase
{
    [HttpPost(nameof(Upload))]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        using var fileStream = new FileStream(file.FileName, FileMode.Create);

        using var stream = file.OpenReadStream();

        await stream.CopyToAsync(fileStream);

        return Ok(new { FilePath = file.FileName, Message = "File uploaded successfully!" });
    }
}
