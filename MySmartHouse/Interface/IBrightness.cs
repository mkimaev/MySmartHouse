using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public interface IBrightness
    {
        BrightMode Bright { get; set; }
        void SetBright(BrightMode mod);
    }
}
