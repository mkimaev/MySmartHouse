using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class GrillDevice : HomeDevice
    {
        public GrillDevice(string name, bool power) : base(name, power)
        {
            TemperatureOpportunity = new Temperaturer();
            TimeOpportunity = new Timer();
            CookOpportunity = new Cooker();
            BrightOpportunity = new Brightner();
            SafeOpportunity = new Safer();
            SoundOpportunity = new Sounder();
        }
    }
}
