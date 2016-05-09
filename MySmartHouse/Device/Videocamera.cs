using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Videocamera : HomeDevice, ISecure
    {
        public Videocamera(string name, bool power) : base (name, power)
        {
            this.Name = name;
            this.Power = power;
        }

        public void Active()
        {
            Console.WriteLine("Съёмка c {0} включена\n", Name); ;
            State = true;
        }

        public void Deactive()
        {
            Console.WriteLine("Съёмка c {0} выключена\n", Name);
            State = false;
        }
    }

}