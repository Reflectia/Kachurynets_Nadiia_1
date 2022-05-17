using System;

namespace Electronics
{
    class PersonalComp
    {
        public bool turn = false;
        public virtual void Turn()
        {
            Console.WriteLine("Якщо хочете ввімкнути комп'ютер, введіть +, якщо ні, будь-який інший символ");
            char turn = Char.Parse(Console.ReadLine());
            if (turn == '+')
            {
                Console.WriteLine("Комп'ютер ввімкнено");
                this.turn = true;
            }
            else
            {
                Console.WriteLine("Комп'ютер вимкнено");
                this.turn = false;
            }
        }       
    }
    class SysBlock : PersonalComp
    {
        public override string ToString()
        {
            return Convert.ToString(turn);
        }
    }
    class Monitor : PersonalComp
    {
        bool monitor = false;
        public override void Turn()
        {
            Console.WriteLine("Якщо хочете під'єднати монітор, введіть +, якщо ні, будь-який інший символ");
            char turn = Char.Parse(Console.ReadLine());
            if (turn == '+')
            {
                Console.WriteLine("Монітор під'єднано");
                monitor = true;
            }
            else
            {
                Console.WriteLine("Монітор від'єднано");
                monitor = false;
            }
        }
        public override string ToString()
        {
            return Convert.ToString(monitor);
        }
    }
    class Mouse : PersonalComp
    {
        bool mouse = false;
        public override void Turn()
        {
            Console.WriteLine("Якщо хочете під'єднати мишку, введіть +, якщо ні, будь-який інший символ");
            char turn = Char.Parse(Console.ReadLine());
            if (turn == '+')
            {
                Console.WriteLine("Мишку під'єднано");
                mouse = true;
            }
            else
            {
                Console.WriteLine("Мишку від'єднано");
                mouse = false;
            }
        }
        public override string ToString()
        {
            return Convert.ToString(mouse);
        }
    }
    class KeyBoard : PersonalComp
    {
        bool keyboard = false;
        public override void Turn()
        {
            Console.WriteLine("Якщо хочете під'єднати клавіатуру, введіть +, якщо ні, будь-який інший символ");
            char turn = Char.Parse(Console.ReadLine());
            if (turn == '+')
            {
                Console.WriteLine("Клавіатуру під'єднано");
                keyboard = true;
            }
            else
            {
                Console.WriteLine("Клавіатуру від'єднано");
                keyboard = false;
            }
        }
        public override string ToString()
        {
            return Convert.ToString(keyboard);
        }
    }
}
