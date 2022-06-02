using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgorithmCourse
{
    class AlgorithmCourse
    {      
        static void Main()
        {
            Console.WriteLine("В данной программе реализованы ДЗ по курсе Алгоритмы и структуры данных");

            List<ILesson> tasks = new List<ILesson>()
            {
                new Lesson1(),
                new Lesson2(),
                new Lesson3(),
                new Lesson4(),
                new Lesson5()
            };

            foreach (ILesson lesson in tasks)
                Console.WriteLine($"\nВведите {lesson.Name} для демонстрации домашнего задания {lesson.Description}");

            string numLesson = Console.ReadLine();

            foreach (ILesson lesson in tasks)
                if (lesson.Name == numLesson)
                    lesson.Start();
        }
    }
}
