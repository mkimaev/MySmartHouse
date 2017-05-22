using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class Alarm : HomeDevice, ISecure
    {
        public Alarm(string name, bool power) : base(name, power) {}
        public void Active() //дублирование кода, т.к. есть автосвойство в абстрактном классе, которое выполняет ту же функцию
        {
            isFunctionalActive = true;
        }

        public void Deactive() //дублирование кода, т.к. есть автосвойство в абстрактном классе, которое выполняет ту же функцию
        {
            isFunctionalActive = false;
        }

    }
}
