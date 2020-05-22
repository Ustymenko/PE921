using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31032020
{
    static class CountWordsExtensions
    {
        public static int CountWords(this string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;
            return text.Split(" ,.*-+/!)(&^%$#@[]".ToArray(),
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

    }
    static class PrintExtensions
    {
        public static void Print(this ArrayList List, string name = "arrlist")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name?.ToUpper() + ":");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));
            foreach (var item in List)
                Console.Write(item + "\t");
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
        public static void Print(this Stack stack, string name = "stack")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name?.ToUpper() + ":");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));
            foreach (var item in stack)
                Console.Write(item + "\t");
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
        public static void Print(this Queue queue, string name = "queue")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name?.ToUpper() + ":");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));
            foreach (var item in queue)
                Console.Write(item + "\t");
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        } 
        
        public static void Print(this Hashtable table, string name = "queue")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name?.ToUpper() + ":");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));
            foreach (var key in table.Keys)
                Console.WriteLine(key + "\t" + table[key]);
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
    class CompInt : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Int32 a && y is Int32 b)
                return -a.CompareTo(b);
            throw new Exception("object x or object y is not Int32");
        }
    }
    class Program
    {
        static void TestExtension()
        {
            string str = "Несе, Галя , воду hg jgj jh j!";
            Console.WriteLine(str.CountWords());

            //ArrayList al1;
        }
        static void TestArrayList()
        {
            ArrayList al1 = new ArrayList();
            ArrayList al2 = new ArrayList(10);
            ArrayList al3 = new ArrayList(new int[] { 10, 20, 30, 40, 50 });

            // al1.Print("al1"); 
            //  al2.Print("al2");
            al3.Print("al3");
            Console.WriteLine($"Count   ={al3.Count}");
            Console.WriteLine($"Capacity={al3.Capacity}");
            al3.Add(15.99);
            al3.Add(true);
            al3.Add("Piter");
            al3.AddRange(new string[] { "Pen", "Ivan", "Stepan" });
            al3.Insert(6, "It Step");
            al3.InsertRange(6, new int[] { 1, 50, 3, 4, 50 });

            al3.Print("al3");
            Console.WriteLine($"Count   ={al3.Count}");
            Console.WriteLine($"Capacity={al3.Capacity}");
            //for (int i = 0; i < 100; i++)
            //{
            //    al3.Add(i);
            //    Console.WriteLine($"Count   ={al3.Count}");
            //    Console.WriteLine($"Capacity={al3.Capacity}");
            //}
            al3.TrimToSize();
            Console.WriteLine($"Count   ={al3.Count}");
            Console.WriteLine($"Capacity={al3.Capacity}");
            al3.Remove("Ivan");
            al3.RemoveAt(5);
            al3.RemoveRange(10, 5);

            al3.Print("al3");
            Console.WriteLine($"IndexOf   ={al3.IndexOf(50)}");
            Console.WriteLine($"LastIndexOf   ={al3.LastIndexOf(50)}");
            Console.WriteLine(new string('-', 50));
            int val = 100;
            int pos = al3.IndexOf(val);
            while (pos >= 0)
            {
                Console.WriteLine($"IndexOf   ={pos}");
                pos = al3.IndexOf(val, pos + 1);
            }
            Console.WriteLine(new string('-', 50));
            al3.Sort();
            al3.Print("al3");
            al3.Sort(new CompInt());
            al3.Print("al3");
            //public delegate int Comparison<in T>(T x, T y);
        }
        static void TestStack()
        {
            Stack st1 = new Stack();
            Stack st2 = new Stack(50);
            Stack st3 = new Stack(new int[] {10,20,30,40,50 });
            st3.Push(52.36);
            st3.Push("Piter");
            st3.Push(true);
            st3.Print();
            Console.WriteLine($"Top={st3.Peek()}");
            Console.WriteLine($"Pop={st3.Pop()}");
            Console.WriteLine($"Count={st3.Count}");
            st3.Print();
            if (st3.Contains(30))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
            st3.Pop();
            st3.Pop();
            int[] arr = new int[st3.Count];
            st3.CopyTo(arr, 0);
            Console.WriteLine(string.Join(" ",arr));
            st3.Clear();
        }
        static void TestQueue()
         {
            Queue st1 = new Queue();
            Queue st2 = new Queue(50);
            Queue st3 = new Queue(new int[] {10,20,30,40,50 });
          //  st3.Enqueue(52.36);
          //  st3.Enqueue("Piter");
          //  st3.Enqueue(true);
            st3.Print();
            Console.WriteLine($"Head={st3.Peek()}");
            Console.WriteLine($"Pop={st3.Dequeue()}");
            Console.WriteLine($"Count={st3.Count}");
            st3.Print();
            if (st3.Contains(30))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
            //st3.Dequeue();
            //st3.Dequeue();
            int[] arr = new int[st3.Count];
            st3.CopyTo(arr, 0);
            Console.WriteLine(string.Join(" ", arr));
            st3.Clear();
        }
        static void TestHashTable()
        {
            Hashtable table = new Hashtable {
                {1,"Petrenko" },
                {2,"Piter" },
                {3,"Stepanenko" },

            };
            table.Add("Ivan", "Ivanenko");
            table[100]= "Ivanenko";
            table.Print();
            if (table.ContainsKey(2)) {
                Console.WriteLine("Yes");
            }
            if (table.ContainsValue("Piter"))
            {
                Console.WriteLine("Yes");
            }
            table.Remove(1000);
            table.Print();


            //
        }

        static void Main(string[] args)
        {
            //TestExtension();
            //TestArrayList();
            //TestStack();
            // TestQueue();
            TestHashTable();
            Console.ReadKey();
        }
    }
}
