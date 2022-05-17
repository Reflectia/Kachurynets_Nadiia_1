using System;

namespace Students
{
    interface IPerson
    {
        string Name { get; set; }

    }
    abstract class Student : IPerson
    {
        string name;
        int course;
        int GPA;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Course
        {
            get { return course; }
            set 
            {
                if (value < 1)
                    course = 1;
                else if (value > 0 && value < 7)
                    course = value;
                else
                    course = 6;
            }
        }
        public int _GPA
        {
            get { return GPA; }
            set 
            {
                if (GPA < 0)
                    GPA = 0;
                else if (GPA > 0 && GPA < 101)
                    GPA = value;
                else
                    GPA = 100;
            }
        }
        public Student(int course, int GPA)
        {
            Course = course;
            _GPA = GPA;
        }
        public void CheckScholar()
        {
            if (GetType().Name == "StudentBudg" && GPA > 70)
                Console.WriteLine($"{name} отримує стипендію");
            else
                Console.WriteLine($"{name} не отримує стипендію");
        }
        public virtual void TuitionFee()
        {
            int bachelor = 31000;
            int master = 45000;
            Console.Write($"У студента(-ки) {name} вартість навчання складає : ");
            if (course > 0 && course < 5)
                Console.WriteLine(bachelor);
            else
                Console.WriteLine(master);
        }
        public void LessonAmount()
        {
            int amount = 0;
            switch (course)
            {
                case 1:
                    amount = 16;
                    break;
                case 2:
                    amount = 17;
                    break;
                case 3:
                    amount = 16;
                    break;
                case 4:
                    amount = 15;
                    break;
                case 5:
                    amount = 13;
                    break;
                case 6:
                    amount = 12;
                    break;
            }
            Console.WriteLine($"Студент(-ка) {name} має у тиждень {amount} пар");
        }
        public static void StartSession()
        {
            DateTime session = new DateTime(2022, 6, 6);
            Console.WriteLine($"Дата початку сесії - {session.ToShortDateString()}"); 
        }
    }
    class StudentBudg : Student
    {
        public StudentBudg(int course, int GPA) : base(course, GPA) { }
    }
    class StudentContr : Student
    {
        public StudentContr(int course, int GPA) : base(course, GPA) { }

    }
    class StudentDist : Student
    {
        public StudentDist(int course, int GPA) : base(course, GPA) { }
        public override void TuitionFee()
        {
            int bachelor = 25000;
            int master = 38000;
            Console.Write($"У студента(-ки) {Name} вартість навчання складає : ");
            if (Course > 0 && Course < 5)
                Console.WriteLine(bachelor);
            else
                Console.WriteLine(master);
        }
    }
}
