using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface ISecure
    {
        void Active(); //дублирование кода, т.к. есть автосвойство у абст.класса, которое выполняет ту же функцию
        void Deactive(); //дублирование кода, т.к. есть автосвойство у абст.класса, которое выполняет ту же функцию
    }
}