using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacePresentation.Interfaces
{
    public interface IFish
    {
        string Name { get; set; }
        string Description { get; set; }
        string Habitat { get; set; }
        string Diet { get; set; }
    }
}
