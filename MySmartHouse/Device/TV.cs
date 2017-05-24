using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class TV : HomeDevice, ITv
    {
        public Channels Chanel { get; set; }
        public BrightMode Bright { get; set; }
        public TV (string name, bool power): base (name, power)
        {
            TimeOpportunity = new Timer();
            SoundOpportunity = new Sounder();
            BrightOpportunity = new Brightner();
        }
        public void SetChannel(Channels ch) //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        {
            Chanel = ch;
        }
        public void NextChannel()
        {
        }
        public void PreChannel()
        {
        }

    }
}
