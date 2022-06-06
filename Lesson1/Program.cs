using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Reflection;
using ILesson;
using Lesson1;
using Lesson2;
using Lesson3;
using Lesson4;
using Lesson5;


namespace AlgorithmCourse
{
    class AlgorithmCourse
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("LogFile.log").CreateLogger();
            Log.Information("Запущено приложение по курсу Алгоритмы и структуры данных");

            Console.WriteLine("В данной программе реализованы ДЗ по курсе Алгоритмы и структуры данных");

            List<ILess> tasks = new List<ILess>()
            {
                new Less1(),
                new Less2(),
                new Less3(),
                new Less4(),
                new Less5()
            };

            foreach (ILess lesson in tasks)
                Console.WriteLine($"\nВведите {lesson.Name} для демонстрации домашнего задания {lesson.Description}");

            string numLesson = Console.ReadLine();

            foreach (ILess lesson in tasks)
                if (lesson.Name == numLesson)
                    lesson.Start();
        }
    }
}
