using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    interface ISound
    {
        int Volume { get; set; }
        void SetVolume(int vol);//дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
    }
}
