using CommonDLL;
using SortingAlgorithms;
using System;

namespace DataStructureAndSortingTests
{
    public class Queue<T> : ISortableCollection<T> where T : IComparable<T>
    {
        private Node<T> front;
        private Node<T> rear;
        private ISortStrategy<T> sortAlgorithm;

        public Queue()
        {
            front = null;
            rear = null;
            sortAlgorithm = SortStrategyFactory.CreateDefault<T>(); //  Factory Pattern
        }

        public void Enqueue(T data) // Element hinzufügen
        {
            Node<T> newNode = new Node<T>(data);
            if (rear == null)
            {
                front = rear = newNode;
                return;
            }
            rear.Next = newNode;
            rear = newNode;
        }

        public T Dequeue() // Element entfernen
        {
            if (front == null) throw new InvalidOperationException("Queue is empty");
            T data = front.Data;
            front = front.Next;
            if (front == null)
                rear = null;
            return data;
        }

        public T Peek() // Erstes Element ansehen
        {
            if (front == null) throw new InvalidOperationException("Queue is empty");
            return front.Data;
        }

        public bool IsEmpty() // Ist die Queue leer?
        {
            return front == null;
        }

        public void Sort() // Queue sortieren
        {
            sortAlgorithm.Sort(this);
        }

        public int Count() // Anzahl der Elemente
        {
            int count = 0;
            Node<T> current = front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public T Get(int index) // Element an Index holen
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            Node<T> current = front;
            for (int i = 0; i < index; i++)
            {
                if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
                current = current.Next;
            }
            if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
            return current.Data;
        }

        public void Swap(int index1, int index2) // Zwei Elemente tauschen
        {
            if (index1 == index2) return;
            if (index1 > index2)
            {
                int tempIndex = index1;
                index1 = index2;
                index2 = tempIndex;
            }
            Node<T> node1 = front;
            for (int i = 0; i < index1; i++)
            {
                node1 = node1.Next;
            }
            Node<T> node2 = node1;
            for (int i = index1; i < index2; i++)
            {
                node2 = node2.Next;
            }
            if (node1 == null || node2 == null) throw new ArgumentOutOfRangeException();
            T temp = node1.Data;
            node1.Data = node2.Data;
            node2.Data = temp;
        }
    }
}