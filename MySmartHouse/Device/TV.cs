using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class TV : HomeDevice, ISound, ILight, ITime, ITv
    {
        public Channels Chanel { get; set; }
        public int Volume { get; set; }
        public BrightMode Bright { get; set; }
        public int Time { get; set; }
        public TV (string name, bool power): base (name, power) {}
        public void SetVolume (int vol)
        {
            Volume = vol;
        }
        public void SetBright(BrightMode mod)
        {
            Bright = mod;
        }
        public void SetChannel(Channels ch)
        {
            Chanel = ch;
        }
        public void NextChannel()
        {
        }
        public void PreChannel()
        {
        }
        public void SetTimer(int time)
        {
            this.Time = time;
        }

    }
}
