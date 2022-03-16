using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public interface IMagic
    {
        public void Teleport(int x, int y);

        public void ThrowFrostNova();

        public void ThrowMagicMisile();
    }
}
