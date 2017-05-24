using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Kettle : HomeDevice
    {
        public Kettle(string name, bool power): base (name,power)
        { TimeOpportunity = new Timer(); }
    }
}
