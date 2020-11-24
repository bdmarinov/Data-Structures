public class CircularQueue<T>
{

    private const int DefaultCapacity = 4;
    private T[] elements;

    private int Start;
    private int End;
    

    public int Count
    {
        get;
        private set;
    }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }

    private void CopyAllElements(T[] newArray)
    {
        int index = 0;
        for(int i = Start; i < End; i++){
            newArray[index] = elements[i];
        }
    }

    private void Resize()
    {
        T[] newArray = new T[this.elements.Length * 2];
        
        this.CopyAllElements(newArray);

        this.elements = newArray;

        this.Start = 0;
        this.End = Count;
    }

    public void Enqueue(T element)
    {
        if(this.Count == this.elements.Length)
        {
            this.Resize();
        }

        this.elements[End] = element;
        this.End = (this.End + 1) % elements.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T result = this.elements[this.Start];
        this.Start = (this.Start + 1) % this.elements.Length;

        this.Count--;
        return result;
    }
}