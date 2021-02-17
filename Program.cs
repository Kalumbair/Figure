using System;
using System.Collections.Generic;

namespace Попытка
{

    class Program
    {
        abstract class Figure
        {
            public double p;
            public double s;
            protected int n;
            protected abstract void PandS();
        }

        class Square : Figure
        {
            static int num = 1;
            double a;
            public Square(double a)
            {
                this.a = a;
                n = num++;
                PandS();
            }
            
            protected override void PandS()
            {
                this.p = (a + a) * 2;
                this.s = a * a;
            }

            public override string ToString()
            {
                return String.Format("Квадрат {0}, сторона: {1}, периметр: {2:F2}, площадь: {3:F2}.", n, a, p, s);
            }
        }

        class Rectangle : Figure
        {
            static int num = 1;
            double a;
            double b;
            public Rectangle(double a, double b)
            {
                this.a = a;
                this.b = b;
                n = num++;
                PandS();
            }
            protected override void PandS()
            {
                this.p = (a + b) * 2;
                this.s = a * b;                
            }

            public override string ToString()
            {
                return String.Format("Прямоугольник {0}, стороны: {1} и {2}, " +
                "периметр: {3:F2}, площадь: {4:F2}.", n, a, b, p, s);
            }
        }

        class Triangle : Figure
        {
             static int num = 1;
            double a;
            double b;
            double c;
            public Triangle(double a, double b, double c)
            {
                if (a>=b+c || b>=a+c || c>=a+b)
                    throw new ArithmeticException();
                this.a = a;
                this.b = b;
                this.c = c;
                n=num++;
                PandS(); 
            }
            protected override void PandS()
            {
                this.p = a + b+ c;
                this.s = Math.Sqrt((p/2)*((p / 2-a)* (p / 2 - b)*(p / 2 - a)));
            }
            public override string ToString()
            {
                return String.Format("Треугольник {0}, стороны: {1}, {2} и {3} " +
                "периметр: {4:F2}, площадь: {5:F2}.", n, a, b, c, p, s);
            }
        }
        class Circle : Figure
        {
            static int num = 1;
            double r;
            public Circle(double r)
            {
                this.r = r;
                n=num++;
                PandS();
            }

            protected override void PandS()
            {
                this.p = 2*Math.PI*r;
                this.s = Math.PI * Math.Pow(r,2);
            }
            public override string ToString()
            {
                return String.Format("Круг {0}, радиус: {1}, " +
                "периметр: {2:F2}, площадь: {3:F2}.", n, r, p, s);
            }
        }

        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();
            int p;
            do {
                try
                {
                    Console.WriteLine("Введите цифру фигуры: 1-квадрат, 2-прямоугольник, 3- треугольник, 4- круг");
                    double[] a= new double[3];
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Введите сторону квадрата");
                            a[0]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            figures.Add(new Square(a[0]));
                            break;
                        case 2:
                            Console.WriteLine("Введите стороны прямоугольника");
                            a[0]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            a[1]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            figures.Add(new Rectangle(a[0], a[1]));
                            break;
                        case 3:
                            Console.WriteLine("Введите стороны треугольника");
                            a[0]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            a[1]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            a[2]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            figures.Add(new Triangle(a[0], a[1], a[2]));
                            break;
                        case 4:
                            Console.WriteLine("Введите радиус круга");
                            a[0]=Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            figures.Add(new Circle(a[0]));
                            break;
                        default:
                            Console.WriteLine("Введите цифру от 1-4");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Че то вы ввели совсем не то");
                }
                catch(ArithmeticException)
                {
                     Console.WriteLine("Такого треугольника просто нет ");
                }
                Console.WriteLine("Еще хотите выбрать фигуру? 0-Нет");
                p=Convert.ToInt32(Console.ReadLine());
            }
            while (p!=0);

            foreach (var f in figures)
                Console.WriteLine(f.ToString());
            Console.ReadKey();
        }
    }
}
