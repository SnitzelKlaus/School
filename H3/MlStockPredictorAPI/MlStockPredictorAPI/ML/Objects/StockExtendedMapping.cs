using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlStockPredictorAPI.ML.Objects
{
    [CustomMappingFactoryAttribute("StockExtendedMapping")]
    public class StockExtendedMapping : CustomMappingFactory<Stock, StockExtended>
    {
        // Starting point for converting date to float (in days)
        private readonly DateTime startingPoint = new DateTime(2000, 1, 1);

        public override Action<Stock, StockExtended> GetMapping()
        {
            return (input, output) =>
            {
                DateTime inputDate = DateTime.Parse(input.Date);
                output.DateFloat = (float)(inputDate - startingPoint).TotalDays;
                output.Open = input.Open;
                output.High = input.High;
                output.Low = input.Low;
                output.Close = input.Close;
                output.AdjClose = input.AdjClose;
                output.Volume = input.Volume;
            };
        }
    }
}
