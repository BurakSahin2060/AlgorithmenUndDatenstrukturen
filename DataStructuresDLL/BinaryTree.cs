using CommonDLL;
using SortingAlgorithms;
using System;
using System.Collections.Generic;

public class BinaryTree<T> : ISortableCollection<T> where T : IComparable<T>
{
    private Node<T> root;
    private ISortStrategy<T> sortAlgorithm;

    public BinaryTree()
    {
        root = null;
        sortAlgorithm = SortStrategyFactory.CreateDefault<T>(); //  Factory Pattern
    }

    public void Insert(T data)
    {
        root = InsertRec(root, data);
    }

    private Node<T> InsertRec(Node<T> node, T data)
    {
        if (node == null)
        {
            node = new Node<T>(data);
            return node;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            node.Previous = InsertRec(node.Previous, data);
        }
        else if (data.CompareTo(node.Data) > 0)
        {
            node.Next = InsertRec(node.Next, data);
        }

        return node;
    }

    public void Sort()
    {
        sortAlgorithm.Sort(this);
    }

    public int Count()
    {
        return CountRec(root);
    }

    private int CountRec(Node<T> node)
    {
        if (node == null) return 0;
        return 1 + CountRec(node.Previous) + CountRec(node.Next);
    }

    public T Get(int index) // Element an Position holen
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        List<T> inOrderList = new List<T>();
        InOrderRec(root, inOrderList);
        if (index >= inOrderList.Count) throw new ArgumentOutOfRangeException(nameof(index));
        return inOrderList[index];
    }

    public void Swap(int index1, int index2)
    {
        if (index1 == index2) return;
        List<Node<T>> inOrderNodes = new List<Node<T>>();
        InOrderNodesRec(root, inOrderNodes);
        if (index1 < 0 || index1 >= inOrderNodes.Count || index2 < 0 || index2 >= inOrderNodes.Count)
            throw new ArgumentOutOfRangeException();

        T temp = inOrderNodes[index1].Data;
        inOrderNodes[index1].Data = inOrderNodes[index2].Data;
        inOrderNodes[index2].Data = temp;
    }

    private void InOrderRec(Node<T> node, List<T> list) // Sammeln der Werte
    {
        if (node == null) return;
        InOrderRec(node.Previous, list);
        list.Add(node.Data);
        InOrderRec(node.Next, list);
    }

    private void InOrderNodesRec(Node<T> node, List<Node<T>> list) // Sammeln der Knoten
    {
        if (node == null) return;
        InOrderNodesRec(node.Previous, list);
        list.Add(node);
        InOrderNodesRec(node.Next, list);
    }
}