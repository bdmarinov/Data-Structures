public class LinkedStack<T>
        {
            private Node topNode;

            public int Count
            {
                get;
                private set;
            }

            public void Push(T item)
            {
                Node newNode = new Node(item, topNode);
                topNode = newNode;
                Count++;
            }

            public T Peek()
            {
                if(Count == 0)
                {
                    throw new InvalidOperationException();
                }
                return topNode.Value;
            }

            public T Pop()
            {
                if(Count == 0)
                {
                    throw new InvalidOperationException();
                }
                T result = topNode.Value;

                topNode = topNode.Next;
                Count--;
                return result;
            }

            public T[] toArray()
            {
                T[] array = new T[Count];
                for(int i = Count-1; i >= 0; i--)
                {
                    array[i] = topNode.Value;
                    topNode = topNode.Next;
                }
                return array;
            }
            private class Node
            {
                public T Value
                {
                    get;
                    set;
                }
                public Node Next
                {
                    get;
                    set;
                }

                public Node(T value, Node Next = null)
                {
                    this.Value = value;
                    this.Next = Next;
                } 
            }
        }