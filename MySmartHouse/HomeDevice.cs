 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public abstract class HomeDevice
    {
        public HomeDevice(string name, bool power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; set; }
        public bool Power { get; set; }
        public bool State {get; set;}

        public void PowerOn(bool power)
        {
            this.Power = power;
        }
    }
}