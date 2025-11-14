using CommonDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        private void SwapNodes(Node<T> node1, Node<T> node2)
        {
            if (node1 == null || node2 == null)
                return;

            T temp = node1.Data;
            node1.Data = node2.Data;
            node2.Data = temp;
        }

        public void Sort(Node<T> head)
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
                        SwapNodes(current, current.Next);
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}
