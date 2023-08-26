using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.ImageUpload;

public class ImageUploadModel : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(IFormFile file)
    {
        if (file is not { Length: > 0 })
        {
            return Page();
        }

        var fileName = Path.GetRandomFileName();// Generates a unique name
        var tempPath = Path.Combine(Path.GetTempPath(), fileName);

        await using (var fileStream = new FileStream(tempPath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Partial("_ImagePartial", fileName);
    }

    public IActionResult OnGetFile(string filename)
    {
        var tempPath = Path.Combine(Path.GetTempPath(), filename);
        var fileBytes = System.IO.File.ReadAllBytes(tempPath);
        return new FileContentResult(fileBytes, "image/jpeg");// Adjust the MIME type accordingly
    }
}