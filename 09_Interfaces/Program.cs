namespace _09_Interfaces
{
    public interface IOutput
    {
        void Show();
        void Show(string info);
    }
    public interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }
    public interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    public class Array : IOutput, IMath, ISort
    {
        private int[] _array;
        public Array(int[] array)
        {
            _array = array;
        }
        public void Show()
        {
            Console.WriteLine(string.Join(", ", _array));
        }
        public void Show(string info)
        {
            Console.WriteLine(info);
            Console.WriteLine(string.Join(", ", _array));
        }
        public int Max()
        {
            return _array.Max();
        }
        public int Min()
        {
            return _array.Min();
        }
        public float Avg()
        {
            return (float)_array.Average();
        }
        public bool Search(int valueToSearch)
        {
            return _array.Contains(valueToSearch);
        }
        public void SortAsc()
        {
            System.Array.Sort(_array);
        }
        public void SortDesc()
        {
            System.Array.Sort(_array);
            System.Array.Reverse(_array);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int[] data = { 5, 3, 8, 1, 2 };

            Array array = new Array(data);
            Console.WriteLine("Testing IOutput:");

            array.Show();
            array.Show("Array elements:");

            Console.WriteLine("\nTesting IMath:");
            Console.WriteLine($"Max: {array.Max()}");
            Console.WriteLine($"Min: {array.Min()}");
            Console.WriteLine($"Avg: {array.Avg()}");
            Console.WriteLine($"Search 3: {array.Search(3)}");
            Console.WriteLine($"Search 10: {array.Search(10)}");
            Console.WriteLine("Testing ISort:");

            array.SortAsc();
            array.Show("Sorted Ascending:");
            array.SortDesc();
            array.Show("Sorted Descending:");
            array.SortByParam(true);
            array.Show("Sorted by Param (true):");
            array.SortByParam(false);
            array.Show("Sorted by Param (false):");
        }
    }
}
