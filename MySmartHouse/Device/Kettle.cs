﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Kettle : HomeDevice, ITime
    {
        public Kettle(string name, bool power): base (name,power) { }
        public int Time { get; set; }
        public void SetTimer(int time)
        {
            this.Time = time;
        }

    }
}
