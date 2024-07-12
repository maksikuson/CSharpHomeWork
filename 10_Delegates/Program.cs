namespace _11_Delegates
{
    public delegate int CalculateOperation(int[] array);
    public delegate void ModifyOperation(int[] array);

    public class ArrayOperations
    {
        public static int CalculateSum(int[] array)
        {
            int sum = 0;
            foreach (int elem in array)
            {
                sum += elem;
            }
            return sum;
        }
        public static int CountPrimeNumbers(int[] array)
        {
            int count = 0;
            foreach (int elem in array)
            {
                if (IsPrime(elem))
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountNegativeElements(int[] array)
        {
            int count = 0;
            foreach (int elem in array)
            {
                if (elem < 0)
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        public static void MoveEvenElementsToFront(int[] array)
        {
            int evenIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    int temp = array[evenIndex];
                    array[evenIndex] = array[i];
                    array[i] = temp;
                    evenIndex++;
                }
            }
        }

        public static void ReplaceNegativeWithZero(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = 0;
                }
            }
        }

        public static void SortArray(int[] array)
        {
            Array.Sort(array);
        }

    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, -2, 3, 4, -5, 6, 7, 8, 9 };

            Console.WriteLine("Choose operation type:");
            Console.WriteLine("1. Calculate operation");
            Console.WriteLine("2. Modify operation");

            int operationType = int.Parse(Console.ReadLine()!);

            if (operationType == 1)
            {
                Console.WriteLine("Choose calculate operation:");
                Console.WriteLine("1. Count negative elements");
                Console.WriteLine("2. Calculate sum");
                Console.WriteLine("3. Count prime numbers");
                int calculateOperation = int.Parse(Console.ReadLine()!);

                CalculateOperation? operation = null;

                switch (calculateOperation)
                {
                    case 1:
                        operation = ArrayOperations.CountNegativeElements;
                        break;
                    case 2:
                        operation = ArrayOperations.CalculateSum;
                        break;
                    case 3:
                        operation = ArrayOperations.CountPrimeNumbers;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        return;
                }

                int result = operation(array);
                Console.WriteLine("Result: " + result);
            }
            else if (operationType == 2)
            {
                Console.WriteLine("Choose modify operation:");
                Console.WriteLine("1. Replace negative with zero");
                Console.WriteLine("2. Sort array");
                Console.WriteLine("3. Move even elements to front");

                int modifyOperation = int.Parse(Console.ReadLine()!);

                ModifyOperation? operation = null;

                switch (modifyOperation)
                {
                    case 1:
                        operation = ArrayOperations.ReplaceNegativeWithZero;
                        break;
                    case 2:
                        operation = ArrayOperations.SortArray;
                        break;
                    case 3:
                        operation = ArrayOperations.MoveEvenElementsToFront;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        return;
                }
                operation(array);
                Console.WriteLine("Array after modification:");
                foreach (int elem in array)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid operation type");
            }
        }
    }
}
