using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class MyDLL
    {
        public static List<Student> students = new List<Student>();
        public static DateTime[] dateTimes;
        public static double[] mark = new double[4] { 2, 3, 4, 5 };
        public static double[] count = new double[4];

        public class Student
        {
            public string FIO;
            public int group;
            public DateTime dateTime;

            public List<Marks> marks = new List<Marks>();

            public class Marks
            {
                public DateTime Date;
                public string Mark;
            }
            //Генерация отметок на 10 дней подряд
            public static void MarkRandom(string FIO)
            {
                List<Marks> marks = new List<Marks>();
                Random random = new Random();
                string[] MassMark = new string[5] { "2", "3", "4", "5", "Н" };
                for (int i = 0; i < 10; i++)
                {
                    int rndMarks = random.Next(5);
                    Marks Mark = new Marks();
                    Mark.Mark = MassMark[rndMarks];
                    Mark.Date = DateTime.Now.AddDays(i + 1);
                    marks.Add(Mark);
                }
                Student student = new Student();
                student.FIO = FIO;
                student.marks = marks;
                students.Add(student);
            }
        }
        public static int MathProgul(string student)
        {
            int count = 0;
            foreach (var item in MyDLL.students)
            {
                foreach (var item1 in item.marks)
                {
                    if (item1.Mark == "Н")
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static double MinAvg(string[] marks)
        {
            int[] massMark;
            massMark = marks.Where(p => int.TryParse(p.ToString(), out int result)).Select(p => int.Parse(p.ToString())).ToArray();
            double AVG = Math.Floor(massMark.Average());
            return AVG;
        }
    }
}
