using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Electronics2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            try
            {
                List<Device> devices = new List<Device>() {
                    new Device("laptop", 80, "Japan", 'A'),
                    new Device("fridge", 700, "Germany", 'C'),
                    new Device("kettle", 1500, "Germany", 'B'),
                    new Device("microwave", 1150, "Germany", 'A'),
                    new Device("stove", 3200, "France", 'D'),
                    new Device("washer", 2300, "Japan", 'B'),
                    new Device("vacuum", 1350, "Korea", 'C'),
                    new Device("TV", 210, "Korea", 'A'),
                    new Device("oven", 1600, "Korea", 'B'),
                    new Device("iron", 1200, "France", 'A'),
                    new Device("aircon", 2200, "Japan", 'A'),
                    new Device("hairdryer", 1300, "France", 'C')
                };
                Console.WriteLine("3 ієрархії електроприладів: за умовчанням, потужністю, енергоефективністю" +
                    "\nЯкий спосіб сортування обираєте? (1, 2, 3)");
                byte mode = byte.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:
                        Device.SelfPrint(devices);  
                        break;
                    case 2:
                        Device.PowerPrint(devices);
                        break;
                    case 3:
                        Device.EffectPrint(devices);
                        break;
                    default:
                        Console.WriteLine("Немає такого варіанту ієрархії");
                        break;
                }
                Console.WriteLine("Оберіть які прилади підключити до розетки (введіть потужності):\nколи закінчите введіть 0");
                List<int> turnon = new List<int>();
                int devP = int.Parse(Console.ReadLine());
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while (devP != 0)
                {
                    foreach (Device d in devices)
                    {
                        if (devP == d.power && turnon.Contains(devP) == false)
                        {
                            turnon.Add(devP);
                            Console.WriteLine($"Прилад {d.name} підключений до розетки");
                        }
                    }
                    devP = int.Parse(Console.ReadLine());
                }
                stopwatch.Stop();
                TimeSpan span = stopwatch.Elapsed;
                Console.WriteLine("Час, що пройшов від початку роботи - " + span.TotalSeconds);
                int InPow = Device.InputPower(turnon, devices, span);
                Console.WriteLine($"Споживана потужність ввімкнених приладів - {InPow} Вт*с");
                Device.SelectDev(devices);
                Console.ReadKey();
            } catch (Exception e)            
            {
                Console.WriteLine("You have caught the exception:" + e);
            }            
        }
    }
}
