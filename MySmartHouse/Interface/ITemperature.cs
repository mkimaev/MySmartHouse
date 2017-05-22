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
        void IncreaseTemp(int celsius); //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        void DecreaseTemp(int celsius); //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
    }
}
