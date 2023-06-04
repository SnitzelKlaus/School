using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPricePredictor.ML.Objects
{
    public class StockPrediction
    {
        public float Score { get; set; }
        public StockPrediction() { }
        public StockPrediction(float score)
        {
            Score = score;
        }

        public override string ToString()
        {
            return $"Prediction: {Score}";
        }

        public string ToCsv()
        {
            return $"{Score}";
        }

        public static string GetCsvHeader()
        {
            return $"Score";
        }

        public static StockPrediction FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            StockPrediction stockPrediction = new StockPrediction();
            stockPrediction.Score = float.Parse(values[0]);
            return stockPrediction;
        }

        public static List<StockPrediction> FromCsv(List<string> csvLines)
        {
            List<StockPrediction> stockPredictions = new List<StockPrediction>();
            foreach (string csvLine in csvLines)
            {
                stockPredictions.Add(FromCsv(csvLine));
            }
            return stockPredictions;
        }

        public static List<string> ToCsv(List<StockPrediction> stockPredictions)
        {
            List<string> csvLines = new List<string>();
            foreach (StockPrediction stockPrediction in stockPredictions)
            {
                csvLines.Add(stockPrediction.ToCsv());
            }
            return csvLines;
        }

        public static List<string> GetCsvHeaders()
        {
            List<string> csvHeaders = new List<string>();
            csvHeaders.Add(GetCsvHeader());
            return csvHeaders;
        }

        public static List<string> GetCsvHeaders(List<StockPrediction> stockPredictions)
        {
            List<string> csvHeaders = new List<string>();
            csvHeaders.Add(GetCsvHeader());
            return csvHeaders;
        }

        public static List<string> GetCsvHeaders(List<string> csvLines)
        {
            List<string> csvHeaders = new List<string>();
            csvHeaders.Add(GetCsvHeader());
            return csvHeaders;
        }
    }
}
