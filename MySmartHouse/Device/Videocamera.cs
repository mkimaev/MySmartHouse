using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Videocamera : HomeDevice
    {
        public Videocamera(string name, bool power) : base (name, power)
        {
            SafeOpportunity = new Safer();
            TimeOpportunity = new Timer();
        }
        public void RecordOn(bool command) { }

    }

}