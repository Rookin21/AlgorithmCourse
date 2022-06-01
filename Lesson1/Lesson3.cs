using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCourse
{
    class Lesson3 : ILesson
    {
        string ILesson.Name => "3";

        string ILesson.Description => "Урок 3. Класс, структура и дистанция";

        Random rnd = new Random(); // Вызов класса генератора случайных чисел произведен
                                   // тут для того, чтобы числа при каждом вызове были разные.

        /// <summary>
        /// Реализация домашнего задания Урок 3. Класс, структура и дистанция
        /// </summary>
        void ILesson.Start()
        {           
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            // Внесение в массив 4 случайных чисел для реализации класса
            double[] arrClass = { GetRandom(), GetRandom(), GetRandom(), GetRandom() };
            // Внесение в массив 4 случайных чисел для реализации структуры
            double[] arrStruct = { GetRandom(), GetRandom(), GetRandom(), GetRandom() };

            // Присвоение значений для класса
            var pointOne = new PointClassDouble(arrClass[0], arrClass[1]);
            var pointTwo = new PointClassDouble(arrClass[2], arrClass[3]);
            // Присвоение значений для структуры
            var pointone = new PointStructDouble(arrStruct[0], arrStruct[1]);
            var pointtwo = new PointStructDouble(arrStruct[2], arrStruct[3]);

            Console.Clear();

            Console.WriteLine("Урок 3. Класс, структура и дистанция");
            Console.WriteLine("При каждом новом запуске X и Y генерируются случайным образом");

            // Расчет дистанции путем реализации класса
            double resultClass = DistanceClass(pointOne, pointTwo);
            sw1.Stop();
            // Расчет дистанции путем реализации структуры
            double resultStruct = DistanceStruct(pointone, pointtwo);
            sw2.Stop();

            Console.WriteLine($"\nРассточние между парой точек путем реализации класса: {resultClass}");
            Console.WriteLine($"Время расчета: {sw1.Elapsed}");
            Console.WriteLine($"\nРассточние между парой точек путем реализации структуры: {resultStruct}");
            Console.WriteLine($"Время расчета: {sw2.Elapsed}");

            Console.ReadKey();            
        }

        /// <summary>
        /// Генерация случайного числа
        /// </summary>
        /// <returns>Случайное число в диапазоне от 1 до 999</returns>
        public double GetRandom()
        {
            return rnd.Next(1, 999);
        }

        /// <summary>
        /// Объявление параметров в классе
        /// </summary>
        public class PointClassDouble
        {
            public double X;
            public double Y;
            public PointClassDouble(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// Метод возвращающий расстояние между парой точек. Реализованный в классе
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        static double DistanceClass(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.X - pointTwo.X;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Объявление параметров в структуре
        /// </summary>
        public struct PointStructDouble
        {
            public double X;
            public double Y;
            public PointStructDouble(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// Метод возвращающий расстояние между парой точек. Реализованный в структуре
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        static double DistanceStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}
