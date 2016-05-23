﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
        public class Alarm : HomeDevice, ISecure
        {
            public Alarm(string name, bool power) : base(name, power)
            {
                this.Name = name;
                this.State = power;
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
