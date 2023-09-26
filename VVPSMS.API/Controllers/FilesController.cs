using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VVPSMS.API.Controllers
{
    [ApiController]
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFiles(List<IFormFile> formFile, CancellationToken cancellationToken)
        {
            var result = await WriteFile(formFile);
            return Ok(result);
        }

        private async Task<List<string>> WriteFile(List<IFormFile> files)
        {
            List<string> filename = new List<string>();
            try
            {
                int index = 0;
                foreach (var file in files)
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    var filename1 = DateTime.Now.Ticks.ToString() + extension;
                    filename.Add(filename1);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename1);
                    using (var stream = new FileStream(exactPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {

            }
            return filename;
        }
    }
}
