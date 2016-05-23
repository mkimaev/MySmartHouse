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
                foreach (HomeDevice device1 in deviceList)
                {           
                    if (device1.Power == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Устр-во: {0} \tПитание: ВКЛ. ", device1.Name);
                        Console.ResetColor();
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("Устр-во: {0} \tПитание: ВЫКЛ. ", device1.Name);
                        Console.ResetColor(); }

                        if (device1.State == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("\tФункционал: активирован \n\n");
                            Console.ResetColor();
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\tФункционал: деактивирован \n");
                            Console.ResetColor();
                        }
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
                    Console.WriteLine("choose - выбрать комнату");
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
                        { device.PowerOn(true);
                            Console.WriteLine("Включено\n");
                        }
                        break;
                    case "off":
                        if (device is HomeDevice)
                        { device.PowerOn(false);
                          device.State = false;
                          Console.WriteLine("Выключено\n");
                        }
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
                                device.State = true;
                                Console.WriteLine("Таймер установлен на {0} минут", ((ITime)device).Time);
                            }
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
                                Console.WriteLine("Установлен режим запекания птицы");
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ICook)device).SetMode(OvenMode.BakeCakes);
                                Console.WriteLine("Установлен режим выпечки");
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ICook)device).SetMode(OvenMode.Pizza);
                                Console.WriteLine("Установлен режим приготовления пиццы");
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
                                Console.WriteLine("Температура увеличена до {0} градусов", ((ITemperature)device).Celcius);
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
                                Console.WriteLine("Температура уменьшена до {0} градусов", ((ITemperature)device).Celcius);
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
                                Console.WriteLine("Яркость ({0})", ((ILight)device).Bright);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ILight)device).SetBright(BrightMode.Bright75);
                                Console.WriteLine("Яркость ({0})", ((ILight)device).Bright);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ILight)device).SetBright(BrightMode.Bright50);
                                Console.WriteLine("Яркость ({0})", ((ILight)device).Bright);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ILight)device).SetBright(BrightMode.Off);
                                Console.WriteLine("Яркость ({0})", ((ILight)device).Bright);
                                device.State = false;
                            }
                            else { Console.WriteLine("ввели неверный номер"); }
                        }
                        break;
                        case "choose":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Введите № комнаты: \n1 - Bathroom\n2 - CourtYard\n3 - Bedroom\n4 - Kitchen\n5 - Cellar");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            {
                            Console.WriteLine("Введите режим для ванны:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num1 = Int32.Parse(Console.ReadLine());
                                if (num == 1) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright100); }
                                else if (num == 2) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright75); }
                                else if (num == 3) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright50); }
                                else if (num == 4) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Off); }
                                Console.WriteLine("\nРежим для ванны установен");
                            }
                            if (num == 2)
                            {
                                Console.WriteLine("Введите режим для внутр.двора:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int num1 = Int32.Parse(Console.ReadLine());
                                if (num == 1) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright100); }
                                else if (num == 2) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright75); }
                                else if (num == 3) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright50); }
                                else if (num == 4) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Off); }
                                Console.WriteLine("\nРежим для внутр.двора установен");
                            }
                            if (num == 3)
                            {
                                Console.WriteLine("Введите режим для спальни:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int num1 = Int32.Parse(Console.ReadLine());
                                if (num == 1) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright100); }
                                else if (num == 2) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright75); }
                                else if (num == 3) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright50); }
                                else if (num == 4) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Off); }
                                Console.WriteLine("\nРежим для спальни установен");
                            }
                            if (num == 4)
                            {
                                Console.WriteLine("Введите режим для кухни:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int num1 = Int32.Parse(Console.ReadLine());
                                if (num == 1) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright100); }
                                else if (num == 2) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright75); }
                                else if (num == 3) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright50); }
                                else if (num == 4) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Off); }
                                Console.WriteLine("\nРежим для кухни установен");
                            }
                            if (num == 5)
                            {
                                Console.WriteLine("Введите режим для погреба:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int num1 = Int32.Parse(Console.ReadLine());
                                if (num == 1) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright100); }
                                else if (num == 2) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright75); }
                                else if (num == 3) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright50); }
                                else if (num == 4) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Off); }
                                Console.WriteLine("\nРежим для погреба установен");
                            }
                            Thread.Sleep(1500);
                            Console.Clear();
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
                                Console.WriteLine("Громкость ({0})", ((ISound)device).Volume);
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
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.State = true;
                            }
                            else if (num == 2)
                            { ((ITv)device).SetChannel(Channels.ICTV);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.State = true;
                            }
                            else if (num == 3)
                            { ((ITv)device).SetChannel(Channels.Discovery_Channel);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.State = true;
                            }
                            else if (num == 4)
                            { ((ITv)device).SetChannel(Channels.Animal_Planet);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
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
                          Console.WriteLine("Вкючён следующий канал");
                        }
                        break;
                    case "pre":
                        if (device is ITv)
                        {
                            ((ITv)device).PreChannel();
                            Console.WriteLine("Вкючён предыдущий канал");
                        }
                        break;
                    case "q":
                        return;
                }
            }
        }
    }
}

