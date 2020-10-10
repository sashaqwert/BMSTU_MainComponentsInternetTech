using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleListProject
{
    public class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        public SimpleStack () { }
        
        public void push(T t)
        {
            Add(t);
        }

        public T pop()
        {
            T res = last.data;
            SimpleListItem<T> newLast = first;
            for (int i = 0; i < Count - 2; i++) {
                newLast = newLast.next;
            }
            last = newLast;
            newLast.next = null;
            Count--;
            return res;
        }
    }
}
