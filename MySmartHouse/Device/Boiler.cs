using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Boiler : HomeDevice
    {

        public Boiler(string name, bool power) : base(name, power)
        {
            TemperatureOpportunity = new Temperaturer();
            TimeOpportunity = new Timer();
        }
    }
}
