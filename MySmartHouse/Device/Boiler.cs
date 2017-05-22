using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Boiler : HomeDevice, ITemperature, ITime
    {
        public int Time { get; set; }
        private int temperature;
        public int Celcius
        { //применяю принцип подстановки Лисков - предусловие, а то у жителей будут ожоги.
            get { return temperature; }
            set
            {
                if (value <= 0 | value > 80) { throw new Exception("Недопустимое зачение. Допустимо от 1 до 79"); }
                else temperature = value;
            }
        }
        public Boiler(string name, bool power) : base(name, power) { }

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
