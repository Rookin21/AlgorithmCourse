using System;
using System.Collections.Generic;
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
            Console.Write("Введите номер урока для демонстрации домашнего задания: ");

            int numLesson = Convert.ToInt32(Console.ReadLine());

            switch(numLesson)
            {
                case 1:
                    Lesson1 lesson1 = new Lesson1();
                    lesson1.Start();
                    break;
                case 2:
                    Lesson2 lesson2 = new Lesson2();
                    lesson2.Start();
                    break;
            }
        }
    }

    public class Lesson1
    {
        /// <summary>
        /// Реализация домашнего задания Урок 1 по курсу Алгоритмы и структуры данных
        /// </summary>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Уроку 1. Блок-схемы, асимптотическая сложность, рекурсия");
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
            {
                Lesson1 lesson1 = new Lesson1();
                lesson1.Start();
            }
        }
    }

    public class Lesson2
    {
        public void Start()
        {
            ILinkedList link = new LinkedList();

            int num1 = 1234;
            int num2 = 4321;
            int num3 = 1423;
            int num4 = 5555;

            // Добавление элементов
            link.AddNode(num1);
            link.AddNode(num2);
            link.AddNode(num3);
            link.AddNode(num4);

            Console.Clear();

            Console.WriteLine("Уроку 2. Массив, список, поиск");

            // Добавление нескольких элементов
            Console.WriteLine("\nДобавлены следующие элементы:" +
                              $"\n1. {num1}" +
                              $"\n2. {num2}" +
                              $"\n3. {num3}" +
                              $"\n3. {num4}");

            Console.WriteLine($"\nВ данном решении существует {link.GetCount()} элемента"); // Вызов счетчика

            Console.WriteLine("\nПосле нажатия любой клавиши произойдет удаление последнего элемента");

            Console.ReadKey(true);
            Console.Clear();

            link.RemoveLast(); // Удаление последнего элемента

            Console.WriteLine("Удаление произошло успешно");

            link.RemoveNode(1); // Удаление элемента по первому индексу 

            Console.WriteLine("\nУдален элемент по первому индексу");

            Console.Write($"Количество элементов: {link.GetCount()}"); // Вызов счетчика

            Console.WriteLine($"\n{link.FindNode(1423)}"); // Поиск элемента

            Console.ReadKey(true);
        }

        public class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        // Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value); // добавляет новый элемент списка
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
            void RemoveFirst(); // удаляет первый элемент
            void RemoveLast(); // удаляет последний элемент
        }

        public class LinkedList : ILinkedList
        {
            Node head; // первый элемент
            Node tail; // последний элемент
            int count; // количество элементов в списке

            // Определение количества элементов в списке
            public int GetCount ()
            {
                return count;
            }

            // Добавление элемента в конец списка
            public void AddNode(int value)
            {
                Node node = new Node(value);

                if (count == 0) // Проверка, является ли список пустым
                {
                    head = node; // Указываем на новый узел
                }
                else
                {
                    tail.NextNode = node; // Узел добавляется в конец списка
                    node.PrevNode = tail;
                }

                tail = node; // Указываем на новый узел

                count++;
            }

            // удаляет указанный элемент
            public void Remove(Node node)
            {
                Node previous = null;
                Node current = head;

                while (current != null)
                {
                    if (current.Value.Equals(node))
                    {
                        // Узел в середине или в конце
                        if (previous != null) // если предыдущий пустой, то удаляем первый
                        {
                            previous.NextNode = current.NextNode; // убираем указатель между удаляющим элементом

                            if (current.NextNode == null) // Если узел в конце, то меняем tail
                            {
                                tail = previous;
                            }
                            else
                            {
                                current.NextNode.PrevNode = previous; // указатель со след элемента на предыдущий перед удаляемый
                            }
                            count--;
                        }
                        else
                        {
                            RemoveFirst();
                        }
                    }
                    previous = current;
                    current = current.NextNode;
                }
            }

            // удаляет элемент по порядковому номеру
            public void RemoveNode(int index)
            {
                if (index > count || index < 0)
                {
                    throw new InvalidOperationException();
                }

                if (index == 1)
                {
                    RemoveFirst();
                }
                else if (index == (count - 1))
                {
                    RemoveLast();
                }
                else
                {
                    Node current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.NextNode;
                    }

                    current.NextNode = current.NextNode.NextNode;
                    count--;
                }
            }

            //Удаляет первый узел
            public void RemoveFirst()
            {
                if (count != 0)
                {
                    head = head.NextNode;
                    count--;

                    if (count == 0)
                    {
                        tail = null;
                    }
                    else
                    {
                        head.PrevNode = null;
                    }
                }
            }

            // Удаляет последний узел
            public void RemoveLast()
            {
                if (count != 0)
                {
                    if (count == 1)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        tail.PrevNode = null;
                        tail = tail.PrevNode;
                    }
                    count--;
                }
            }

            // поиск элемента с определённым значением
            public Node FindNode(int searchValue)
            {
                var current = head;

                while (current != null)
                {
                    if (current.Value == searchValue)
                        return current;

                    current = current.NextNode;
                }
                return null;
            }

            public void RemoveNode(Node node)
            {
                throw new NotImplementedException();
            }
        }
    }
}
