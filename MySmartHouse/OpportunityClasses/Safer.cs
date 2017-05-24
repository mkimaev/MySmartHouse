using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Safer : ISecure
    {
        bool ReadyToSafe { get; set; }
        public void Active()
        {
            ReadyToSafe = true;
        }

        public void Deactive()
        {
            ReadyToSafe = false;
        }
    }
}
