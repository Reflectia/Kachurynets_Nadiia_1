using System;

namespace Electronics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var sysblock = new SysBlock();
                var monitor = new Monitor();
                var mouse = new Mouse();
                var keyboard = new KeyBoard();
                Console.WriteLine("Ви маєте при собі персональний комп'ютер.\n" +
                    "Якщо хочете виконати якусь з перелічених дій, введіть відповідну цифру\n" +
                    "1.Ввімкнути/вимкнути комп'ютер\n" +
                    "2.Підключити монітор\n3.Підключити мишку\n4.Підключити клавіатуру");
                int choice = 1;
                Console.WriteLine("Якщо захочете зупинитись, введіть \"0\" в будь-який момент");
                while (choice != 0)
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Завершення програми");
                            return;
                        case 1:
                            sysblock.Turn();
                            Console.WriteLine(sysblock.ToString());
                            break;
                        case 2:
                            monitor.Turn();
                            Console.WriteLine(monitor.ToString());
                            break;
                        case 3:
                            mouse.Turn();
                            Console.WriteLine(mouse.ToString());
                            break;
                        case 4:
                            keyboard.Turn();
                            Console.WriteLine(keyboard.ToString());
                            break;
                        default:
                            Console.WriteLine("Немає такого варіанту дії");
                            return;
                    }
                    Console.WriteLine("Введіть 0 або цифру від 1 до 4");
                } 
            } catch (Exception e)
            {
                Console.WriteLine($"You have caught the exception {e}");
            }            
        }
    }
}
