using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    interface ITv
    {
        Channels Chanel { get; set; }
        void SetChannel(Channels ch); //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        void NextChannel();
        void PreChannel();
    }
}
