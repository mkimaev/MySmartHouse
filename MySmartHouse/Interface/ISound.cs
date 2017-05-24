using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public interface ISound
    {
        int Volume { get; set; }
        void SetVolume(int vol);
    }
}
