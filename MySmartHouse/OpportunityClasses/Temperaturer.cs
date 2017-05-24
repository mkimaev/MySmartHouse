using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{

    //delegate void TemperatureHandler();
    class Temperaturer : ITemperature
    {
        //event TemperatureHandler HighCelcius;
        private int temperature = 0;
        public int Celisius //применяю принцип подстановки Лисков - предусловие, а то у жителей будут ожоги.
        { 
            get { return temperature; }
            set
            {
                if (value <= 0) { throw new Exception("Недопустимое зачение. Значение должно быть положительным"); }
                else temperature = value;
            }
        }
        public void DecreaseTemp(int celsius)
        {
            Celisius -= celsius;
            //можно добавить вывод текста для интерфейса пользователя
            // return string.Format("Температура снижена на {0} градусов. Текущая температура устройства - {1}", celsius, temperature)
        }
        public void IncreaseTemp(int celsius)
        {
            Celisius += celsius;
            //можно добавить вывод текста для интерфейса пользователя
            // return string.Format("Температура повышена на {0} градусов. Текущая температура устройства - {1}", celsius, temperature)
        }
    }
}
