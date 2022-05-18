using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        /// <summary>
        /// Реализация домашнего задания Урок 1 по курсу Алгоритмы и структуры данных
        /// </summary>
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("В данной программе реализованы ДЗ по Уроку 1. Курс Алгоритмы и структуры данных.");
            Console.WriteLine("Выберите номер задания. 1 или 3");

            int exercise = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (exercise)           // Выбор задания
            {
                case 1:
                    int[] value1 = { 12, 17, 53, 98 };

                    Console.WriteLine("Алгоритм проверки, простое число или нет");

                    for (int i = 0, j = 1; i < value1.Length; i++, j++)
                    {
                        string result1 = FindSimpleNumber(value1[i]);
                        Console.WriteLine($"\nРезультат {j}: {result1}");
                    }
                    break;
                case 3:
                    int[] value2 = { 10, 15, 20, 25 };

                    Console.WriteLine("Вычисление числа Фибоначчи");

                    for (int i = 0, j = 1; i < value2.Length; i++, j++)
                    {
                        int result2 = RecursionFibonachi(value2[i]);
                        Console.WriteLine($"\nРезультат №{j} числа {value2[i]} рекурсивным методом: {result2}");

                        int result3 = CycleFibonachi(value2[i]);
                        Console.WriteLine($"\nРезультат №{j} числа {value2[i]} c помощью цикла: {result3}");

                    }

                    break;
            }

            continueProgram();  // Возможность продолжения работы программы     
        }

        /// <summary>
        /// Определение простого числа
        /// </summary>
        /// <param name="value">Значение для вычисления</param>
        /// <returns></returns>
        static string FindSimpleNumber(int value)
        {
            int d = 0;
            int i = 2;

            while (i < value)
            {
                if (value % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            if (d == 0)
                return $"{value} простое число";
            else
                return $"{value } не простое число";
        }

        /// <summary>
        /// Вычисление числа Фибоначчи с помощью рекурсии
        /// </summary>
        /// <param name="value">Значение для вычисления</param>
        /// <returns></returns>
        static int RecursionFibonachi(int value)
        {
            if (value == 0 || value == 1) return value;

            return RecursionFibonachi(value - 1) + RecursionFibonachi(value - 2);
        }

        /// <summary>
        /// Вычисление числа Фибоначчи с помощью цикла
        /// </summary>
        /// <param name="value">Значение для вычисления</param>
        /// <returns></returns>
        static int CycleFibonachi(int value)
        {
            int num1 = 0;
            int num2 = 1;
            int result = 0;
            if (value == 1) result = num1;
            else if (value == 2) result = num2;
            for (int i = 1; i < value; i++)
            {
                result = num1 + num2;
                num1 = num2;
                num2 = result;
            }
            return result;
        }

        /// <summary>
        /// Выбор продолжения работы программы
        /// </summary>
        static void continueProgram()
        {
            Console.WriteLine("\nХотите продолжить?" +
                              "\nY- да" +
                              "\nДля завершения нажмите <Enter>");
            string usersChoice = Console.ReadLine();

            if (usersChoice == "y" || usersChoice == "Y")   // Повторно запускаем программу
                Main();
        }
    }
}
