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
            List<string> images = Directory.GetFiles("Images", "*.*", SearchOption.AllDirectories).ToList();
            List<string> resultImages = new List<string>();

            foreach (string image in images)
            {
                FileInfo imageInfo = new FileInfo(image);
                byte[] imageBytes = new byte[imageInfo.Length];
                using (FileStream stream = imageInfo.OpenRead())
                {
                    stream.Read(imageBytes, 0, imageBytes.Length);
                }
                resultImages.Add(Convert.ToBase64String(imageBytes));
            }
            return resultImages;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> Upload(string image)
        {
            Random rndm = new Random();
            int imageNumber = rndm.Next(1, 1000);
            if (!String.IsNullOrEmpty(image))
            {
                string path = "Images/" + imageNumber + ".jpg";
                var formattedString = image.Replace(" ", "+");
                byte[] imageBytes = Convert.FromBase64String(formattedString);
                System.IO.File.WriteAllBytes(path, imageBytes);
                return Content("Succesfully saved image");
            }
            return Content("Couldnt save image, something went wrong");
        }
    }
}
