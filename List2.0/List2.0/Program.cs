using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace List2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                //список
                List<string> Wings = new List<string>()
                {
                    "А й правда, крилатим ґрунту не треба.",
                    "Землі немає, то буде небо.",
                    "Немає поля, то буде воля.",
                    "Немає пари, то будуть хмари.",
                    "В цьому, напевно, правда пташина…",
                    "А як же людина? А що ж людина?",
                    "Живе на землі. Сама не літає.",
                    "А крила має. А крила має!",
                    "Вони, ті крила, не з пуху-пір'я,",
                    "А з правди, чесноти і довір'я.",
                    "У кого – з вірності у коханні.",
                    "У кого – з вічного поривання.",
                    "У кого – з щирості до роботи.",
                    "У кого – з щедрості на турботи.",
                    "У кого – з пісні, або з надії,",
                    "Або з поезії, або з мрії.",
                    "Людина нібито не літає…",
                    "А крила має. А крила має!"
                };
                List<string> Prayer = new List<string>()
                {
                    "коли повертається світ спиною",
                    "і знов поміж нами відстань і стіни",
                    "говори зі мною",
                    "говори зі мною",
                    "хай навіть слова ці нічого не змінять",
                    "і коли вже довкола пахне війною",
                    "і вже розгораються перші битви",
                    "говори зі мною",
                    "говори зі мною",
                    "бо словом також можна любити",
                    "я одне лиш знаю і одне засвоїв",
                    "і прошу тебе тихо незграбно несміло:",
                    "говори зі мною",
                    "говори зі мною",
                    "і нехай твоє слово станеться тілом"
                };
                List<string> Input = new List<string>();
                Console.WriteLine("Яке завдання? (1/2/3)");
                int task = Int32.Parse(Console.ReadLine());
                switch (task)
                {
                    case 1:
                        Console.WriteLine("Вірші беремо зі списку чи вводимо вручну?\n(1/2/3 - 1, 2 вірші за замовчуванням; 3 - вводимо самі)");
                        byte choice = Byte.Parse(Console.ReadLine());
                        List<string> Result = new List<string>();
                        switch (choice)
                        {
                            case 1:
                                Result = Wings;
                                break;
                            case 2:
                                Result = Prayer;
                                break;
                            case 3:
                                Console.WriteLine("Скільки рядків буде у списку?");
                                int num = Int32.Parse(Console.ReadLine());
                                for (int i = 0; i < num; i++)
                                {
                                    Result.Add(Console.ReadLine());
                                }
                                break;
                            default:
                                Console.WriteLine("Не зрозуміло що робити в такій ситуації");
                                return;
                        }
                        //сортуємо по зростанню
                        Result.Sort(SortByLength);
                        Console.WriteLine("\nВивід відсортованого вірша:\n");
                        foreach (string row in Result)
                        {
                            Console.WriteLine(row);
                        }
                        break;
                    case 2:
                        //cловник
                        var characters = new Dictionary<int, string>();
                        Console.WriteLine("\nСкідьки елементів буде у словнику?");
                        int num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введіть ключі та значення елементів словника");
                        int key;
                        string value;
                        for (int i = 0; i < num2; i++)
                        {
                            key = Int32.Parse(Console.ReadLine());
                            value = Console.ReadLine();
                            characters.Add(key, value);
                        }
                        Console.WriteLine("Введіть значення для порівняння");
                        int comp = Int32.Parse(Console.ReadLine());
                        foreach (var character in characters)
                        {
                            if (character.Key >= comp)
                            {
                                Console.WriteLine($"Ключ: {character.Key}  Значення: {character.Value}");
                            }
                            else
                            {
                                characters.Remove(character.Key);
                            }
                        }
                        string fileName = "characters.json";
                        string jsonString = JsonSerializer.Serialize(characters);
                        File.WriteAllText(fileName, jsonString);
                        Console.WriteLine(File.ReadAllText(fileName));
                        break;
                    case 3:
                        // LINQ
                        List<string> Codes = new List<string>();
                        Console.WriteLine("Скільки рядків буде у списку?");
                        int num3 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введіть ці рядки:");
                        for (int i = 0; i < num3; i++)
                        {
                            Codes.Add(Console.ReadLine());
                        }
                        Console.WriteLine("Введіть довжину рядка");
                        int L = Int32.Parse(Console.ReadLine());
                        if (L < 1)
                        {
                            Console.WriteLine("Довжина не може бути менше 1");
                            return;
                        }
                        var SelectedCodes = from c in Codes
                                            where Regex.IsMatch(c, @"\d") && c.Length == L
                                            select c;
                        Console.WriteLine("\nОстанній рядок, що починається з цифри і має задану кількість елементів:");
                        if (SelectedCodes.Count() == 0)
                        {
                            Console.WriteLine("Not found");
                        } else
                        {
                            Console.WriteLine(SelectedCodes.Last());
                        }                      
                        break;
                    default:
                        Console.WriteLine("Нема такого завдання");
                        break;
                }                                              
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"You caught an exception {e}");
            }

        }

        public static int SortByLength(string x, string y)
        {
            int retval = x.Length.CompareTo(y.Length);
            return retval;
        }
    }
}

