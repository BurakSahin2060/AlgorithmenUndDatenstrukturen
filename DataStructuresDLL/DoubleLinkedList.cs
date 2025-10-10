using CommonDLL;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }
    public Node(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class DoubleLinkedList<T>
{
    private Node<T> head;

    public DoubleLinkedList()
    {
        head = null;
    }

    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        if (head == null)
        {
            head = newNode;
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
            head = newNode;
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
            current.Next = newNode;
        }
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
}