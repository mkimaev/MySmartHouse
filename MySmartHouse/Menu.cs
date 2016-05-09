using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmartHouse
{
    class Menu
    {
        private HomeDevice[] deviceList;
        public void Show()
        {
            deviceList = new HomeDevice[9];
            deviceList[0] = new Videocamera("Видеокамера \"Samsung L-1\"", false);
            deviceList[1] = new Alarm("Сигнализация \"Aligator\"", false);
            deviceList[2] = new Microwave("Микроволновка \"LG-700\"", false);
            deviceList[3] = new ElectricOven("Электропечь \"Calor CLR-2\"", false);
            deviceList[4] = new Kettle("Электрочайник \"Bosh Tea\"", false);
            deviceList[5] = new Lamp("Система освещения \"Light_H\"", false);
            deviceList[6] = new TV("Телевизор \"Toshiba-2T\"", false);
            deviceList[7] = new Conditioner("Кондиционер \"Mitsubishi K-4", false);
            deviceList[8] = new Boiler("Котёл \"Тёплышко всегда\"", false);

            while (true)
            {
                Console.Clear();
                byte listNumber = 1;
                for (int i = 0; i < deviceList.Length; i++)
                { deviceList[i].Info(); }
                Console.WriteLine();
                Console.WriteLine("Программа-эмулятор \"SmartHouse\"\n");
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
                if (device is Videocamera)
                {
                    Console.WriteLine("act - активировать съёмку");
                    Console.WriteLine("deact - деактивировать съёмку");
                }
                if (device is Alarm)
                {
                    Console.WriteLine("act - активировать сенсоры");
                    Console.WriteLine("deact - деактивировать сенсоры");
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
                if (device is ElectricOven)
                {
                    Console.WriteLine("sm - установить режим для духовки");
                }
                if (device is ILight)
                {
                    Console.WriteLine("sb - установить уровень яркости");
                }
                if (device is Lamp)
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
                if (device is TV)
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
                        { device.PowerOn(true);}
                        break;
                    case "off":
                        if (device is HomeDevice)
                        { device.PowerOn(false);
                          device.State = false; }
                        break;
                    case "act":
                        if (device is ISecure) 
                        {
                            if (device is ISecure)
                            {
                            ((ISecure)device).Active();
                            }
                        }
                        break;
                    case "deact":
                        if (device is ISecure)
                        {
                            if (device is ISecure)
                            {
                                ((ISecure)device).Deactive();
                            }
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
                        if (device is ElectricOven)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - курица \n2 - выпечка \n3 - pizza");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((ElectricOven)device).SetMode(OvenMode.RoastChicken); }
                            else if (num == 2)
                            { ((ElectricOven)device).SetMode(OvenMode.BakeCakes); }
                            else if (num == 3)
                            { ((ElectricOven)device).SetMode(OvenMode.Pizza); }
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
                            { ((ILight)device).SetBright(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((ILight)device).SetBright(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((ILight)device).SetBright(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((ILight)device).SetBright(BrightMode.Off); }
                            else { Console.WriteLine("ввели неверный номер"); }
                            if (((ILight)device).Bright != BrightMode.Off)
                            {
                                device.State = true;
                            }
                            else
                            {
                                device.State = false;
                            }
                        }
                        break;
                        case "slbed":
                        if (device is Lamp)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((Lamp)device).SetLampBedroom(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((Lamp)device).SetLampBedroom(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((Lamp)device).SetLampBedroom(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((Lamp)device).SetLampBedroom(BrightMode.Off); }
                            else {
                            Console.WriteLine("ввели неверный номер"); }
                        }
                        break;
                    case "slyard":
                        if (device is Lamp)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((Lamp)device).SetLampCourtYard(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((Lamp)device).SetLampCourtYard(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((Lamp)device).SetLampCourtYard(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((Lamp)device).SetLampCourtYard(BrightMode.Off); }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slbath":
                        if (device is Lamp)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((Lamp)device).SetLampBathroom(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((Lamp)device).SetLampBathroom(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((Lamp)device).SetLampBathroom(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((Lamp)device).SetLampBathroom(BrightMode.Off); }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slkitchen":
                        if (device is Lamp)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((Lamp)device).SetLampKitchen(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((Lamp)device).SetLampKitchen(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((Lamp)device).SetLampKitchen(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((Lamp)device).SetLampKitchen(BrightMode.Off); }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "slcellar":
                        if (device is Lamp)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((Lamp)device).SetLampCellar(BrightMode.Bright100); }
                            else if (num == 2)
                            { ((Lamp)device).SetLampCellar(BrightMode.Bright75); }
                            else if (num == 3)
                            { ((Lamp)device).SetLampCellar(BrightMode.Bright50); }
                            else if (num == 4)
                            { ((Lamp)device).SetLampCellar(BrightMode.Off); }
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
                        if (device is TV)
                        {
                            Console.WriteLine("Выберите канал:\n \n1 - Интер \n2 - ICTV \n3 - Discovery_Channel \n4 - Animal_Planet");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            { ((TV)device).SetChannel(Channels.Inter);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((TV)device).SetChannel(Channels.ICTV);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((TV)device).SetChannel(Channels.Discovery_Channel);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((TV)device).SetChannel(Channels.Animal_Planet);
                                device.State = true;
                            }
                            else {
                                Console.WriteLine("ввели неверный номер");
                            }
                        }
                        break;
                    case "next":
                        if (device is TV)
                        {
                         ((TV)device).NextChannel();
                        }
                        break;
                    case "pre":
                        if (device is TV)
                        {
                            ((TV)device).PreChannel();
                        }
                        break;
                    case "q":
                        return;

                }

            }
        }

    }
}

