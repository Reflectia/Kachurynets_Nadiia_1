using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics2
{
    class Device
    {
        public string name;
        public int power;
        string country;
        char energyef;
        public Device(string name, int power, string country, char energyef)
        {
            this.name = name;
            this.power = power;
            this.country = country;
            this.energyef = energyef;
        }
        static void Print(IOrderedEnumerable<Device> newdevices)
        {
            Console.WriteLine("\nНазва: потужність, країна виробник, енергоефективність");
            int i = 0;
            foreach (Device device in newdevices)
            {
                i++;
                Console.WriteLine($"{i}. {device.name}: {device.power}, {device.country}, {device.energyef}");
            }
        }
        public static void SelfPrint(List<Device> devices)
        {
            var newdevices = from d in devices
                             orderby d.name
                             select d;
            Console.WriteLine("Список електроприладів за умовчанням:");
            Print(newdevices);
        }
        public static void PowerPrint(List<Device> devices)
        {
            var newdevices = from d in devices
                      orderby d.power descending
                      select d;
            Console.WriteLine("Список електроприладів за спаданням потужності:");
            Print(newdevices);
        }        
        public static void EffectPrint(List<Device> devices)
        {
            var newdevices = from d in devices
                             orderby d.energyef
                             select d;
            Console.WriteLine("Список електроприладів за енергоефективністю:");
            Print(newdevices);
        }
        public static int InputPower(List<int> turnon, List<Device> devices, TimeSpan span)
        {
            int InPow = 0;
            foreach (Device d in devices)
            {
                if (turnon.Contains(d.power))
                {
                    InPow += (int)(d.power * (float)span.TotalSeconds);
                }
            }
            return InPow;
        }
        public static void SelectDev(List<Device> devices)
        {
            Console.WriteLine("Введіть за якими параметрами шукаємо прилади: потужність(1), країна виробник(2), енергоефективність(3)" +
                "\nколи закінчите введіть 0");
            List<int> opt = new List<int>();
            int nextopt = int.Parse(Console.ReadLine());
            while (nextopt != 0)
            {
                switch (nextopt)
                {
                    case 1:
                        opt.Add(nextopt);
                        break;
                    case 2:
                        opt.Add(nextopt);
                        break;
                    case 3:
                        opt.Add(nextopt);
                        break;
                    default:
                        Console.WriteLine("Нема такої опції");
                        break;
                }                     
                nextopt = int.Parse(Console.ReadLine());                
            }
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            if (opt.Contains(1))
            {
                Console.WriteLine("Введіть проміжок потужності");
                int pow1 = int.Parse(Console.ReadLine());
                int pow2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Прилади зі списку що підійшли:");
                foreach (Device d in devices)
                {
                    if (pow1 <= d.power && d.power <= pow2)
                    {
                        Console.WriteLine(d.name);
                        list1.Add(d.name);
                    }
                }
            }
            if (opt.Contains(2))
            {
                Console.WriteLine("Введіть країну виробника");
                string cntr = Console.ReadLine();
                Console.WriteLine("Прилади зі списку що підійшли:");
                foreach (Device d in devices)
                {
                    if (cntr == d.country)
                    {
                        Console.WriteLine(d.name);
                        list2.Add(d.name);
                    }
                }
            }
            if (opt.Contains(3))
            {
                Console.WriteLine("Введіть рівень енергоефективності");
                char effec = char.Parse(Console.ReadLine());
                Console.WriteLine("Прилади зі списку що підійшли:");
                foreach (Device d in devices)
                {
                    if (effec == d.energyef)
                    {
                        Console.WriteLine(d.name);
                        list3.Add(d.name);
                    }
                }
            }
            if (list1.Count > 0 || list2.Count > 0 || list3.Count > 0)
            {
                List<string> newlist = new List<string>();
                foreach(string l1 in list1)
                {
                    foreach(string l2 in list2)
                    {
                        if (l1 == l2)
                        {
                            newlist.Add(l1);
                        }
                    }
                }
                list1.Clear();
                foreach (string lnew in newlist)
                {
                    foreach (string l3 in list3)
                    {
                        if (lnew == l3)
                        {
                            list1.Add(l3);
                        }
                    }
                }
                if (list1.Count == 0)
                {
                    Console.WriteLine("Приладів які задовільняють всі параметри нема");
                }
                else
                {
                    Console.WriteLine("Прилади які задовільняють всі параметри:");
                    foreach (string l in list1)
                    {
                        Console.WriteLine(l);
                    }
                }
            }
        }
    }
}
