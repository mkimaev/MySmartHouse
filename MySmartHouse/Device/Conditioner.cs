using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Conditioner : HomeDevice, ITemperature, ITime
    {
        public int Time { get; set; }
        public int Celcius { get; set; }
        public Conditioner(string name, bool power) : base(name, power) { }

        public void SetTimer(int time) //дублирование кода, т.к. есть автосвойство Time, которое выполняет ту же функцию
        {
            Time = time;
        }
        public void IncreaseTemp(int c) //дублирование кода, т.к. есть автосвойство Celcius, которое выполняет ту же функцию
        {
            Celcius = c;
        }
        public void DecreaseTemp(int c) //дублирование кода, т.к. есть автосвойство Celcius, которое выполняет ту же функцию
        {
            Celcius = c;
        }

    }
}
