using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MySmartHouse
{
    class Menu
    {
        List<HomeDevice> deviceList = new List<HomeDevice>();
        public void Show()
        {
            deviceList.Add(new Videocamera("Видеокамера \"Samsung L-1\"", false));
            deviceList.Add(new Alarm("Сигнализация \"Aligator\"", false));
            deviceList.Add(new Microwave("Микроволновка \"LG-700\"", false));
            deviceList.Add(new ElectricOven("Электропечь \"Calor CLR-2\"", false));
            deviceList.Add(new Kettle("Электрочайник \"Bosh Tea\"", false));
            deviceList.Add(new Lamp("Система освещения \"Light_H\"", false));
            deviceList.Add(new TV("Телевизор \"Toshiba-2T\"", false));
            deviceList.Add(new Conditioner("Кондиционер \"Mitsubishi K-4", false));
            deviceList.Add(new Boiler("Котёл \"Warm-R-2016\"      ", false));
            while (true)
            {
                Console.Clear();
                foreach (HomeDevice device in deviceList)
                {
                    device.Info();
                }
                Console.WriteLine("\nПрограмма-эмулятор \"SmartHouse\"\n");
                byte listNumber = 1;
                Console.WriteLine();
                foreach (var device in deviceList)
                {
                    Console.WriteLine(listNumber++ + " - Управление устройством " + device.Name);
                }
                Console.WriteLine("0 - Выход\n");
                
                Console.Write("Введите номер: ");
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number == 0)
                    {
                        return;
                    }
                    Managment(deviceList[number - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный номер");
                    Console.ReadLine();
                }
            }
        }
        public void Managment (HomeDevice device)
        {
            Console.Clear();
            while(true)
            {
                device.Info();
                Console.WriteLine("\nКоманды для управления устройством " + device.Name + ":\n");
                if (device is HomeDevice)
                {
                    Console.WriteLine("on - включить устройство {0}", device.Name);
                    Console.WriteLine("off - выключить устройство {0}", device.Name);
                }
                if (device is ISecure)
                {
                    Console.WriteLine("act - активировать охранные устройства");
                    Console.WriteLine("deact - деактивировать охранные устройства");
                }
                if (device is ITime)
                {
                    Console.WriteLine("st - установить таймер для {0}", device.Name);
                }
                if (device is ITemperature)
                {
                    Console.WriteLine("+c - увеличить до .. градусов");
                    Console.WriteLine("-c - убавить до .. градусов");
                }
                if (device is ICook)
                {
                    Console.WriteLine("sm - установить режим для духовки");
                }
                if (device is ILight)
                {
                    Console.WriteLine("sb - установить уровень яркости");
                }
                if (device is ILamps)
                {
                    Console.WriteLine("slbed - установить режим для спальни");
                    Console.WriteLine("slyard - установить режим на внутреннем дворе");
                    Console.WriteLine("slbath - установить режим для ванны");
                    Console.WriteLine("slkitchen - установить режим для кухни");
                    Console.WriteLine("slcellar - установить режим для погреба");
                }
                if (device is ISound)
                {
                    Console.WriteLine("sv - установить уровень громкости");
                }
                if (device is ITv)
                {
                    Console.WriteLine("ch - выбрать канал");
                    Console.WriteLine("pre - предыдущий канал");
                    Console.WriteLine("next - следующий канал");
                }
                Console.WriteLine("\nq - вернуться назад");
                    Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "on":
                        if (device is HomeDevice)
                        { device.PowerOn(true); }
                        break;
                    case "off":
                        if (device is HomeDevice)
                        { device.PowerOn(false);
                          device.State = false; }
                        break;
                    case "act":
                        if (device is ISecure) 
                        {
                        ((ISecure)device).Active();
                        }
                        break;
                    case "deact":
                        if (device is ISecure)
                        {
                        ((ISecure)device).Deactive();
                        }
                            break;
                    case "st":
                        if (device is ITime)
                        {
                            Console.WriteLine("Введите кол-во минут для таймера");
                            int min = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (device is ITime) { ((ITime)device).SetTimer(min);
                                device.State = true; }
                        }
                        break;
                    case "sm":
                        if (device is ICook)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - курица \n2 - выпечка \n3 - pizza");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ICook)device).SetMode(OvenMode.RoastChicken);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ICook)device).SetMode(OvenMode.BakeCakes);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ICook)device).SetMode(OvenMode.Pizza);
                                device.State = true;
                            }
                            else { Console.WriteLine("ввели неверный номер"); }
                            }
                        break;
                    case "+c":
                        if (device is ITemperature)
                        {
                            Console.WriteLine("Введите нужную температру");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (device is ITemperature)
                            {
                                ((ITemperature)device).IncreaseTemp(c);
                                device.State = true;
                            }
                        }
                        break;
                    case "-c":
                        if (device is ITemperature)
                        {
                            Console.WriteLine("Введите нужную температру");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (device is ITemperature)
                            {
                                ((ITemperature)device).DecreaseTemp(c);
                                device.State = true;
                            }
                        }
                        break;
                    case "sb":
                        if (device is ILight)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILight)device).SetBright(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILight)device).SetBright(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILight)device).SetBright(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILight)device).SetBright(BrightMode.Off);
                                device.State = false;
                            }
                            else { Console.WriteLine("ввели неверный номер"); }
                        }
                        break;
                        case "slbed":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILamps)device).SetLampBedroom(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILamps)device).SetLampBedroom(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILamps)device).SetLampBedroom(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILamps)device).SetLampBedroom(BrightMode.Off);
                                device.State = false;
                            }
                            else {
                            Console.WriteLine("ввели неверный номер"); }
                        }
                        break;
                    case "slyard":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILamps)device).SetLampCourtYard(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILamps)device).SetLampCourtYard(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILamps)device).SetLampCourtYard(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILamps)device).SetLampCourtYard(BrightMode.Off);
                                device.State = false;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slbath":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILamps)device).SetLampBathroom(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILamps)device).SetLampBathroom(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILamps)device).SetLampBathroom(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILamps)device).SetLampBathroom(BrightMode.Off);
                                device.State = false;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slkitchen":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILamps)device).SetLampKitchen(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILamps)device).SetLampKitchen(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILamps)device).SetLampKitchen(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILamps)device).SetLampKitchen(BrightMode.Off);
                                device.State = false;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slcellar":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ILamps)device).SetLampCellar(BrightMode.Bright100);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILamps)device).SetLampCellar(BrightMode.Bright75);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILamps)device).SetLampCellar(BrightMode.Bright50);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILamps)device).SetLampCellar(BrightMode.Off);
                                device.State = false;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "sv":
                        if (device is ISound)
                        {
                            Console.WriteLine("Введите нужную громкость");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (device is ISound)
                            {
                                ((ISound)device).SetVolume(c);
                                device.State = true;
                            }
                            else { Console.WriteLine("неверный формат"); }
                        }
                        break;
                    case "ch":
                        if (device is ITv)
                        {
                            Console.WriteLine("Выберите канал:\n \n1 - Интер \n2 - ICTV \n3 - Discovery_Channel \n4 - Animal_Planet");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ITv)device).SetChannel(Channels.Inter);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ITv)device).SetChannel(Channels.ICTV);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ITv)device).SetChannel(Channels.Discovery_Channel);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ITv)device).SetChannel(Channels.Animal_Planet);
                                device.State = true;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "next":
                        if (device is ITv)
                        {
                         ((ITv)device).NextChannel();
                        }
                        break;
                    case "pre":
                        if (device is ITv)
                        {
                            ((ITv)device).PreChannel();
                        }
                        break;
                    case "q":
                        return;
                }
            }
        }
    }
}

