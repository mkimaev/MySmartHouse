 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public abstract class HomeDevice
    {
        public ITemperature TemperatureOpportunity { get; set; }
        public ITime TimeOpportunity { get; set; }
        public ICook CookOpportunity { get; set; }
        public ISecure SafeOpportunity { get; set; }
        public ISound SoundOpportunity { get; set; }
        public IBrightness BrightOpportunity { get; set; }
        public HomeDevice(string name, bool power)
        {
            Name = name;
            isDeviceTurnOn = power;
        }
        public string Name { get; set; }
        public bool isDeviceTurnOn { get; set; }
        public bool isFunctionalActive {get; set;}

        public string TurnOn(bool power) 
        {
            isDeviceTurnOn = power;
            if (power == true) { return string.Format("Оборудование {0} включено", Name); }
            else { return string.Format("Оборудование {0} выключено", Name); }
        }
    }
}