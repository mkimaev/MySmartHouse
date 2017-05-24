using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Cooker : ICook
    {
        public OvenMode bakeMode { get; set; }
        public void SetMode(OvenMode mod)
        {
            bakeMode = mod;
        }
    }
}
