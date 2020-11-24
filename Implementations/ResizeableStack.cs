public class ArrayStack<T>
        {
            private T[] array;
            private const int initialCapacity = 2;
            public int Count
            {
                get;
                private set;
            }

            public ArrayStack(int capacity = initialCapacity)
            {
                array = new T[capacity];
            }

            public void resize()
            {
                T[] newArray = new T[array.Length * 2];
                for(int i = 0; i < Count; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }

            public void Push(T item)
            {
                if(Count == array.Length)
                {
                    resize();
                }
                array[Count++] = item; 
            }

            public T Peek()
            {
                if(Count <= 0)
                {
                    throw new InvalidOperationException();
                }
                return array[Count - 1];
            }

            public T pop()
            {
                if (Count <= 0)
                {
                    throw new InvalidOperationException();
                }
                T result = array[Count - 1];
                Count--;
                return result;
            }

            public T[] toArray()
            {
                T[] elements = new T[Count];
                for(int i = 0; i < Count; i++)
                {
                    elements[i] = array[i];
                }
                return elements;
            }
        }