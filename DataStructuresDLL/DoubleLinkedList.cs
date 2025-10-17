using CommonDLL;
using System;

public class DoubleLinkedList<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public DoubleLinkedList()
    {
        head = null;
        tail = null;
    }

    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        if (head == null)
        {
            head = tail = newNode;
            return;
        }
        if (head.Data.Equals(elementAfter))
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            return;
        }
        Node<T> current = head;
        while (current != null && !current.Data.Equals(elementAfter))
        {
            current = current.Next;
        }
        if (current != null)
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            if (current.Previous != null)
            {
                current.Previous.Next = newNode;
            }
            current.Previous = newNode;
        }
    }

    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        if (head == null)
        {
            head = tail = newNode;
            return;
        }
        Node<T> current = head;
        while (current != null && !current.Data.Equals(elementBefore))
        {
            current = current.Next;
        }
        if (current != null)
        {
            newNode.Next = current.Next;
            newNode.Previous = current;
            if (current.Next != null)
            {
                current.Next.Previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            current.Next = newNode;
        }
    }

    public void InsertLast(T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        if (head == null)
        {
            head = tail = newNode;
            return;
        }
        tail.Next = newNode;
        newNode.Previous = tail;
        tail = newNode;
    }

    public int PosOfElement(T element)
    {
        Node<T> current = head;
        int position = 0;
        while (current != null)
        {
            if (current.Data.Equals(element))
            {
                return position;
            }
            current = current.Next;
            position++;
        }
        return -1;
    }

    public void BubbleSort()
    {
        if (head == null || head.Next == null)
            return;

        bool swapped;
        do
        {
            swapped = false;
            Node<T> current = head;
            while (current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }
}