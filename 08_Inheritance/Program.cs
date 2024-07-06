namespace _08_Inheritance
{
    abstract class GeometricFigure
    {
        protected int A;

        public GeometricFigure()
        {
            A = 0;
        }
        public GeometricFigure(int a)
        {
            A = a;
        }
        public void Print()
        {
            Console.WriteLine($"A : {A}.");
        }
        public abstract float GetArea();
        public abstract int GetPerimeter();
    }
    class Тriangle : GeometricFigure
    {
        protected int B;
        protected int H;
        protected int C;
        public Тriangle() : base()
        {
            B = 0;
            H = 0;
            C = 0;
        }
        public Тriangle(int a) : base(a)
        {
        }
        public Тriangle(int a, int b, int h, int c) : base(a)
        {
            B = b;
            H = h;
            C = c;
        }
        public override float GetArea()
        {
            float area = (float)(A * H / 2.0);
            return area;
        }
        public override int GetPerimeter()
        {
            int perimetre = A + B + C;
            return perimetre;
        }
        public new void Print()
        {
            Console.WriteLine($"Area of Triangle: {GetArea()}. Perimetr of Triangle: {GetPerimeter()}");
        }

    }
    class Cube : GeometricFigure
    {
        public Cube() : base() { }
        public Cube(int a) : base(a) { }

        public override float GetArea()
        {
            float area = (A * A);
            return area;
        }
        public override int GetPerimeter()
        {
            int perimetre = A + A + A + A;
            return perimetre;
        }
        public new void Print()
        {
            Console.WriteLine($"Area of Cube: {GetArea()}. Perimetr of Cube: {GetPerimeter()}");
        }
        class Romb : GeometricFigure
        {
            protected int D;
            public Romb() : base()
            {
                D = 0;
            }
            public Romb(int d, int a) : base(a)
            {
                D = d;
            }
            public override float GetArea()
            {
                float area = (float)(A * D / 2.0);
                return area;
            }
            public override int GetPerimeter()
            {
                int perimetre = A + A + D + D;
                return perimetre;
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Romb: {GetArea()}. Perimetr of Romb: {GetPerimeter()}");
            }
        }
        class Rectangle : GeometricFigure
        {
            protected int D;
            public Rectangle() : base()
            {
                D = 0;
            }
            public Rectangle(int d, int a) : base(a)
            {
                D = d;
            }
            public override float GetArea()
            {
                float area = (float)(A * D / 2.0);
                return area;
            }
            public override int GetPerimeter()
            {
                int perimetre = A + A + D + D;
                return perimetre;
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Rectangle: {GetArea()}. Perimetr of Rectangle: {GetPerimeter()}");
            }

        }
        class Parallelogram : GeometricFigure
        {
            protected int H1;
            protected int B1;
            public Parallelogram() : base()
            {
                H1 = 0;
                B1 = 0;
            }
            public Parallelogram(int h1, int b1, int a) : base(a)
            {
                H1 = h1;
                B1 = b1;
            }
            public override float GetArea()
            {
                float area = (float)(A * H1 / 2.0);
                return area;
            }
            public override int GetPerimeter()
            {
                int perimetre = 2 * A + B1 * 2;
                return perimetre;
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Parallelogram: {GetArea()}. Perimetr of Parallelogram: {GetPerimeter()}");
            }

        }
        class Trapeze : GeometricFigure
        {
            protected int H1;
            protected int B1;
            public Trapeze() : base()
            {
                H1 = 0;
                B1 = 0;
            }
            public Trapeze(int h1, int b1, int a) : base(a)
            {
                H1 = h1;
                B1 = b1;
            }
            public override float GetArea()
            {
                float area = (float)(A * H1 / 2.0);
                return area;
            }

            public override int GetPerimeter()
            {
                int perimetre = 2 * (H1 + B1);
                return perimetre;
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Trapeze: {GetArea()}. Perimetr of Trapeze: {GetPerimeter()}");
            }

        }
        class Сircle : GeometricFigure
        {

            public Сircle() : base() { }
            public Сircle(int a) : base(a) { }

            public override float GetArea()
            {
                float area = (float)(A * A * 3.14);
                return area;
            }

            public override int GetPerimeter()
            {
                int perimetre = 2 * A * 3;
                return perimetre;
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Сircle: {GetArea()}. Perimetr of Сircle: {GetPerimeter()}");
            }

        }

        class Ellipse : GeometricFigure
        {
            protected int R;
            protected int R1;
            public Ellipse() : base()
            {
                R = 0;
                R1 = 0;
            }

            public Ellipse(int r, int r1, int a) : base(a)
            {
                R = r;
                R1 = r1;
            }

            public override float GetArea()
            {
                float area = (float)(3.14 * R * R1);
                return area;
            }

            public override int GetPerimeter()
            {
                return (int)(Math.PI * (3 * (R + R1) - Math.Sqrt((3 * R + R1) * (R + 3 * R1))));
            }
            public new void Print()
            {
                Console.WriteLine($"Area of Ellipse: {GetArea()}. Perimetr of Ellipse: {GetPerimeter()}");
            }

        }
        class CompoundFigure
        {
            private List<GeometricFigure> figures = new List<GeometricFigure>();

            public void AddFigure(GeometricFigure figure)
            {
                figures.Add(figure);
            }

            public void PrintAll()
            {
                foreach (var figure in figures)
                {
                    figure.Print();
                }
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Тriangle triangle = new Тriangle(3, 4, 5, 2);
                triangle.Print();
                Cube cube = new Cube(3);
                cube.Print();
                Romb romb = new Romb(3, 10);
                romb.Print();
                Rectangle rectangle = new Rectangle(3, 10);
                rectangle.Print();
                Parallelogram parallelograme = new Parallelogram(3, 10, 6);
                parallelograme.Print();
                Trapeze trapeze = new Trapeze(4, 6, 8);
                trapeze.Print();
                Ellipse ellipse = new Ellipse(3, 5, 4);
                ellipse.Print();
                CompoundFigure compoundFigure = new CompoundFigure();


                compoundFigure.AddFigure(new Cube(3));
                compoundFigure.AddFigure(new Romb(3, 10));
                compoundFigure.AddFigure(new Rectangle(3, 10));
                compoundFigure.AddFigure(new Parallelogram(3, 10, 6));
                compoundFigure.AddFigure(new Trapeze(4, 6, 8));
                compoundFigure.AddFigure(new Ellipse(3, 5, 4));

                compoundFigure.PrintAll();

            }
        }
    }
}
