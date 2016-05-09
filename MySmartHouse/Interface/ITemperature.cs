using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    interface ITemperature
    {
        int Celcius { get; set; }
        void IncreaseTemp(int celsius);
        void DecreaseTemp(int celsius);
    }
}
