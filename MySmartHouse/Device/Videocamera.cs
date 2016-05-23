﻿using System;
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
            State = true;
        }

        public void Deactive()
        {
            State = false;
        }
    }

}