using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Conditioner : HomeDevice, ITemperature, ITime
    {
        public int Time { get; set; }
        public int Celcius { get; set; }
        public Conditioner(string name, bool power) : base(name, power) { }

        public void SetTimer(int time)
        {
            this.Time = time;
            Console.WriteLine("Таймер установлен на {0} минут", Time);
        }
        public void IncreaseTemp(int c)
        {
            this.Celcius = c;
            Console.WriteLine("Температура увеличена до {0} градусов", Celcius);
        }
        public void DecreaseTemp(int c)
        {
            this.Celcius = c;
            Console.WriteLine("Температура уменьшена до {0} градусов", Celcius);
        }

    }
}
