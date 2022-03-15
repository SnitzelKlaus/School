using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    interface IFilter
    {
        bool Filter { get; set; }

        void FilterUsed();
        void ReplaceFilter();
    }
}
