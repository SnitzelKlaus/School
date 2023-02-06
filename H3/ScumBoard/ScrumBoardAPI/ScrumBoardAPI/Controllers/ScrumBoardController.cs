using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.Models;
using Newtonsoft.Json;

namespace ScrumBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrumBoardController : ControllerBase
    {
        [HttpGet("board")]
        public string GetBoard(int id)
        {
            DAL access = new DAL();

            string jsonString = JsonConvert.SerializeObject(access.database.Boards.Where(x => x.Id == id));

            return jsonString;
        }
    }
}
