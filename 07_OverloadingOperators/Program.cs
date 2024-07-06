namespace _07_OverloadingOperators
{
    class Rectangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public Rectangle() : this(0, 0) { }
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return $"A : {A}, B : {B}";
        }

        public static explicit operator int(Rectangle r1)
        {
            return r1.A + r1.B;
        }

        public static explicit operator Rectangle(Square s1)
        {
            return new Rectangle(s1.A, 10);
        }
    }
    class Square
    {
        public int A { get; set; }
        public Square() : this(0) { }
        public Square(int a)
        {
            A = a;
        }
        public override string ToString()
        {
            return $"A : {A}";
        }
        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }
        public static Square operator --(Square s)
        {
            s.A--;
            return s;
        }
        public static Square operator +(Square s1, Square s2)
        {
            return new Square(s1.A + s2.A);
        }
        public static Square operator -(Square s1, Square s2)
        {
            return new Square(s1.A - s2.A);
        }
        public static Square operator /(Square s1, Square s2)
        {
            if (s2.A == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return new Square(s1.A / s2.A);
        }
        public static bool operator ==(Square s1, Square s2)
        {
            return s1.A == s2.A;
        }
        public static bool operator !=(Square s1, Square s2)
        {
            return s1.A != s2.A;
        }
        public static Square operator *(Square s1, Square s2)
        {
            return new Square(s1.A * s2.A);
        }
        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }
        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }
        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }
        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }
        public static bool operator true(Square s1)
        {
            return s1.A != 0;
        }
        public static bool operator false(Square s1)
        {
            return s1.A == 0;
        }
        public static explicit operator int(Square s1)
        {
            return s1.A;
        }
        public static explicit operator Rectangle(Square s1)
        {
            return new Rectangle(s1.A, 15);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Square s = (Square)obj;
            return A == s.A;
        }
        public override int GetHashCode()
        {
            return A.GetHashCode();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Square s1 = new Square(5);
            Square s2 = new Square(3);

            Console.WriteLine($"s1 + s2 = {s1 + s2}");
            Console.WriteLine($"s1 - s2 = {s1 - s2}");
            Console.WriteLine($"s1 * s2 = {s1 * s2}");
            Console.WriteLine($"s1 / s2 = {s1 / s2}");

            Rectangle s = null;
            Rectangle r = (Rectangle)s;
            Console.WriteLine(r);

            int sum = (int)s1;
            Console.WriteLine($"Sum of sides of r1: {sum}");
        }
    }
}
