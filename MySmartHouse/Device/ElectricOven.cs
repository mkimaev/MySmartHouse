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
        public ElectricOven(string name, bool power) : base (name, power)
        {
            Name = name;
            Power = power;
            State = false;
        }
        public void SetTimer(int time)
        {
            this.Time = time;
            Console.WriteLine("Таймер установлен на {0} минут", Time);
        }
        public void IncreaseTemp (int c)
        {
            this.Celcius = c;
            Console.WriteLine("Температура увеличена до {0} градусов", Celcius);
        }
        public void DecreaseTemp(int c)
        {
            this.Celcius = c;
            Console.WriteLine("Температура уменьшена до {0} градусов", Celcius);
        }
        public void SetMode(OvenMode mod)
        {
            Mode = mod;
            if (mod == OvenMode.Pizza) {
                Celcius = 180;
                Time = 90;
                Console.WriteLine("Установлен режим приготовления пиццы. Температура {0} градусов. Таймер {1} минут ", Celcius, Time);
            }
            else if (mod == OvenMode.BakeCakes) { Console.WriteLine("Установлен режим выпечки"); }
            else { Console.WriteLine("Установлен режим запекания птицы"); }
        }
    }
}
