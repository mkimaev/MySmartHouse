using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Brightner : IBrightness
    {
        public BrightMode Bright { get; set; }
        public void SetBright(BrightMode mod)
        {
            Bright = mod;
        }
    }
}
