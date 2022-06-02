using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCourse
{
    class Lesson4 : ILesson
    {
        string ILesson.Name => "4";

        string ILesson.Description => "Урок 4. Деревья, хэш-таблицы";

        void ILesson.Start()
        {
            Console.Clear();

            Console.WriteLine("Урок 4. Деревья, хэш-таблицы");

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
            public void Remove(int value)
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
