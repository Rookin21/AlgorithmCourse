using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
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
        public int GetCount { get { return count; } }

        // Добавление элемента в конец списка
        public void AddNode (int value)
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
            if (index > count || index < 0 )
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
        public Node FindNode (int searchValue)
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

        int ILinkedList.GetCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(Node node)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main()
        {
            // Создадим связный список
            LinkedList<string> link = new LinkedList<string>();

            // Добавим несколько элементов
            link.AddFirst("example1");
            link.AddFirst("example2");
            link.AddLast("example3");

        }     
    }
}
