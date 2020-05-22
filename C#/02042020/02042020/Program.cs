using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02042020
{
    // public class Point<T> where T: struct
    // public class Point<T> where T: class
    // public class Point<T> where T: new()
    // public class Point<T,U> where U: struct where T: class, new()
    // public class Group<T> where T: Student
    // public class Group<T> where T: IClient
    public class Point<T> where T : struct
    {
        T X, Y;
        public T Z { get; set; }
        public static T radius;
        public Point(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point() : this(default, default, default)
        {
        }
        //public Point()
        //{
        //    X = default(T);
        //    Y = default(T);
        //    Z = default(T);
        //}
        public override string ToString()
        {
            return $"({X,5};{Y,5};{Z,5} - {radius,10})";
        }
        public void Reset()
        {
            X = default;
            Y = default;
            Z = default(T);
        }

    }

    class Circle : Point<int>
    {
        public int R { get; set; }
        // public Circle() { }
        public Circle() : base() { R = 0; }
        public Circle(int r, int x, int y) : base(x, y, 0) { R = r; }
        public override string ToString()
        {
            return $"Circle R={R} {base.ToString()}";
        }

    }
    public class Circle<T> : Point<T> where T : struct
    {
        public T R { get; set; }
        // public Circle() { }
        public Circle() : base() { R = default; }
        public Circle(T r, T x, T y) : base(x, y, default)
        {
            R = r;
        }
        public override string ToString()
        {
            return $"Circle R={R} {base.ToString()}";
        }

    }
    public class Kolo<U>
    {
        public class Point<T>
        {
            T X, Y;
            public T Z { get; set; }
            public static T radius;
            public Point(T x, T y, T z)
            {
                X = x; Y = y; Z = z;
            }
            public Point() : this(default, default, default)
            {
            }
            public override string ToString()
            {
                return $"({X,5};{Y,5};{Z,5} - {radius,10})";
            }
            public void Reset()
            {
                X = default;
                Y = default;
                Z = default(T);
            }

        }
        public U R { get; set; }
        Point<U> center;
        // public Circle() { }
        public Kolo() { R = default; center = default; }
        public Kolo(U r, U x, U y)
        {
            R = r;
            center = new Point<U>(x, y, default);
        }
        public override string ToString()
        {
            return $"Kolo R={R} {center}";
        }

    }

    class Element
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        // Max
        public static T Max<T>(T[] mas) where T : IComparable<T>
        {
            T max = mas[0];
            foreach (var item in mas)
                if (max.CompareTo(item) < 0)
                    max = item;
            return max;
        }

    }
    class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }

        public int CompareTo(Student other)
        {
            return String.Compare(Name, other?.Name);
        }

        public override string ToString()
        {
            return $"|{Name,-15}|{Bday.ToShortDateString(),12}|";
        }

    }
    class CompDate : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return DateTime.Compare(x.Bday, y.Bday);
        }
    }

    class Program
    {
        static void Test1()
        {
            Point<int> point = new Point<int>(10, 20, 30);
            point.Reset();
            ///point.Z = 15;
            //point.Z = 15.99; error
            Console.WriteLine(point);
            Point<double> point2 = new Point<double>(10.9, 20.2, 30.6);
            Console.WriteLine(point2);
            // Point<string> point3 = new Point<string>("Ivan", "Piter", "Ira");
            Point<char> point3 = new Point<char>('I', 'p', 'W');
            Console.WriteLine(point3);
            Point<int> point4 = new Point<int>();
            Console.WriteLine(point4);
            point3.Reset();
            Console.WriteLine(point3);
            Console.WriteLine("--------------------------------");
            Point<int>.radius = 10;// PointInt
            Console.WriteLine(point);
            Console.WriteLine(point2);
            Console.WriteLine(point3);
            Console.WriteLine(point4);

        }
        static void Test2()
        {
            Point<int>.radius = 100;
            Point<double>.radius = 200;
            Circle k1 = new Circle();
            Circle k2 = new Circle(10, 20, 30);
            Console.WriteLine(k1);
            Console.WriteLine(k2);

        }
        static void Test3()
        {
            Point<int>.radius = 100;
            Point<double>.radius = 200;
            Circle<int> k1 = new Circle<int>();
            Circle<double> k2 = new Circle<double>(10.90, 20.330, 30.33);
            Console.WriteLine(k1);
            Console.WriteLine(k2);
        }
        static void Test4()
        {
            Point<int>.radius = 100;
            Point<double>.radius = 200;
            Kolo<double>.Point<int>.radius = 300;

            Kolo<int> k1 = new Kolo<int>();
            Kolo<double> k2 = new Kolo<double>(10.90, 20.330, 30.33);
            Console.WriteLine(k1);
            Console.WriteLine(k2);

            Kolo<double>.Point<int> point = new Kolo<double>.Point<int>
                (50, 60, 70);
            Console.WriteLine(point);

        }
        static void Test5()
        {
            int a = 10, b = 20;
            Console.WriteLine($"a={a} b={b}");
            Element.Swap(ref a, ref b);
            Console.WriteLine($"a={a} b={b}");
            int[] masInt = { 10, -20, 36, 56, 54, 36, 94, 2 };
            double[] masDouble = { 1.9, -2.0, 3.6, 5.6, 5.4, 3.6, 9.4, 2.0 };
            Console.WriteLine(String.Join("\t", masInt));
            Console.WriteLine(String.Join("\t", masDouble));
            Console.WriteLine($"Max ={Element.Max(masInt)}");
            Console.WriteLine($"Max ={Element.Max(masDouble)}");
        }
        static void Print<T>(T[] mas)
        {
            foreach (var item in mas)
                Console.WriteLine(item);
            Console.WriteLine("----------------------------------");
        }
        static void Test6()
        {
            Student st1 = new Student
            {
                Name = "Wert",
                Bday = new DateTime(1996, 12, 25)
            };
            Console.WriteLine(st1);

            Student[] gr = {
            new Student{ Name = "Wert", Bday = new DateTime(1996, 12, 13)},
            new Student{ Name = "Ivan", Bday = new DateTime(2013, 10, 25)},
            new Student{ Name = "Anna", Bday = new DateTime(1986, 5, 12)},
            new Student{ Name = "Galka", Bday = new DateTime(2015, 1, 16)}
            };

            Print(gr);
            Array.Sort(gr);
            Print(gr);
            Array.Sort(gr, new CompDate());
            Print(gr);
            Array.Sort(gr, (x,y)=>-DateTime.Compare(x.Bday,y.Bday));
            Print(gr);
            Console.WriteLine($"Max ={Element.Max(gr)}");

        }
        static void Main(string[] args)
        {
            // Test1();
            // Test2();
            //Test3();
            // Test4();
            //Test5();
            Test6();
        }
    }
}
