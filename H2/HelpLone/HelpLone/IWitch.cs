using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public interface IWitch
    {
        public void RaiseShield();
        public void ShieldGlare();
        public void Teleport(int x, int y);
    }
}
