using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCourse
{
    class Lesson5 : ILesson
    {
        string ILesson.Name => "5";

        string ILesson.Description => "Урок 5. Стек, очередь, словарь и коллекции в C#";

        void ILesson.Start()
        {
            Console.Clear();

            Console.WriteLine("Урок 5. Стек, очередь, словарь и коллекции в C#");

            BinaryTree binaryTree = new BinaryTree();

            int[] arr = { 6, 2, 3, 11, 30, 9, 13, 18, 50, 87, 65, 42 };

            // Добавление элементов в дерево
            for (int i = 0; i < arr.Length; i++)
            {
                binaryTree.Add(arr[i]);
            }

            // Отрисовка дерева
            binaryTree.Print();

            // Удаление элементов
            binaryTree.Remove(87);
            binaryTree.Remove(9);

            // Отрисовка дерева после удаления
            binaryTree.Print();

            // Поиск элемента
            Node node = binaryTree.Find(arr[8]);
            Console.WriteLine($"\nНайден элемент: {node.Data}");

            // Поиск в ширину
            Console.WriteLine("\nПоиск в ширину");
            binaryTree.BreadthFirstSearch();

            // Поиск в глубину
            Console.WriteLine("\nПоиск в глубину");
            binaryTree.DeepFirstSearch();

            Console.ReadKey(true);
        }

        /// <summary>
        /// Перечисление нахождения элемента
        /// </summary>
        public enum NodePosition
        {
            left,
            right,
            center
        }

        public class Node
        {
            public int Data;
            public Node Right;
            public Node Left;
            public Node Parent;

            public Node(int data)
            {
                this.Data = data;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="data">Выводимое значение</param>
            /// <param name="nodePostion">Позиция элемента</param>
            public void PrintValue(string data, NodePosition nodePostion)
            {
                // В зависимости от позиции вызываем метод
                switch (nodePostion)
                {
                    case NodePosition.left:
                        PrintLeftValue(data);
                        break;
                    case NodePosition.right:
                        PrintRightValue(data);
                        break;
                    case NodePosition.center:
                        Console.WriteLine(data);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Размещение элемента слева
            /// </summary>
            /// <param name="data">Отображаемый элемент</param>
            public void PrintLeftValue(string data)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("L:");
                Console.ForegroundColor = (data == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(data);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            /// <summary>
            /// Размещение элемента справа
            /// </summary>
            /// <param name="data">Отображаемый элемент</param>
            public void PrintRightValue(string data)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("R:");
                Console.ForegroundColor = (data == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(data);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            /// <summary>
            /// Алгоритм отрисовки дерева
            /// </summary>
            /// <param name="indent">Отступ</param>
            /// <param name="nodePosition">Позиция элемента</param>
            /// <param name="last">Последний элемент</param>
            /// <param name="empty">Пустота</param>
            public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
            {

                Console.Write(indent);
                if (last) // Если последний элемент
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "| ";
                }

                // В случае отсутствия элемента
                var stringValue = empty ? "-" : Data.ToString();
                PrintValue(stringValue, nodePosition);

                // Если есть значение, то выбор позиции для размещения элемента
                if (!empty && (this.Left != null || this.Right != null))
                {
                    if (this.Left != null)
                        this.Left.PrintPretty(indent, NodePosition.left, false, false);
                    else
                        PrintPretty(indent, NodePosition.left, false, true);

                    if (this.Right != null)
                        this.Right.PrintPretty(indent, NodePosition.right, true, false);
                    else
                        PrintPretty(indent, NodePosition.right, true, true);
                }
            }

        }

        public class BinaryTree
        {
            private Node root;
            private int count;
            private IComparer<int> _comparer = Comparer<int>.Default;

            public BinaryTree()
            {
                root = null;
                count = 0;
            }

            /// <summary>
            /// Поиск в ширину
            /// </summary>
            public void BreadthFirstSearch()
            {
                // При поиске в ширину используется очередь
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root); // Добавление в очередь
                while (q.Count > 0)
                {
                    Node n = q.Dequeue(); // Изъятие из очереди
                    Console.WriteLine(n.Data);
                    if (n.Left != null)
                        q.Enqueue(n.Left);
                    if (n.Right != null)
                        q.Enqueue(n.Right);
                }
            }
            /// <summary>
            /// Поиск в глубину
            /// </summary>
            public void DeepFirstSearch()
            {
                // При поиске в глубину используется стек
                Stack<Node> s = new Stack<Node>();
                s.Push(root); // Добавление в стек
                while (s.Count > 0)
                {
                    Node n = s.Pop(); // Изъятие из стека
                    Console.WriteLine(n.Data);
                    if (n.Left != null)
                        s.Push(n.Left);
                    if (n.Right != null)
                        s.Push(n.Right);
                }
            }

            /// <summary>
            /// Поиск элементов
            /// </summary>
            /// <param name="data">Искомое значение</param>
            /// <returns></returns>
            public Node Find(int data)
            {
                return this.Find(data, this.root);
            }

            /// <summary>
            /// Удаление элемента
            /// </summary>
            /// <param name="data">Удаляемое значение</param>
            public void Remove(int data)
            {
                this.root = Remove(this.root, data);
            }

            /// <summary>
            /// Удаление элемента
            /// </summary>
            /// <param name="parent">Родитель</param>
            /// <param name="key"></param>
            /// <returns></returns>
            public Node Remove(Node parent, int key)
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
            public int MinValue(Node node)
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
            /// <param name="data">Искомое значение</param>
            /// <param name="parent">Родитель</param>
            /// <returns></returns>
            public Node Find(int data, Node parent)
            {
                if (parent != null)
                {
                    if (data == parent.Data) return parent;
                    if (data < parent.Data)
                        return Find(data, parent.Left);
                    else
                        return Find(data, parent.Right);
                }

                return null;
            }

            /// <summary>
            /// Добавление самого первого элемента
            /// </summary>
            /// <param name="data">Добавляемое значение</param>
            /// <returns></returns>
            public bool Add(int data)
            {
                // Если самый первый элемент
                if (root == null)
                {
                    root = new Node(data);
                    count++;
                    return true;
                }
                else
                {
                    return Add_Sub(root, data);
                }
            }

            /// <summary>
            /// Добавление элемента после первого
            /// </summary>
            /// <param name="node">Узел</param>
            /// <param name="data">Добавляемое значение</param>
            /// <returns></returns>
            private bool Add_Sub(Node node, int data)
            {
                if (_comparer.Compare(node.Data, data) < 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node(data);
                        count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(node.Right, data);
                    }
                }
                else if (_comparer.Compare(node.Data, data) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(data);
                        count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(node.Left, data);
                    }
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Отображение дерева
            /// </summary>
            public void Print()
            {
                root.PrintPretty("", NodePosition.center, true, false);
            }
        }
    }
}
