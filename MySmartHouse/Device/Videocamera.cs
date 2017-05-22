using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Videocamera : HomeDevice, ISecure
    {
        public Videocamera(string name, bool power) : base (name, power)
        {
            this.Name = name;
            this.isDeviceTurnOn = power;
        }

        public void Active() //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        {
            isFunctionalActive = true;
        }

        public void Deactive() //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        {
            isFunctionalActive = false;
        }
    }

}