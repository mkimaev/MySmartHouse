using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Conditioner : HomeDevice, ITemperature, ITime
    {
        public int Time { get; set; }
        public int Celcius { get; set; }
        public Conditioner(string name, bool power) : base(name, power) { }

        public void SetTimer(int time)
        {
            this.Time = time;
        }
        public void IncreaseTemp(int c)
        {
            this.Celcius = c;
        }
        public void DecreaseTemp(int c)
        {
            this.Celcius = c;
        }

    }
}
