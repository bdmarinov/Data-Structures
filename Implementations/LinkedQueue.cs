public class LinkedQueue<T>
        {

            private Node front;
            private Node tail;

            public LinkedQueue()
            {
                front = null;
                tail = null;
            }

            public int Count
            {
                get;
                private set;
            }

            public void Enqueue(T item)
            {
                Node newNode = new Node(item);
                Count++;
                if (Count == 1)
                {
                    front = tail = newNode;
                }
                else
                {
                    newNode.Prev = tail;
                    tail = newNode;
                }
            }

            public T Dequeue()
            {
                if(Count == 0)
                {
                    throw new InvalidOperationException();
                }

                T result = front.Value;

                if(Count == 1)
                {
                    front = tail = null;
                }
                else
                {
                    front = front.Next;
                    front.Prev = null;
                }
                Count--;
                return result;
            }
            
            public T[] toArray()
            {
                T[] array = new T[Count];
                Node current = front;
                int i = 0;
                while(current != null)
                {
                    array[i] = current.Value;
                    current = current.Next;
                }
                return array;
            }
            private class Node
            {
                public T Value { get; private set; }
                public Node Next { get; set; }
                public Node Prev { get; set; }
                public Node(T value)
                {
                    Value = value;
                }
            }
        }