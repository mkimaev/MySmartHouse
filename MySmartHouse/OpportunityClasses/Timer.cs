using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{

    //delegate void TimeHandler();
    class Timer : ITime
    {
        //event TemperatureHandler HighCelcius;
        private int time = 0;

        public int Time
        {
            get { return time; }
            set
            {
                if (value <= 0) { throw new Exception("Недопустимое зачение. Значение должно быть положительным"); }
                else time = value;
            }
        }

        public void SetTimer(int inputTime)
        {
            Time = inputTime;
            // return string.Format("Таймер установлен на {0} минут", inputTime)
        }
    }
}
