using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApplication4
{

    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Part 1:\n");
            Console.WriteLine("bool: {0}, {1}", (false), (true));
            Console.WriteLine("sbyte: {0}, {1}", (sbyte.MinValue), (sbyte.MaxValue));
            Console.WriteLine("char: {0}, {1}", (char.MinValue), (char.MaxValue));
            Console.WriteLine("decimal: {0}, {1}", (decimal.MinValue), (decimal.MaxValue));
            Console.WriteLine("double: {0}, {1}", (double.MinValue), (double.MaxValue));
            Console.WriteLine("float: {0}, {1}", (float.MinValue), (float.MaxValue));
            Console.WriteLine("int: {0}, {1}", (int.MinValue), (int.MaxValue));
            Console.WriteLine("uint: {0}, {1}", (uint.MinValue), (uint.MaxValue));
            Console.WriteLine("long: {0}, {1}", (long.MinValue), (long.MaxValue));
            Console.WriteLine("ulong: {0}, {1}", (ulong.MinValue), (ulong.MaxValue));
            Console.WriteLine("short: {0}, {1}", (short.MinValue), (short.MaxValue));
            Console.WriteLine("ushort: {0}, {1} \n", (ushort.MinValue), (ushort.MaxValue));

            //2
            Console.WriteLine("\nPart 2:\n");
            double x1, x2;
            Console.WriteLine("Enter 2 sides.");

            string input = Console.ReadLine(); //получает строку с консоли
            var num = input.Split(' '); //разделить на два элемента по пробелу
            double.TryParse(num[0], out x1);
            double.TryParse(num[1], out x2); //помещает разделённую строку в переменные как int

            Rectangle x = new Rectangle(x1, x2); //создаём об. класса

            Console.WriteLine("AreaCalculator = {0}", (x.AreaCalculator().ToString()));
            Console.WriteLine("PerimeterCalculator = {0}", (x.PerimeterCalculator().ToString()));
            double z = x.Area;
            Console.WriteLine("Area = {0}", (z));
            z = x.Perimeter;
            Console.WriteLine("Perimeter = {0}", (z));

            //3
            Console.WriteLine("\nPart 3:");
            Figure test_1 = new Figure("Three Pts",
                                  new Point(1, 6),
                                  new Point(2, 0),
                                  new Point(1.5, 3));
            test_1.print_points();
            test_1.print();

            Figure test_2 = new Figure("Four Pts",
                                      new Point(10, 0),
                                      new Point(10, 10),
                                      new Point(0, 10),
                                      new Point(0, 0));
            test_2.print_points();
            test_2.print();

            Figure test_3 = new Figure("Five Pts",
                                      new Point(10, 5),
                                      new Point(8, 1),
                                      new Point(5, -5),
                                      new Point(10, 0),
                                      new Point(12, 6));
            test_3.print_points();
            test_3.print();

            Console.ReadKey();

        }
    }

    public class Rectangle
    {
        double side1, side2; //стороны

        public Rectangle(double sideA = 0, double sideB = 0) //конструктор
        {
            side1 = sideA;
            side2 = sideB;
        }

        public double AreaCalculator() //функция возвращающая площадь
        {
            return side1 * side2;
        }

        public double PerimeterCalculator() //функция возвращающая периметр
        {
            return side1 * 2 + side2 * 2;
        }

        public double Area //метод возвращающий площадь
        {
            get { return side1 * side2; }
        }

        public double Perimeter //меторд возвращающий периметр
        {
            get { return side1 * 2 + side2 * 2; }
        }
    }

    public class Point
    {
        double _x, _y;

        public double X { get => _x; }
        public double Y { get => _y; }
        //методы get для координат

        public Point (double x = 0, double y = 0)//конструктор
        {
            _x = x;
            _y = y;
        }
    }

    public class Figure
    {
        Point[] _points; //массив точек
        public string Name { get; set; } //автосвойство имени фигуры

        //public Point[] Pts { get => _pts; set => _pts = value; }

        public Figure(string str, Point A, Point B, Point C) //конструкт с 3 точками
        {
            _points = new Point[3] { A, B, C };
            Name = str;
        }
        public Figure(string str, Point A, Point B, Point C, Point D) // с 4 точками
        {
            _points = new Point[4] { A, B, C, D};
            Name = str;
        }
        public Figure(string str, Point A, Point B, Point C, Point D, Point E) // с 5 точками
        {
            _points = new Point[5] { A, B, C, D, E};
            Name = str;
        }

        public double LengthSide(Point A, Point B) //находит длинну стороны
            => Math.Sqrt( Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.X, 2) );

        public double PerimeterCalculator()
        {
            double rez = 0;
            for (int i = 1; i < _points.Length; ++i)
            {
                rez += LengthSide(_points[i-1], _points[i]);
            }
            rez += LengthSide(_points[0], _points[_points.Length - 1]);
            return rez;
        }

        public void print()
        {
            Console.WriteLine($"[{Name}] Perimeter is {PerimeterCalculator()}");
        }

        public void print_points()
        {
            Console.WriteLine(Name);
            int i = 0;
            foreach (Point A in _points)
            {
                Console.WriteLine($"{i}: {A.X}, {A.Y}.");
                ++i;
            }
        }
    }
}

