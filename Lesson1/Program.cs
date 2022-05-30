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
            Console.Write("Введите номер урока для демонстрации домашнего задания: ");

            int numLesson = Convert.ToInt32(Console.ReadLine());

            switch(numLesson)
            {
                case 1: // Вызов решения Урок №1
                    Lesson1 lesson1 = new Lesson1();
                    lesson1.Start();
                    break;
                case 2: // Вызов решения Урок №2
                    Lesson2 lesson2 = new Lesson2();
                    lesson2.Start();
                    break;
                case 3: // Вызов решения Урок №3
                    Lesson3 lesson3 = new Lesson3();
                    lesson3.Start();
                    break;
                case 4: // Вызов решения Урок №4
                    Lesson4 lesson4 = new Lesson4();
                    lesson4.Start();
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

    public class Lesson3
    {
        Random rnd = new Random(); // Вызов класса генератора случайных чисел произведен
                                   // тут для того, чтобы числа при каждом вызове были разные.
        public void Start()
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

    public class Lesson4
    {
        public void Start()
        {
            Console.Clear();

            BinaryTree binaryTree = new BinaryTree();

            // Добавление элементов в дерево
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            // Поиск элемента
            Node<int> node = binaryTree.Find(5);

            Console.WriteLine($"Найден элемент: {node.Data}");

            Console.Write("Рекурсиный обход: ");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.Write("Прямой обход: ");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();

            Console.Write("Центрированный обход: ");
            binaryTree.TraversePostOrder(binaryTree.Root);
            Console.WriteLine();

            // Удаление элементов
            binaryTree.Remove(7);
            binaryTree.Remove(8);

            Console.Write("Рекурсивный обход после удаления элементов: ");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.ReadKey(true);
        }

        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Parent { get; set; }
        }

        /// <summary>
        /// Двоичное дерево поиска
        /// </summary>
        class BinaryTree
        {
            public Node<int> Root { get; set; }

            /// <summary>
            /// Добавление элемента в дерево
            /// </summary>
            /// <param name="value">Добавляемое значение</param>
            /// <returns></returns>
            public bool Add(int value)
            {
                Node<int> before = null, after = this.Root;

                while (after != null)
                {
                    before = after;
                    if (value < after.Data) // Если узел в левой ветви
                        after = after.Left;
                    else if (value > after.Data) // Если узел в правом ветви
                        after = after.Right;
                    else
                        return false; // Такое значение уже существует
                }

                Node<int> newNode = new Node<int>();

                newNode.Data = value;

                if (this.Root == null) // Если дерево пустое
                    this.Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.Left = newNode;
                    else
                        before.Right = newNode;
                }

                return true;
            }

            /// <summary>
            /// Поиск элементов
            /// </summary>
            /// <param name="value">Искомое значение</param>
            /// <returns></returns>
            public Node<int> Find(int value)
            {
                return this.Find(value, this.Root);
            }

            /// <summary>
            /// Удаление элемента
            /// </summary>
            /// <param name="value">Удаляемое значение</param>
            public void Remove (int value)
            {
                this.Root = Remove(this.Root, value);
            }

            /// <summary>
            /// Удаление элемента
            /// </summary>
            /// <param name="parent">Родитель</param>
            /// <param name="key"></param>
            /// <returns></returns>
            public Node<int> Remove(Node<int> parent, int key)
            {
                if (parent == null) return parent;

                if (key < parent.Data) parent.Left = Remove(parent.Left, key);
                else if (key > parent.Data)
                    parent.Right = Remove(parent.Right, key);
                else // Если значение совпадает с родителем, то он удаляется
                {  
                    if (parent.Left == null) // Если справа нет сына
                        return parent.Right;
                    else if (parent.Right == null) // Если слева нет сына
                        return parent.Left;
                     
                    parent.Data = MinValue(parent.Right); // Узел с двумя сыновьями: Получить преемника по порядку (наименьший в правом поддереве) 

                    parent.Right = Remove(parent.Right, parent.Data); // Удалить преемника по порядку
                }

                return parent;
            }

            /// <summary>
            /// Определение минимального значения
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public int MinValue(Node<int> node)
            {
                int minv = node.Data;

                while (node.Left != null)
                {
                    minv = node.Left.Data;
                    node = node.Left;
                }

                return minv;
            }

            /// <summary>
            /// Поиск элемента
            /// </summary>
            /// <param name="value">Искомое значение</param>
            /// <param name="parent">Родитель</param>
            /// <returns></returns>
            public Node<int> Find(int value, Node<int> parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;
                    if (value < parent.Data)
                        return Find(value, parent.Left);
                    else
                        return Find(value, parent.Right);
                }

                return null;
            }

            //public int GetTreeDepth()
            //{
            //    return this.GetTreeDepth(this.Root);
            //}

            //private int GetTreeDepth(Node<int> parent)
            //{
            //    return parent == null ? 0 : Math.Max(GetTreeDepth(parent.Left), GetTreeDepth(parent.Right)) + 1;
            //}

            /// <summary>
            /// Рекурсивный обход
            /// </summary>
            /// <param name="parent"></param>
            public void TraversePreOrder(Node<int> parent)
            {
                if (parent != null)
                {
                    Console.Write(parent.Data + " ");
                    TraversePreOrder(parent.Left);
                    TraversePreOrder(parent.Right);
                }
            }

            /// <summary>
            /// Прямой обход
            /// </summary>
            /// <param name="parent"></param>
            public void TraverseInOrder(Node<int> parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.Left);
                    Console.Write(parent.Data + " ");
                    TraverseInOrder(parent.Right);
                }
            }

            /// <summary>
            /// Центрированный обход
            /// </summary>
            /// <param name="parent"></param>
            public void TraversePostOrder(Node<int> parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.Left);
                    TraversePostOrder(parent.Right);
                    Console.Write(parent.Data + " ");
                }
            }
        }
     

    }


}
