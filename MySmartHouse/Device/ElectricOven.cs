using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class ElectricOven : HomeDevice, ITime, ITemperature, ICook
    {
        public OvenMode Mode { get; set; }
        public int Time { get; set; }
        public int Celcius { get; set; }
        public ElectricOven(string name, bool power) : base (name, power) {}
        public void SetTimer(int time) //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        {
            Time = time;
        }
        public void IncreaseTemp (int c) //дублирование кода, т.к. есть автосвойство Celcius, которое выполняет ту же функцию
        {
            Celcius = c;
        }
        public void DecreaseTemp(int c) //дублирование кода, т.к. есть автосвойство Celcius, которое выполняет ту же функцию
        {
            Celcius = c;
        }

        //remake
        public void SetMode(OvenMode mod) //дублирование кода, т.к. есть автосвойство Mode, которое выполняет ту же функцию
        {
            Mode = mod;
        }
    }
}
