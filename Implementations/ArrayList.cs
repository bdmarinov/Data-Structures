public class ArrayList<T>
        {
            private T[] array;

            public ArrayList()
            {
                array = new T[2];
            }

            public int Count
            {
                get;
                private set;
            }

            public T this[int index]
            {
                get
                {
                    if(index < 0 || index >= Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return array[index];
                }
                set
                {
                    if(index < 0 || index >= Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    array[index] = value;
                }
            }

            private void resize()
            {
                T[] newArray = new T[array.Length * 2];
                for(int i = 0; i < Count; i++)
                {
                    newArray[i] = array[i];
                }

                array = newArray;
            }
            public void Add(T item)
            {
                if(Count == array.Length)
                {
                    resize();
                }
                array[Count++] = item;
            }

            public T removeAt(int index)
            {
                if(index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                T value = array[index];

                for(int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i - 1];
                }

                Count--;
                if(Count <= array.Length/4)
                {
                    T[] newArray = new T[array.Length / 2];
                    for(int i = 0; i < Count; i++)
                    {
                        newArray[i] = array[i];
                    }
                    array = newArray;
                }
                return value;
            }
        }