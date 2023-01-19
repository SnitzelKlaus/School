using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        // GET api/milkshake/Chocolate
        [HttpGet("favcookie")]
        public string Get(string cookie)
        {
            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddMinutes(5);

            Response.Cookies.Append("favCookie", cookie, co);

            return $"value {cookie}";
        }

        [HttpGet("getcookie")]
        public string GetFromCookie()
        {
            string? cookie = Request.Cookies["favcookie"];

            if (Request.Cookies["favcookie"] == null)
                cookie = "unknown";

            Response.Cookies.Delete("favcookie");

            return cookie;
        }
    }
}
