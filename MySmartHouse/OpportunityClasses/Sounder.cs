using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Sounder : ISound
    {
        int volumeRate;
        public int Volume
        {
            get
            {
                return volumeRate;
            }

            set
            {
                if (value < 0 | value >= 100) { throw new Exception("Недопустимое зачение. Значение должно быть от 0 до 100"); }
                else volumeRate = value;
            }
        }

        public void SetVolume(int vol)
        {
            if (vol < 0 | vol >= 100) { throw new Exception("Недопустимое зачение. Значение должно быть от 0 до 100"); }
            else volumeRate = vol;
        }
    }
}
