using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class ElectricOven : HomeDevice, ITime, ITemperature, ICook
    {
        public OvenMode Mode { get; set; }
        public int Time { get; set; }
        public int Celcius { get; set; }
        public ElectricOven(string name, bool power) : base (name, power)
        {
            Name = name;
            Power = power;
        }
        public void SetTimer(int time)
        {
            this.Time = time;
        }
        public void IncreaseTemp (int c)
        {
            this.Celcius = c;
        }
        public void DecreaseTemp(int c)
        {
            this.Celcius = c;
        }
        public void SetMode(OvenMode mod)
        {
            Mode = mod;
        }
    }
}
