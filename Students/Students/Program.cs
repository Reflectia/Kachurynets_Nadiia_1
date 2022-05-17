using System;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Student[] choice = {new StudentBudg(0, 0), new StudentContr(0, 0), new StudentDist(0, 0)};
                Console.WriteLine("Оберіть форму навчання студента(-ки): бюджетник(1), контрактник(2), заочник(3)");
                int opt = int.Parse(Console.ReadLine());
                Student student = choice[opt-1];
                Console.WriteLine("Тепер введіть ім'я студента(-ки)");
                student.Name = Console.ReadLine();
                Console.WriteLine("Введіть курс навчання студента(1-6)");
                student.Course = int.Parse(Console.ReadLine());
                Console.WriteLine("І останнє, середній бал студента за попередній семестр(0-100)");
                student._GPA = int.Parse(Console.ReadLine());
                student.CheckScholar();
                if (student.GetType().Name == "StudentContr" || student.GetType().Name == "StudentDist")
                {
                    student.TuitionFee();
                }
                if (student.GetType().Name == "StudentBudg" || student.GetType().Name == "StudentContr")
                {
                    student.LessonAmount();
                }
                Student.StartSession();
            }
            catch (Exception e)
            {
                Console.WriteLine("You have caught the exception " + e);
            }
        }
    }
}
