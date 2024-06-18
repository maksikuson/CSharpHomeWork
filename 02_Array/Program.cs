using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _02_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region task1

            int[] arr = new int[10] { 1, 1, 1, 4, 12, 7, 71, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            int coutEven = 0;
            int coutOdd = 0;
            int coutUnique = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] % 2 == 0)
                {
                    coutEven++;
                }
                else
                {
                    coutOdd++;
                }
            }
            Console.WriteLine("Cout odd : " + coutOdd);
            Console.WriteLine("Cout even : " + coutEven);
            for (int i = 0; i < arr.Length; i++)
            {
                int repeats = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        repeats++;
                    }
                }
                if (repeats == 1)
                {
                    coutUnique++;
                }
            }
            Console.WriteLine("Cout Yunik : " + coutUnique);
            Console.WriteLine();
            #endregion

            #region task2

            int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Enter threshold value : ");

            int threshold = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] < threshold)
                {
                    Console.Write(arr2[i] + " ");
                }
            }
            
            #endregion

            #region task 3

            int[] A = new int[5];
            double[,] B = new double[3, 4];
            Random random1 = new Random();

            Console.WriteLine("Enter 5 numbers for array A : ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"A[{i}] = ");
                int l = int.Parse(Console.ReadLine()!);
                A[i] = l;
            }

            for (int i = 0;i < B.GetLength(0); i++)
            {
                for (int j = 0;j < B.GetLength(1); j++)
                {
                    B[i,j] = random1.NextDouble() * 100;
                }
            }

            Console.WriteLine("Array A : ");
            for(int i = 0; i < A.Length ; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Array B : ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i,j]:F2}");
                }
            }
            Console.WriteLine();

            double maxElement = double.MinValue;
            double minElement = double.MaxValue;
            double totalSum = 0;
            double totalProduct = 1;

            foreach (int value in A)
            {
                if (value > maxElement) maxElement = value;
                if (value < minElement) minElement = value;
                totalSum += value;
                totalProduct *= value;
            }

            foreach (double value in B)
            {
                if (value > maxElement) maxElement = value;
                if (value < minElement) minElement = value;
                totalSum += value;
                totalProduct *= value;
            }

            int sumEvenA = 0;
            foreach (int value in A)
            {
                if (value % 2 == 0)
                {
                    sumEvenA += value;
                }
            }

            double sumOddColumsB = 0;
            for (int i = 0; i < B.GetLength(1); i += 2)
            {
                for (int j = 0; j < B.GetLength(0); j++)
                {
                    sumOddColumsB += B[i, j];
                }
            }

            Console.WriteLine("\nTotal maximum element: " + maxElement);
            Console.WriteLine("Common minimum element:" + minElement);
            Console.WriteLine("Total sum of all elements:" + totalSum);
            Console.WriteLine("Total product of all elements:" + totalProduct);
            Console.WriteLine("Sum of even elements of array A:" + sumEvenA);
            Console.WriteLine("Sum of elements of odd columns of array B:" + sumOddColumsB);

            #endregion

            #region task 4

            int[,] array1 = new int[5, 5];
            Random random = new Random();

            for (int i = 0;i < array1.GetLength(0);i++)
            {
                for(int j = 0;j < array1.GetLength(1);j++)
                {
                    array1[i,j] = random.Next(-100,100);
                }
            }

            Console.WriteLine("2D array : ");
            for (int i = 0; i < array1.GetLength(0);i++)
            {
                for (int j = 0;j < array1.GetLength(1); j++)
                {
                    Console.WriteLine(array1[i, j] + " ");
                }
                Console.WriteLine();
            }

            int rows = array1.GetLength(0);
            int cols = array1.GetLength(1);
            int[] array2 = new int[rows * cols];

            int index = 0;
            for (int i = 0; index < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array2[index] = array1[i, j];
                    index++;
                }
            }

            int max = array2[0];
            int min = array2[0];
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 1; i < array2.Length; i++)
            {
                {
                    if (array2[i] > max)
                    {
                        max = array2[i];
                        maxIndex = i;
                    }
                    if (array2[i] > min)
                    {
                        min = array2[i];
                        minIndex = i;
                    }
                }
            }

            int sum = 0;

            if (maxIndex > minIndex)
            {
                for (int i = minIndex + 1; i < maxIndex; i++)
                {
                     sum += array2[i]; 
                }
            }
            else
            {
                for(int i = minIndex + 1;i < maxIndex; i++)
                {
                    sum += array2[i];
                }
            }

            Console.WriteLine("Max Number: " + max);
            Console.WriteLine("Min Number: " + min);
            Console.WriteLine("Sum between Max and Min: " + sum);

            #endregion

            #region task 5

            int[] arrays = { 2, 8, 11, 9, 5, 4 };

            int minA = arrays[0];
            int count = 0;

            for (int i = 1; i < arrays.Length; i++)
            {
                if (arrays[i] < min)
                {
                    min = arrays[i];
                }
            }
            
            for (int i = 0;i < arrays.Length; i++)
            {
                if((arrays[i] - minA) == 5)
                {
                    count++;
                }
            }

            Console.WriteLine($" The number of elements in the given array that are different from the minimum by 5: {count}");

            #endregion

        }
    }
}
