using Microsoft.AspNetCore.Mvc;
using MlStockPredictorAPI.ML.Interfaces;

namespace MlStockPredictorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrainer _trainer;
        private readonly IPredictor _predictor;

        public HomeController(ILogger<HomeController> logger, ITrainer trainer, IPredictor predictor)
        {
            _logger = logger;
            _trainer = trainer;
            _predictor = predictor;
        }

        [HttpGet("Train")]
        public string Train(string symbol)
        {
            //_trainer.Train($"..\\..\\Data\\{symbol}\\sampledata.csv", $"..\\..\\Data\\{symbol}\\testdata.csv");
            _trainer.Train($"C:\\Code\\School\\H3\\MlStockPredictorAPI\\MlStockPredictorAPI\\Data\\{symbol}\\{symbol}.csv", $"C:\\Code\\School\\H3\\MlStockPredictorAPI\\MlStockPredictorAPI\\Data\\{symbol}\\{symbol}.csv");
            return "OK";
        }

        [HttpGet("Predict")]
        public string Predict(string symbol)
        {
            _predictor.Predict($"..\\..\\Data\\{symbol}\\{symbol}.csv");
            return "OK";
        }
    }
}
