using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06042020
{
    static class ListExten
    {
        public static void Print<T>(this List<T> list, string name, string rn = "\n")
        {
            Console.WriteLine(name);
            Console.WriteLine(new string('-', 20));
            foreach (var item in list)
            {
                Console.Write(item + rn);
            }
            Console.WriteLine();

        }
        public static void Print<T>(this LinkedList<T> list, string name, string rn = "\n")
        {
            Console.WriteLine(name);
            Console.WriteLine(new string('-', 20));
            foreach (var item in list)
            {
                Console.Write(item + rn);
            }
            Console.WriteLine();

        }
    }

    class Student : IComparable<Student>, IEquatable<Student>
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }
        public int CompareTo(Student other)
        {
            return String.Compare(Name, other?.Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student other)
        {
            return other != null &&
                   Name == other.Name &&
                   Bday == other.Bday;
        }

        public override int GetHashCode()
        {
            int hashCode = -1892292941;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Bday.GetHashCode();
            return hashCode;
        }

        //public bool Equals(Student other)
        //{
        //    //return this.ToString() == other?.ToString();
        //    return

        //}

        public override string ToString()
        {
            return $"|{Name,-15}|{Bday.ToShortDateString(),12}|";
        }

        public static bool operator ==(Student left, Student right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }
    }
    class CompDate : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x is null || y is null) return 0;
            if (x is null ) return -1;
            if (y is null ) return 1;
            return DateTime.Compare(x.Bday, y.Bday);
        }
    }
    class Program
    {
        static void Test1()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int> { 10, 20, 30, 40, 50 };
            List<double> list3 = new List<double> { 1.8, 2.0, 3.8, 4.5, 5.0 };
            int el = 0;
            int pos = list2.BinarySearch(el);
            if (pos > -1)
                Console.WriteLine(pos);
            else
            {
                list2.Insert(Math.Abs(pos) - 1, el);
                Console.WriteLine($"pos ={Math.Abs(pos) - 1}");
            }
            list2.Print("list2", "\t");
            list1.Add(11);
            list1.AddRange(list2);
            int[] arr = { 9, 7, 5, };
            list1.AddRange(arr);
            // list1.Add(145.99);
            list1.Print("list1", "\t");
            list1.Sort();
            list1.Print("sort list1", "\t");
            list1.Sort((a, b) => -a.CompareTo(b));
            //list1.Sort((a,b)=>b.CompareTo(a));
            list1.Print("sort revers list1", "\t");


            list2.Insert(3, 555);
            list2.Remove(50);
            list2.RemoveAt(0);
            list2.Print("list2", "\t");


            list3.Print("list3", "\t");

            List<Student> group = new List<Student> {
                null,
                new Student{ Name = "Mark", Bday = new DateTime(1996, 12, 13)},
                new Student{ Name = "Ivan", Bday = new DateTime(2013, 10, 25)},
                new Student{ Name = "Anna", Bday = new DateTime(1986, 5, 12)},
                new Student{ Name = "Oleg", Bday = new DateTime(2015, 1, 16)}
            };
            // group.Print("group");
            // group.Sort();
            // group.Print("sort group");
            // group.Sort(new CompDate());
            // group.Print("sort date group");
            //// group.Sort( (a,b)=>  -a.Bday.CompareTo(b.Bday));
            // group.Sort( (a,b)=> (a is null || b is null)?
            //                     -1:
            //                     -DateTime.Compare(a.Bday,b.Bday));
            // group.Print("sort date reverse group");

        }
        static void Test2()
        {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedListNode<int> node;
            node=list1.AddLast(10);
            //list1.AddFirst(5);
            node=list1.AddFirst(5);
            list1.Print("list1", "\t");
            //5 10
            list1.AddAfter(node,20);
            list1.Print("list1", "\t");

            LinkedListNode<int> node2 = new LinkedListNode<int>(50);
            list1.AddAfter(node, node2);
            list1.Print("list1", "\t");
            Console.WriteLine(node.Next.Next.Value);
            Console.WriteLine(node2.Next.Next.Value);

            LinkedListNode<int> node3 = node2.Next;
            Console.WriteLine(node3.Value);
            Console.WriteLine(node3.Previous.Previous.Value);


            Student stud = new Student { Name = "Anna", Bday = new DateTime(1986, 5, 12) };
            List<Student> group = new List<Student> {
                null,
                new Student{ Name = "Mark", Bday = new DateTime(1996, 12, 13)},
                new Student{ Name = "Ivan", Bday = new DateTime(2013, 10, 25)},
                stud,
                new Student{ Name = "Oleg", Bday = new DateTime(2015, 1, 16)}
            };
            LinkedList<Student> listst = new LinkedList<Student>(group);
            listst.Print("listst");
            //var nodefind=listst.Find(new Student { Name = "Anna", Bday = new DateTime(1986, 5, 12) });
           // var nodefind=listst.Find(stud);
            var nodefind=listst.Find(new Student { Name = "Ivan", Bday = new DateTime(2013, 10, 25) });
            if (nodefind is null )
                Console.WriteLine("HEMA");
            else
                Console.WriteLine($"E {nodefind.Value}");

            var col=listst.OrderBy(x => x).ToList();
            LinkedList<Student> listsort = new LinkedList<Student>(col);
            listsort.Print("listst");
            //foreach (var item in col)
            //{
            //    Console.WriteLine(item);
            //}
            IEnumerable<Student> col2 = listst.OrderBy(x => x, new CompDate());
            //ToList();
            LinkedList<Student> listsort2 = new LinkedList<Student>(col2);
            listsort2.Print("listst2");

        }

        static void Main(string[] args)
        {
           // Test1();
            Test2();
        }

    }
}
