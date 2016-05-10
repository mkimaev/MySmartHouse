using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    interface ILamps
    {
        void SetLampBathroom(BrightMode mod);
        void SetLampCourtYard(BrightMode mod);
        void SetLampBedroom(BrightMode mod);
        void SetLampKitchen(BrightMode mod);
        void SetLampCellar(BrightMode mod);
    }
}
