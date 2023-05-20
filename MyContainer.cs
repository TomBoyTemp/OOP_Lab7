using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal class MyContainer<T>
    {
        private const int defaultCapacity = 4;

        private T[] arr;

        private int size;

        private static readonly T[] emptyArr = new T[0];

        private int Capacity
        {
            get
            {
                return arr.Length;
            }
            set
            {
                if (value < size)
                {
                    return;
                }

                if (value == arr.Length)
                {
                    return;
                }

                if (value > 0)
                {
                    T[] tmp_arr = new T[value];

                    if (size > 0)
                    {
                        Array.Copy(arr, tmp_arr, size);
                    }

                    arr = tmp_arr;
                }
                else
                {
                    arr = emptyArr;
                }
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= size)
                {
                    return default(T);
                }

                return arr[index];
            }
            set
            {
                if (index >= size)
                {
                    return;
                }

                arr[index] = value;
            }
        }

        public MyContainer()
        {
            arr = emptyArr;
            size = 0;
        }

        public MyContainer(uint capacity)
        {
            arr = new T[capacity];
            size = 0;
        }

        public void add(T value)
        {
            if (size == arr.Length)
            {
                increaseBuf();
            }
            arr[size++] = value;
        }
        public int find(T obj)
        {
            for (int i = 0; i < size; ++i)
            {
                if (arr[i].Equals(obj))
                {
                    return i;
                }
            }
            return -1;
        }
        public T remove(int index)
        {
            if (index >= size)
            {
                return default(T);
            }
            size--;
            T tmp = arr[index];
            for (int i = index; i < size; i++)
            {
                arr[i] = arr[i + 1];
            }
            if (size == arr.Length / 2)
            {
                decreaseBuf();
            }
            return tmp;
        }
        public void clear()
        {
            arr = emptyArr;
            size = 0;
        }
        private void increaseBuf()
        {
            Capacity = ((arr.Length == 0) ? defaultCapacity : (arr.Length * 2));
        }
        private void decreaseBuf()
        {
            Capacity = size * 3 / 2;
        }
    }
}
