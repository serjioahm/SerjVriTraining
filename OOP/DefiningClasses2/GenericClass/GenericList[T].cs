using System;

namespace GenericClass
{
    public class GenericList<T> 
        where T : IComparable
    {
        private int count;
        private int capacity;
        public T[] ElementList { get; set; }

        public GenericList()
        {
            this.capacity = 1;
            //Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
            this.ElementList = new T[capacity];
            this.count = 0;
        }
        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.ElementList = new T[capacity];
            this.count = 0;
        }

        //Create generic methods  Min<T>()  and  Max<T>()  for finding
        //the minimal and maximal element in the  GenericList<T> 
        public T Min()
        {
            T result = this.ElementList[0];

            for (int i = 1; i < this.count; i++)
            {
                if (this.ElementList[i].CompareTo(result) < 0)
                {
                    result = this.ElementList[i];
                }
            }

            return result;
        }

        public T Max()
        {
            T result = this.ElementList[0];

            for (int i = 1; i < this.count; i++)
            {
                if (this.ElementList[i].CompareTo(result) > 0)
                {
                    result = this.ElementList[i];
                }
            }
            return result;
        }

        //Implement methods for adding element, accessing element by index, removing element by index,
        //inserting element at given position, clearing the list, finding element by its value and  ToString() .
        public void AddElement(T element)
        {
            DoubleCapacityIfNeeded();
            this.ElementList[this.count] = element;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("List index was out of range.");
            }

            for (int i = index; i < count - 1; i++)
            {
                this.ElementList[i] = this.ElementList[i + 1];
            }
            this.count--;
        }
        public void InsertAt(T element, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("List index was out of range.");
            }

            DoubleCapacityIfNeeded();

            for (int i = count ; i >= index + 1; i--)
            {
                this.ElementList[i] = this.ElementList[i - 1];
            }
            this.ElementList[index] = element;
            this.count++;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < this.ElementList.Length; i++)
            {
                if (this.ElementList[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("List index was out of range.");
                }
                return ElementList[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("List index was out of range.");
                }
                ElementList[index] = value;
            }
        }


        public void Clear()
        {
            this.count = 0;
            this.capacity = 1;
            this.ElementList = new T[1];
        }

        //Implement auto-grow functionality: when the internal array is full,
        //create a new array of double size and move all elements to it.
        private void DoubleCapacityIfNeeded()
        {
            if (this.count == this.capacity - 1)
            {
                this.capacity *= 2;
                T[] temp = new T[(this.capacity)];
                for (int i = 0; i < this.ElementList.Length; i++)
                {
                    temp[i] = this.ElementList[i];
                }
                this.ElementList = temp;
            }
        }

        public override string ToString()
        {
            string printer = "";
            for (int i = 0; i < this.count; i++)
            {
                printer = printer + this.ElementList[i] + " ";
            }
            return printer;
        }
    }
}
