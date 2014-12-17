using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class Vector
    {
        public Vector()
        {
            array = new int[CAP_STEP];
            indices = new int[CAP_STEP];
            capacity = CAP_STEP;
            size = 0;
        }

        public bool insert(int val)
        {
            if (size >= capacity)
            {
                if (!increase()) // increase capacity
                    return false;
            }

            array[size] = val; // insert new element
            size = size + 1;

            return true;
        }

        public bool push_front(int val)
        {
            if (insert(val))
            {
                for (int i = size - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = val;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insert_sorted(int val)
        {
            if (insert(val))
            {
                sort(1); //insertion_sort(); O(N) instead of O(N^2)
                return true;
            }
            return false;
        }

        public void insertion_sort()
        {
            for (int i = 1; i < size; i++)
            {
                int k = array[indices[i]];
                int j = i - 1;
                while (j >= 0 && k <= array[indices[j]])
                {
                    indices[j + 1] = indices[j];
                    j = j - 1;
                }
                indices[j + 1] = i;
            }
        }

        public bool increase()
        {
            try
            {
                capacity = capacity + CAP_STEP;
                int[] tmp = new int[capacity];
                int[] tmp_indices = new int[capacity];
                // copy old array to new array
                for (int i = 0; i < size; i++)
                {
                    tmp[i] = array[i];
                    tmp_indices[i] = indices[i];
                }
                array = tmp;
                indices = tmp_indices;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool remove(int index)
        {
            if (size == 0 || index >= size)
                return false;
            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size = size - 1;
            return true;
        }

        public bool remove_by_value(int val)
        {
            int index = binary_search(val);
            if (index != -1)
                return remove(index);
            else
                return false;
        }

        // the meta array is sorted to achieve binary search in log(N)
        public int binary_search(int val)
        {
            int p = 0;
            int r = size - 1;
            while (p <= r)
            {
                int q = (p + r) / 2;
                if (array[indices[q]] == val)
                {
                    return indices[q];
                }
                else if (array[indices[q]] < val)
                {
                    p = q + 1;
                }
                else
                {
                    r = q - 1;
                }
            }
            return -1;
        }

        public void display()
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // dry sort on meta data array
        // only to speed some elementary operations
        // test.sort(); // O(N*Lg(N))
        // test.insert_sorted(11); // O(N) instead of O(N^2)
        public void sort(int mode = 0)
        {
            init_indices();
            switch (mode)
            {
                case 1:
                    insertion_sort();
                    break;
                case 0:
                default:
                    quick_sort(0, size - 1);
                    break;
            }
        }

        public void init_indices()
        {
            for (int i = 0; i < size; i++)
            {
                indices[i] = i;
            }
        }

        public void quick_sort(int p, int r)
        {
            if (p < r)
            {
                int pivot = partition(p, r);
                quick_sort(p, pivot - 1);
                quick_sort(pivot + 1, r);
            }
        }

        private int partition(int p, int r)
        {
            int random_pivot = random(p, r + 1); // avoids worst case quick-sort on a sorted array

            // swap random_pivot and first element ////////////////////////////////////
            /**
            int temp = indices[p];
            indices[p] = indices[random_pivot];
            indices[random_pivot] = temp;
            **/
            // end swap ///////////////////////////////////////////////////////////////

            // continue as if first element is pivot
            int pivot = p;
            int k = indices[pivot];
            int x = array[k];
            int i = p - 1;
            for (int j = p + 1; j <= r; j++)
            {
                if (array[indices[j]] <= x)
                {
                    i = i + 1;
                    int tmp = indices[j];
                    indices[j] = indices[i];
                    indices[i] = tmp;
                }
            }
            i = i + 1;
            indices[i] = k;
            return i;
        }

        public void display_sorted()
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.Write(" {0} ", indices[i]);
            }
            Console.WriteLine();

            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.Write(" {0} ", array[indices[i]]);
            }
            Console.WriteLine();
        }

        private int random(int start, int end)
        {
            Random rnd = new Random();
            return rnd.Next(start, end);
        }

        public int at(int index)
        {
            if (index < size)
            {
                return array[index];
            }
            else
            {
                return 0;
            }
        }

        public bool at(int index, int value)
        {
            if (index < size)
            {
                array[index] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
        public int operator [](int index)
        {
            return this.at(indexer);
        }
        **/

        public string toVString()
        {
            char[] ret = new char[size];
            for (int i = 0; i < size; i++)
            {
                ret[size - i - 1] = (char)(array[i] + '0');
            }
            return new string(ret);
        }

        public int get_size()
        {
            return size;
        }

        public void clear()
        {
            size = 0;
        }

        private int[] indices; // holds array sorted indices
        private int[] array;
        private int size;
        private int capacity;
        static int CAP_STEP = 1000;
        static int OO = int.MaxValue;
    }
}
