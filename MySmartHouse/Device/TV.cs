using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class TV : HomeDevice, ISound, ILight, ITime
    {
        public Channels Chanel { get; set; }
        public int Volume { get; set; }
        public BrightMode Bright { get; set; }
        public int Time { get; set; }
        public TV (string name, bool power): base (name, power) {}
        public void SetVolume (int vol)
        {
            Volume = vol;
            Console.WriteLine("Громкость ({0})", Volume);
        }
        public void SetBright(BrightMode mod)
        {
            Bright = mod;
            Console.WriteLine("Яркость ({0})", Bright);
        }
        public void SetChannel(Channels ch)
        {
            Chanel = ch;
            Console.WriteLine("Транслируется ТВ канал: {0}", Chanel);
        }
        public void NextChannel()
        {
            Console.WriteLine("Вкючён следующий канал");
        }
        public void PreChannel()
        {
            Console.WriteLine("Вкючён предыдущий канал");
        }
        public void SetTimer(int time)
        {
            this.Time = time;
            Console.WriteLine("Таймер установлен на {0} минут", Time);
        }

    }
}
