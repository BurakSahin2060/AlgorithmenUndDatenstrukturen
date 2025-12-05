using System;

namespace CommonDLL
{
    public interface ISortStrategy<T> where T : IComparable<T>
    {
        void Sort(ISortableCollection<T> c);
    }
}