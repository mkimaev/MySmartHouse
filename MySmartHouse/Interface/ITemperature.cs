using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface ITemperature
    {
        int Celisius { get; set; }
        void IncreaseTemp(int celsius);
        void DecreaseTemp(int celsius);
    }
}
