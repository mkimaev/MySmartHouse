using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Microwave : HomeDevice, ITime
    {
        public Microwave(string name, bool power) : base (name, power)
        {
            Name = name;
            Power = power;
        }
        public int Time {get; set;}
        public void SetTimer(int time)
        {
            this.Time = time;
        }
    }
}