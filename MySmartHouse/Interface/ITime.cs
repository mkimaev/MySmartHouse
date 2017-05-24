using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface ITime
    {
        int Time { get; set; }
        void SetTimer(int time); //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
    }
}