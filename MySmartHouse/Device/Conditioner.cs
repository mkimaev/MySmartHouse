using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Conditioner : HomeDevice
    {
        public Conditioner(string name, bool power) : base(name, power)
        {
            TemperatureOpportunity = new Temperaturer();
            TimeOpportunity = new Timer();
        }
    }
}
