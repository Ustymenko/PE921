using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28032020
{
    class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"({X,2};{Y,2})";
        }

        public static Point operator +(Point A, Point B)
        {
            // Point temp = new Point { X = A.X + B.X, Y = A.Y + B.Y };
            //return temp;
            return new Point { X = A.X + B.X, Y = A.Y + B.Y };
        }
        public static Point operator +(Point A, int B)
        {
            return new Point { X = A.X + B, Y = A.Y + B };
        }
        public static Point operator +(int B, Point A)
        {
            return A + B;
           // return new Point { X = A.X + B, Y = A.Y + B };
        }
        public static Point operator +(Point A)
        {
            return new Point { X = A.X , Y = A.Y };
        }
        public static Point operator -(Point A)
        {
            return new Point { X = -A.X, Y = -A.Y };
        }
        public static Point operator ++(Point A)
        {
            return new Point {
                X = A.X+1,
                Y = A.Y+1
            };
        }

        public override bool Equals(object obj)
        {
           if (obj is null)
                return false;
           if (obj is Point p)
                return (X == p.X) && (Y == p.Y);
           return false;
        }

        public bool Equals(Point other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Point A, Point B)
        {
            // return (A.X==B.X)&&(A.Y == B.Y) ;
            return A.Equals(B);
        }
        public static bool operator <(Point A, Point B)
        {
            
            return A.Equals(B);
        }
        public static bool operator >(Point A, Point B)
        {

            return A.Equals(B);
        }
        public static bool operator !=(Point A, Point B)
        {
           // return (A.X != B.X) || (A.Y != B.Y);
            return !(A== B);
        }

    }

    struct SPoint {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"({X,2};{Y,2})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point { X = 10, Y = 20 };
            Point p2 = new Point { X = 30, Y = 40 };
            Point p3 = p1 + p2;
            Console.WriteLine($"{p1}+{p2}={p3}");
            
            int a = 10;
            p3 = p1 + a;
            Console.WriteLine($"{p1}+{a}={p3}");
            p3 = a + p1;
            Console.WriteLine($"{a}+{p1}={p3}");

            p3 =  +p1;
            Console.WriteLine($"{p3}");
            p3 = -p1;
            Console.WriteLine($"{p3}");

            //int x = 10;
            //int y = ++x;
            //Console.WriteLine($"x={x} y={y}"); // 11 11 | 

            //x = 10;
            //y = x++;
            //Console.WriteLine($"x={x} y={y}"); // 11 10 | 

            p1 = new Point { X = 10, Y = 20 };
            p3 = ++p1;
            Console.WriteLine($"{p1}"); //11 21
            Console.WriteLine($"{p3}"); //11 21

            p1 = new Point { X = 10, Y = 20 };
            p3 = p1++;
            Console.WriteLine($"{p1}"); //11 21
            Console.WriteLine($"{p3}"); //10 20

            p1 = new Point { X = 10, Y = 20 };
            p2 = new Point { X = 10, Y = 20 };
            p3 = p2;
            Console.WriteLine($"ReferenceEquals(p1,p2) ={ ReferenceEquals(p1,p2)}"); //11 21
            Console.WriteLine($"ReferenceEquals(p3,p2) ={ ReferenceEquals(p3,p2)}"); //11 21

            SPoint sp1 = new SPoint { X = 10, Y = 20 };
            SPoint sp2 = new SPoint { X = 10, Y = 20 };
            Console.WriteLine($"ReferenceEquals(sp1,sp2) ={ ReferenceEquals(sp1, sp2)}"); 
            Console.WriteLine($"ReferenceEquals(sp1,sp1) ={ ReferenceEquals(sp1, sp1)}");

            p1 = new Point { X = 10, Y = 20 };
            p2 = new Point { X = 10, Y = 20 };

            Console.WriteLine($"p1.Equals(p1,p2) ={ p1.Equals(p2)}");
            Console.WriteLine($"Equals(p1,p2) ={ Equals(p1,p2)}");
            Console.WriteLine($"Equals(sp1,sp2) ={ Equals(sp1, sp2)}");


        }
    }
}
