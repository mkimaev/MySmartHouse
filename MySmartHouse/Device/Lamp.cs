using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Lamp : HomeDevice, ILight, ILamps
    {
        public BrightMode Bright { get; set; }
        public Rooms Room { get; set; }
        public Lamp (string name, bool power) : base(name, power) { }

        public void SetBright(BrightMode mod) //дублирование кода, т.к. есть автосвойство, которое выполняет ту же функцию
        {
            Bright = mod;
        }
        public void SetLampRoom(Rooms room, BrightMode mod)
        {
            Bright = mod;
            Room = Room;
        }
    }
}
