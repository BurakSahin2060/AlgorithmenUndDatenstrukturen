using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL
{
    public interface ISortAlgorithm<T>
    {
        void Sort(Node<T> head);
    }
}
