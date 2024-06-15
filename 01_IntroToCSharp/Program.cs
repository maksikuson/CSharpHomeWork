namespace _01_IntroToCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //1

            Console.WriteLine("I`ts easy to win forgiveness for being wrong;\nbeing right is what gets you into real trouble.\nBjarne Stroustrup");

            //2

            Console.WriteLine("Enter five number : ");
            int num1 = int.Parse(Console.ReadLine()!);
            int num2 = int.Parse(Console.ReadLine()!);
            int num3 = int.Parse(Console.ReadLine()!);
            int num4 = int.Parse(Console.ReadLine()!);
            int num5 = int.Parse(Console.ReadLine()!);

            if (num1 > num2 && num1 > num3 && num1 > num4 && num1 > num5)
            {
                Console.WriteLine("Maximum is " + num1);
            }
            else if (num2 > num1 && num2 > num3 && num2 > num4 && num2 > num5)
            {
                Console.WriteLine("Maximum is " + num2);
            }
            else if (num3 > num1 && num2 > num3 && num2 > num4 && num2 > num5)
            {
                Console.WriteLine("Maximum is " + num3);
            }
            else if (num4 > num1 && num4 > num2 && num3 > num4 && num2 > num5)
            {
                Console.WriteLine("Maximum is " + num4);
            }
            else if (num5 > num1 && num5 > num2 && num5 > num3 && num5 > num4)
            {
                Console.WriteLine("Maximum is " + num5);
            }
            Console.WriteLine("Divide : " + num1 * num2 * num3 * num4 * num5);
            Console.WriteLine("Sum of numbers : ");
            Console.WriteLine(num1 + num2 + num3 + num4 + num5);

            //3

            Console.WriteLine("Enter six digits number : ");
            int nums = int.Parse(Console.ReadLine()!);
            int n6 = nums % 10;
            int n5 = (nums % 100) - n6;
            int n4 = (nums % 1000) - n5 - n6;
            int n3 = (nums % 10000) - n4 - n5 - n6;
            int n2 = (nums % 100000) - n3 - n4 - n5 - n6;
            int n1 = (nums % 1000000) - n2 - n3 - n4 - n5 - n6;
            Console.Write(n6);
            Console.Write(n5 / 10);
            Console.Write(n4 / 100);
            Console.Write(n3 / 1000);
            Console.Write(n2 / 10000);
            Console.Write(n1 / 100000);
            Console.WriteLine();

            //4

            Console.WriteLine("Enter low enge of range : ");
            int low = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter low enge of range : ");
            int high = int.Parse(Console.ReadLine()!);
            int n, a = 0, b = 1;
            for (int i = 0; i <= high; i++)
            {
                n = a;
                a = b;
                b = n + b;
                if (a >= 0 && a <= high)
                {
                    Console.WriteLine(a);
                }
            }

            //5

            Console.WriteLine("Enter A enge of range : ");
            int A = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter B enge of range : ");
            int B = int.Parse(Console.ReadLine()!);
            for (int i = A; i <= B; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }

            //6

            Console.WriteLine("Enter length of line : ");
            int length = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter direction of line \n(H,h - horizontal) \n(V,v - vertikal) ");
            char direction = char.Parse(Console.ReadLine()!);
            if (direction == 'H' || direction == 'h')
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write("+");
                }
            }
            else if (direction == 'V' || direction == 'v')
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("+");
                }
            }
        }
    }
}