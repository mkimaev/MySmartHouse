using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Lamp : HomeDevice, ILight
    {
        public BrightMode Bright { get; set; }
        public Lamp (string name, bool power) : base(name, power) { }

        public void SetBright(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0}", Bright); }
            else
            { Console.WriteLine("Якрость 0% (выключено)"); }
        }
        public void SetLampBathroom(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0} в ванной", Bright); } 
            else
            { Console.WriteLine("Освещение ванны выключено"); } 
        }
        public void SetLampCourtYard(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0} во дворе", Bright); }
            else
            {
                Console.WriteLine("Освещение двора выключено");
            }
        }
        public void SetLampBedroom(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0} в спальне", Bright); }
            else
            {
                Console.WriteLine("Освещение в спальне выключено");
            }
        }
        public void SetLampKitchen(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0} на кухне", Bright); }
            else
            {
                Console.WriteLine("Освещение на кухне выключено");
            }
        }
        public void SetLampCellar(BrightMode mod)
        {
            Bright = mod;
            if (Bright == BrightMode.Bright100 | Bright == BrightMode.Bright75 | Bright == BrightMode.Bright50)
            { Console.WriteLine("Включён режим {0} в погребе", Bright); }
            else
            {
                Console.WriteLine("Освещение в погребе выключено");
            }
        }
    }
}
