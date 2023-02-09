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

            jsonString = jsonString.Substring(1, jsonString.Length - 2);

            return jsonString;
        }

        [HttpGet("all")]
        public string GetAll()
        {
            DAL access = new DAL();

            string jsonString = JsonConvert.SerializeObject(access.database.Boards);

            return jsonString;
        }
    }
}
