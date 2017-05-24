using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class Alarm : HomeDevice
    {
        public Alarm(string name, bool power) : base(name, power)
        { SafeOpportunity = new Safer(); }
    }
}
