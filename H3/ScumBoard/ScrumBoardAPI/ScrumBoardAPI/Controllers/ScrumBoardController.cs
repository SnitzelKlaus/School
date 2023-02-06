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

        [HttpGet("all")]
        public IEnumerable<string> GetAll()
        {
            DAL access = new DAL();

            List<string> list = new List<string>();

            foreach(var board in access.database.Boards)
            {
                list.Add(JsonConvert.SerializeObject(board));
            }

            return list;
        }
    }
}
