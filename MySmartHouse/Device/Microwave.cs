using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Microwave : HomeDevice
    {
        public Microwave(string name, bool power) : base (name, power)
        {
            TimeOpportunity = new Timer();
            TemperatureOpportunity = new Temperaturer();
            CookOpportunity = new Cooker();
        }
    }
}