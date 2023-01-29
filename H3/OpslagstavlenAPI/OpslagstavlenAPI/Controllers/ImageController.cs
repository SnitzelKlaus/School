using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpslagstavlenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        [Route("GetImage")]
        public IEnumerable<string> Get()
        {

        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> Upload(string image)
        {

        }
    }
}
