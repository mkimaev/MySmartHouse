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

            deviceList.Add(new Videocamera("Видеокамера \"Samsung L-1\"", true));
            deviceList.Add(new Alarm("Сигнализация \"Aligator\"", false));
            deviceList.Add(new Microwave("Микроволновка \"LG-700\"", false));
            deviceList.Add(new ElectricOven("Электропечь \"Calor CLR-2\"", false));
            deviceList.Add(new Kettle("Электрочайник \"Bosh Tea\"", false));
            deviceList.Add(new Lamp("Система освещения \"Light_H\"", false));
            deviceList.Add(new TV("Телевизор \"Toshiba-2T\"", false));
            deviceList.Add(new Conditioner("Кондиционер \"Mitsubishi K-4", false));
            deviceList.Add(new Boiler("Котёл \"Warm-R-2016\"      ", false));
            deviceList.Add(new GrillDevice("Электрогриль \"ЧупаКабра-2017\" ", false));

            while (true)
            {
                Console.Clear();
                foreach (HomeDevice device1 in deviceList)
                {
                    if (device1.isDeviceTurnOn == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Устр-во: {0} \tПитание: ВКЛ. ", device1.Name);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("Устр-во: {0} \tПитание: ВЫКЛ. ", device1.Name);
                        Console.ResetColor();
                    }

                    if (device1.isFunctionalActive == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("\tФункционал: активирован \n\n");
                        Console.ResetColor();
                    }
                    else
                    {
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
                catch (Exception ex)
                {
                    Console.WriteLine("Неверный номер");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
        public void Managment(HomeDevice device)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nКоманды для управления устройством " + device.Name + ":\n");
                if (device is HomeDevice)
                {
                    Console.WriteLine("on - включить устройство {0}", device.Name);
                    Console.WriteLine("off - выключить устройство {0}", device.Name);
                }
                if (device.SafeOpportunity is Safer)
                {
                    Console.WriteLine("act - активировать охранные устройства");
                    Console.WriteLine("deact - деактивировать охранные устройства");
                }
                if (device is Videocamera)
                {
                    Console.WriteLine("rec - начать запись на видеокамеру");
                    Console.WriteLine("recoff - остановить запись");
                }
                if (device.TimeOpportunity is Timer)
                {
                    Console.WriteLine("st - установить таймер для {0}", device.Name);
                }
                if (device.TemperatureOpportunity is Temperaturer)
                {
                    Console.WriteLine("+c - увеличить на .. градусов");
                    Console.WriteLine("-c - убавить на .. градусов");
                }
                if (device.CookOpportunity is Cooker)
                {
                    Console.WriteLine("sm - установить режим приготовления");
                }
                if (device.BrightOpportunity is Brightner)
                {
                    Console.WriteLine("sb - установить уровень яркости");
                }
                if (device is ILamps)
                {
                    Console.WriteLine("choose - выбрать комнату");
                }
                if (device.SoundOpportunity is Sounder)
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
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(device.TurnOn(true));
                            Console.ResetColor();
                        }
                        break;
                    case "off":
                        if (device is HomeDevice)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(device.TurnOn(false));
                            device.isFunctionalActive = false;
                            Console.ResetColor();
                        }
                        break;
                    case "act":
                        if (device.SafeOpportunity is Safer)
                        {
                            ((Safer)device.SafeOpportunity).Active();
                            device.isFunctionalActive = true;
                        }
                        break;
                    case "deact":
                        if (device.SafeOpportunity is Safer)
                        {
                            ((Safer)device.SafeOpportunity).Deactive();
                            device.isFunctionalActive = false;
                        }
                        break;
                    case "rec":
                        if (device is Videocamera)
                        {
                            ((Videocamera)device).RecordOn(true);
                            Console.WriteLine("Запись включена");
                            device.isFunctionalActive = true;
                        }
                        break;
                    case "recoff":
                        if (device is Videocamera)
                        {
                            ((Videocamera)device).RecordOn(false);
                            Console.WriteLine("Запись выключена");
                            device.isFunctionalActive = false;
                        }
                        break;
                    case "st":
                        if (device.TimeOpportunity is Timer)
                        {
                            Console.WriteLine("Введите кол-во минут для таймера");
                            int min = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            ((Timer)device.TimeOpportunity).SetTimer(min);
                            device.isFunctionalActive = true;
                            Console.WriteLine("Таймер установлен на {0} минут", min);
                        }
                        break;
                    case "sm":
                        if (device.TemperatureOpportunity is Temperaturer)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - курица \n2 - выпечка \n3 - pizza");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            {
                                ((Cooker)device.CookOpportunity).SetMode(OvenMode.RoastChicken);
                                Console.WriteLine("Установлен режим запекания птицы");
                                device.isFunctionalActive = true;
                            }
                            else if (num == 2)
                            {
                                ((Cooker)device.CookOpportunity).SetMode(OvenMode.BakeCakes);
                                Console.WriteLine("Установлен режим выпечки");
                                device.isFunctionalActive = true;
                            }
                            else if (num == 3)
                            {
                                ((Cooker)device.CookOpportunity).SetMode(OvenMode.Pizza);
                                Console.WriteLine("Установлен режим приготовления пиццы");
                                device.isFunctionalActive = true;
                            }
                            else
                            {
                                Console.WriteLine("ввели несуществующий номер");
                            }
                        }
                        break;
                    case "+c":
                        if (device.TemperatureOpportunity is Temperaturer)
                        {
                            Console.WriteLine("Текущая температура устройства {0} = {1} градусов", device.Name, ((Temperaturer)device.TemperatureOpportunity).Celisius);
                            Console.WriteLine("Введите нужную температру");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            ((Temperaturer)device.TemperatureOpportunity).IncreaseTemp(c);
                            Console.WriteLine("Температура увеличена до {0} градусов", c);
                            device.isFunctionalActive = true;
                        }
                        break;
                    case "-c":
                        if (device.TemperatureOpportunity is Temperaturer)
                        {
                            Console.WriteLine("Текущая температура устройства {0} = {1} градусов", device.Name, ((Temperaturer)device.TemperatureOpportunity).Celisius);
                            Console.WriteLine("Введите нужную температру");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            ((Temperaturer)device.TemperatureOpportunity).DecreaseTemp(c);
                            Console.WriteLine("Температура уменьшена до {0} градусов", c);
                            device.isFunctionalActive = true;
                        }
                        break;
                    case "sb":
                        if (device.BrightOpportunity is Brightner)
                        {
                            Console.WriteLine("Выберите режим:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            {
                                ((Brightner)device.BrightOpportunity).SetBright(BrightMode.Bright100);
                                Console.WriteLine("Яркость ({0})", ((Brightner)device.BrightOpportunity).Bright);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 2)
                            {
                                ((Brightner)device.BrightOpportunity).SetBright(BrightMode.Bright75);
                                Console.WriteLine("Яркость ({0})", ((Brightner)device.BrightOpportunity).Bright);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 3)
                            {
                                ((Brightner)device.BrightOpportunity).SetBright(BrightMode.Bright50);
                                Console.WriteLine("Яркость ({0})", ((Brightner)device.BrightOpportunity).Bright);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 4)
                            {
                                ((Brightner)device.BrightOpportunity).SetBright(BrightMode.Off);
                                Console.WriteLine("Яркость ({0})", ((Brightner)device.BrightOpportunity).Bright);
                                device.isFunctionalActive = false;
                            }
                            else
                            {
                                Console.WriteLine("ввели несуществующий номер");
                            }
                        }
                        break;
                    case "choose":
                        if (device is ILamps)
                        {
                            Console.WriteLine("Введите № комнаты: \n1 - Bathroom\n2 - CourtYard\n3 - Bedroom\n4 - Kitchen\n5 - Cellar");
                            int chooseNum = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (chooseNum == 1)
                            {
                                Console.WriteLine("Введите режим для ванны:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int bathroomNum = Int32.Parse(Console.ReadLine());
                                if (bathroomNum == 1) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright100); }
                                else if (bathroomNum == 2) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright75); }
                                else if (bathroomNum == 3) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Bright50); }
                                else if (bathroomNum == 4) { ((ILamps)device).SetLampRoom(Rooms.Bathroom, BrightMode.Off); }
                                Console.WriteLine("\nРежим для ванны установен");
                            }
                            if (chooseNum == 2)
                            {
                                Console.WriteLine("Введите режим для внутр.двора:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int courtYardnum = Int32.Parse(Console.ReadLine());
                                if (courtYardnum == 1) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright100); }
                                else if (courtYardnum == 2) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright75); }
                                else if (courtYardnum == 3) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Bright50); }
                                else if (courtYardnum == 4) { ((ILamps)device).SetLampRoom(Rooms.CourtYard, BrightMode.Off); }
                                Console.WriteLine("\nРежим для внутр.двора установен");
                            }
                            if (chooseNum == 3)
                            {
                                Console.WriteLine("Введите режим для спальни:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int bedroomNum = Int32.Parse(Console.ReadLine());
                                if (bedroomNum == 1) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright100); }
                                else if (bedroomNum == 2) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright75); }
                                else if (bedroomNum == 3) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Bright50); }
                                else if (bedroomNum == 4) { ((ILamps)device).SetLampRoom(Rooms.Bedroom, BrightMode.Off); }
                                Console.WriteLine("\nРежим для спальни установен");
                            }
                            if (chooseNum == 4)
                            {
                                Console.WriteLine("Введите режим для кухни:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int kitchenNum = Int32.Parse(Console.ReadLine());
                                if (kitchenNum == 1) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright100); }
                                else if (kitchenNum == 2) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright75); }
                                else if (kitchenNum == 3) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Bright50); }
                                else if (kitchenNum == 4) { ((ILamps)device).SetLampRoom(Rooms.Kitchen, BrightMode.Off); }
                                Console.WriteLine("\nРежим для кухни установен");
                            }
                            if (chooseNum == 5)
                            {
                                Console.WriteLine("Введите режим для погреба:\n \n1 - яркость 100% \n2 - яркость 75% \n3 - яркость 50% \n4 - выкл");
                                int cellarNum = Int32.Parse(Console.ReadLine());
                                if (cellarNum == 1) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright100); }
                                else if (cellarNum == 2) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright75); }
                                else if (cellarNum == 3) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Bright50); }
                                else if (cellarNum == 4) { ((ILamps)device).SetLampRoom(Rooms.Cellar, BrightMode.Off); }
                                Console.WriteLine("\nРежим для погреба установен");
                            }
                            else
                            {
                                Console.WriteLine("ввели несуществующий номер");
                            }
                            Thread.Sleep(1500);
                            //Console.Clear();
                        }
                        break;
                    case "sv":
                        if (device.SoundOpportunity is Sounder)
                        {
                            Console.WriteLine("Введите нужную громкость");
                            int c = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            ((Sounder)device.SoundOpportunity).SetVolume(c);
                            Console.WriteLine("Громкость ({0})", c);
                            device.isFunctionalActive = true;
                        }
                        break;
                    case "ch":
                        if (device is ITv)
                        {
                            Console.WriteLine("Выберите канал:\n \n1 - Интер \n2 - ICTV \n3 - Discovery_Channel \n4 - Animal_Planet");
                            int num = Int32.Parse(Console.ReadLine());
                            Console.Clear();
                            if (num == 1)
                            {
                                ((ITv)device).SetChannel(Channels.Inter);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 2)
                            {
                                ((ITv)device).SetChannel(Channels.ICTV);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 3)
                            {
                                ((ITv)device).SetChannel(Channels.Discovery_Channel);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.isFunctionalActive = true;
                            }
                            else if (num == 4)
                            {
                                ((ITv)device).SetChannel(Channels.Animal_Planet);
                                Console.WriteLine("Транслируется ТВ канал: {0}", ((ITv)device).Chanel);
                                device.isFunctionalActive = true;
                            }
                            else
                            {
                                Console.WriteLine("ввели несуществующий номер");
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

