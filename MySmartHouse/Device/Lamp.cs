using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Lamp : HomeDevice, ILamps
    {
        public Rooms Room { get; set; }
        public Lamp (string name, bool power) : base(name, power)
        { BrightOpportunity = new Brightner(); }

        public void SetLampRoom(Rooms room, BrightMode mod)
        {
            BrightOpportunity.Bright = mod;
            Room = Room;
        }
    }
}
