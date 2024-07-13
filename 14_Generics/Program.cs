namespace _14_Generics
{
    //Task 4
    public class Stack<T>
    {
        private List<T> _elements = new List<T>();
        public void Push(T item)
        {
            _elements.Add(item);
        }
        public T Pop()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            return item;
        }
        public T Peek()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _elements[_elements.Count - 1];
        }
        public int Count
        {
            get { return _elements.Count; }
        }
    }

    //Task 5

    public class Queue<T>
    {
        private LinkedList<T> _elements = new LinkedList<T>();
        public void Enqueue(T item)
        {
            _elements.AddLast(item);
        }
        public T Dequeue()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = _elements.First.Value;
            _elements.RemoveFirst();
            return value;
        }
        public T Peek()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _elements.First.Value;
        }
        public int Count
        {
            get { return _elements.Count; }
        }
    }

    internal class Program
    {

        //Task 1

        public static T Max<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;
            if (b.CompareTo(max) > 0)
            {
                max = b;
            }
            if (c.CompareTo(max) > 0)
            {
                max = c;
            }
            return max;
        }

        //Task 2

        public static T Min<T>(T a1, T b1, T c1) where T : IComparable<T>
        {
            T min = a1;
            if (b1.CompareTo(min) < 0)
            {
                min = b1;
            }
            if (c1.CompareTo(min) > 0)
            {
                min = c1;
            }
            return min;
        }

        //Task 3

        public static T Sum<T>(T[] array)
        {
            dynamic sum = default(T);
            foreach (var item in array)
            {
                sum += (dynamic)item;
            }
            return sum;
        }

        static void Main(string[] args)
        {

            //Task 1

            int maxInt = Max(3, 5, 1);
            Console.WriteLine($"Max int : {maxInt}");

            double maxDouble = Max(3.5, 2.4, 5.9);
            Console.WriteLine($"Max double : {maxDouble}");

            //Task 2

            int minInt = Min(3, 5, 1);
            Console.WriteLine($"Min int : {minInt}");

            double minDouble = Min(3.5, 2.4, 5.9);
            Console.WriteLine($"Min double : {minDouble}");

            //Task 3

            int[] intArray = { 1, 2, 3, 4, 5 };
            int intSum = Sum(intArray);
            Console.WriteLine($"Sum of int array : {intSum}");

            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double doubleSum = Sum(doubleArray);
            Console.WriteLine($"Sum of double array : {doubleSum}");

            //Task 4

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Count : {stack.Count}");
            Console.WriteLine($"Peek : {stack.Peek()}");
            Console.WriteLine($"Pop : {stack.Pop()}");
            Console.WriteLine($"Count after Pop : {stack.Count}");
            Console.WriteLine($"Pop : {stack.Pop()}");
            Console.WriteLine($"Pop : {stack.Pop()}");
            try
            {
                Console.WriteLine($"Pop: {stack.Pop()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            //Task 5

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine($"Count : {queue.Count}");
            Console.WriteLine($"Peek : {queue.Peek()}");
            Console.WriteLine($"Dequeue : {queue.Dequeue()}");
            Console.WriteLine($"Count after Dequeue : {queue.Count}");
            Console.WriteLine($"Dequeue : {queue.Dequeue()}");
            Console.WriteLine($"Dequeue : {queue.Dequeue()}");
            try
            {
                Console.WriteLine($"Dequeue : {queue.Dequeue()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
