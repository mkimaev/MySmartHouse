 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public abstract class HomeDevice
    {
        public HomeDevice(string name, bool power)
        {
            Name = name;
            isDeviceTurnOn = power;
        }
        public string Name { get; set; }
        public bool isDeviceTurnOn { get; set; }
        public bool isFunctionalActive {get; set;}

        public void PowerOn(bool power) //дублирование кода, т.к. есть автосвойство isTurnOn, которое выполняет ту же функцию
        {
            isDeviceTurnOn = power;
        }
    }
}