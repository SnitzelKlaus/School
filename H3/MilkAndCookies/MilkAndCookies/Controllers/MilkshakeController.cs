using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkshakeController : ControllerBase
    {
        // GET api/milkshake/Chocolate
        [HttpGet("favmilkshake")]
        public string GetMilkshake(string milkshake)
        {
            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddMinutes(5);

            Response.Cookies.Append("favMilkshake", milkshake, co);

            return $"value {milkshake}";
        }

        [HttpGet("getmilkshake")]
        public string GetFromCookie()
        {
            string? milkshake = Request.Cookies["favMilkshake"];

            if (Request.Cookies["favMilkshake"] == null)
                milkshake = "unknown";

            Response.Cookies.Delete("favMilkshake");

            return milkshake;
        }
    }
}
