using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.FileUpload;

public class FileUploadModel : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(IFormFile file)
    {
        return Content($"<p>File {file.FileName} with length {file.Length} uploaded successfully!</p>", "text/html");
    }
}