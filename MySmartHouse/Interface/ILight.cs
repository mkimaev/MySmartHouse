using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    interface ILight
    {
        BrightMode Bright { get; set; }
        void SetBright(BrightMode mod);
    }
}
