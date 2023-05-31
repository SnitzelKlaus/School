using Microsoft.ML;
using resturant.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant.ML.Base
{
    //public class BaseML
    //{
    //    protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_FILENAME);
    //    protected readonly MLContext MlContext;
    //    protected BaseML()
    //    {
    //        MlContext = new MLContext(2020);
    //    }
    //}

    public class BaseML
    {
        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_FILENAME);

        protected readonly MLContext MlContext;

        protected BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}
