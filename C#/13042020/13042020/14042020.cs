using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042020
{
    class StudCard
    {
        public string serial;
        public int number;
        static int count;
        static StudCard()
        {
            count = 0;
        }
        public override string ToString()
        {
            return $"{serial,3}-{number:d6}";
        }
        public StudCard(string serial)
        {
            if (String.IsNullOrWhiteSpace(serial) || serial.Length != 2)
                this.serial = "00";
            else
                this.serial = serial;

            this.number = ++count;
        }

    }

    class Student : IComparable<Student>
    {
        static Random rnd = new Random();
        public StudCard card;
        public string[] subject { get; set; }
        public int[] marks = new int[5];
        private string lname;
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Fname { get; set; } = "No name";
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - Bday.Year;
                if (Bday.Date > today.AddYears(-age))
                    age--;
                return age;
            }

        }
        public string PIB
        {
            get { return $"{Lname,10} {Fname,8}"; }
        }
        //public DateTime Bday;
        public DateTime Bday { get; set; } = DateTime.Now;

        void SetMark()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = rnd.Next(1, 13);
            }
        }
        public Student(string lname, string fname, DateTime bday, StudCard Card)
        {
            //this.PIB = PIB;
            Lname = lname;
            Fname = fname;
            Bday = bday;
            card = Card;
            SetMark();
        }
        public Student(string lname, string fname)
        {
            Lname = lname;
            Fname = fname;
            SetMark();
        }
        public Student(Student nst)
        {
            Lname = nst.Lname;
            Fname = nst.Fname;
            Bday = nst.Bday;
            card = new StudCard(nst.card.serial);
            SetMark();
        }
        public override string ToString()
        {
            return $"{PIB} {Age,2} " +
                $"{Bday.ToShortDateString(),10} {card}" +
                $"  {string.Join(", ", subject),20}" +
                $"  {string.Join(", ", marks)}";
        }
        public int CompareTo(Student obj)
        {
            return String.Compare(Lname, obj?.Lname);
        }

    }


    class Program
    {
        static List<Student> list = new List<Student> {
             new Student("Ivanenko", "Iwan",new DateTime(2002, 04, 30), new StudCard("BM")) { subject =new [] {"matem","c++","pascal"} },
             new Student("Petrenko", "Petro",new DateTime(1996, 04, 14), new StudCard("BM")){ subject =new [] {"phizik","c++","c--"} },
             new Student("Isack", "Inna",new DateTime(1993, 06, 23), new StudCard("BM")){ subject =new [] {"matem","java","pascal"} },
             new Student("Petruk", "Anna",new DateTime(2010, 09, 18), new StudCard("BM")){ subject =new [] {"matem","php","c"} },
             new Student("Ivanenko", "Iagor",new DateTime(1982, 04, 30), new StudCard("BM")) { subject =new [] {"matem","c++","pascal"} },
            };


        static void Test1()
        {
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            //>01/01/2000 && c++
            var sql = from st in list
                      from dis in st.subject
                      where dis == "c++"
                      where st.Bday > new DateTime(2000, 1, 1)
                      select st;
            Console.WriteLine(string.Join("\n", sql));
            Console.WriteLine("----------------------------------");
            var sql2 = list.SelectMany(
                st => st.subject,
                (s, d) => new { Stud = s, Sub = d }
                ).Where(ast => ast.Stud.Bday > new DateTime(2000, 1, 1)
                && ast.Sub == "c++"
                ).Select(stold => stold.Stud);
            Console.WriteLine(string.Join("\n", sql2));
            Console.WriteLine("----------------------------------");

            //from dis in st.subject
            //where dis == "c++"
            //where st.Bday > new DateTime(2000, 1, 1)
            //select st;
            //  Console.WriteLine(string.Join("\n", sql));
            // Console.WriteLine("----------------------------------");

        }
        static void Test0()
        {
            int[] arr = { 5, 23, 30, 40, 50, -9, 2 };

            var sql = arr.Select(a => a);
            Console.WriteLine(string.Join(" ", sql));
            arr[1] = 999;
            Console.WriteLine(string.Join(" ", sql));

            var sqlarr = arr.Select(a => a).ToArray();

            arr[2] = 555;
            Console.WriteLine(string.Join(" ", sqlarr));
            Console.WriteLine(string.Join(" ", sql));

            Console.WriteLine(arr.Sum());

        }

        static void TestSelectMany()
        {
            // int[] a = { 2,3,4,5,6,7,8,9 };
            int[] a = Enumerable.Range(2, 8).ToArray();
            // int[] b = { 1,2,3,4,5,6,7,8,9 };
            int[] b = Enumerable.Range(1, 9).ToArray();
            var table = from x in a
                        from y in b
                        select $"{x} x {y} = {x * y,2}";
            // Console.WriteLine(string.Join("\n", table));
            Console.WriteLine("----------------------------------");
            table = a.SelectMany(
                ela => b,
                (x, y) => $"{x} x {y} = {x * y,2}"
                );
            //  Console.WriteLine(string.Join("\n", table));
            Console.WriteLine("----------------------------------");
            table = Enumerable.Range(2, 8).SelectMany(
              ela => Enumerable.Range(1, 9),
              (x, y) => $"{x} x {y} = {x * y,2}"
              );
            Console.WriteLine(string.Join("\n", table));
            Console.WriteLine("----------------------------------");
        }
        static void TestSelect()
        {
            int[] numb = { 5, 23, 30, 40, 50, -9, 2 };
            var qn1 = from pi in numb
                      select pi / 5.0;
            Console.WriteLine(string.Join("\t", qn1));
            Console.WriteLine("----------------------------------");
            qn1 = numb.Select(x => x / 5.0);
            Console.WriteLine(string.Join("\t", qn1));
            Console.WriteLine("----------------------------------");
            var qnarr = numb.Select((x, i) => 1.0 * x / (x + i)).ToArray();
            Console.WriteLine(string.Join("\t", qnarr));
            Console.WriteLine("----------------------------------");

            var pib = list.Select(x => x.PIB);
            Console.WriteLine(string.Join("\n", pib));
            Console.WriteLine("----------------------------------");
            pib = list.Select(x => x.Lname + " " + x.Fname);
            Console.WriteLine(string.Join("\n", pib));
            Console.WriteLine("----------------------------------");

            int[] num = { 1, 0, 3, 5, 6, 7, 4 };
            string[] textarr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            pib = num.Select(x => textarr[x]);
            Console.WriteLine(string.Join("\t", pib));
            Console.WriteLine("----------------------------------");

            var gr = num.Select(x => new Student(textarr[x], "" + x));
            Console.WriteLine(string.Join("\n", gr));
            Console.WriteLine("----------------------------------");

            gr = num.Select((x, i) => new Student(textarr[x], "" + i + " " + x));
            Console.WriteLine(string.Join("\n", gr));
            Console.WriteLine("----------------------------------");

        }

        static void TestWhere()
        {
            string[] arr = { "Ivanenko", "Petrenko","Ivasyk",
                "Stepanenko","isack"};

            var pib = new List<string>();
            foreach (var item in arr)
                if (item[0] == 'I')
                    pib.Add(item);
            Console.WriteLine(string.Join("\n", pib));
            Console.WriteLine("----------------------------------");

            var q1 = from pi in arr
                     where pi[0] == 'I'
                     select pi;
            Console.WriteLine(string.Join("\n", q1));
            Console.WriteLine("----------------------------------");
            q1 = from pi in arr
                 where pi.ToUpper().StartsWith("I")
                 select pi;
            Console.WriteLine(string.Join("\n", q1));
            Console.WriteLine("----------------------------------");

            q1 = arr.Where(x => x.ToUpper().StartsWith("I"));
            Console.WriteLine(string.Join("\n", q1));
            Console.WriteLine("----------------------------------");

            int[] numb = { 5, 23, 30, 40, 50, -9, 2 };
            var qn1 = from pi in numb
                      where pi > 10
                      select pi;
            Console.WriteLine(string.Join("\t", qn1));
            Console.WriteLine("----------------------------------");
            qn1 = numb.Where(x => x > 10);
            Console.WriteLine(string.Join("\t", qn1));
            Console.WriteLine("----------------------------------");

            qn1 = numb.Where((x, i) => x > 0 && (i & 1) == 1);
            Console.WriteLine(string.Join("\t", qn1));
            Console.WriteLine("----------------------------------");



            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            var q2 = from st in list
                     where st.Lname.EndsWith("ko")
                     select st;
            Console.WriteLine(string.Join("\n", q2));
            Console.WriteLine("----------------------------------");
            q2 = list.Where(st => st.Lname.EndsWith("ko"));
            Console.WriteLine(string.Join("\n", q2));
            Console.WriteLine("----------------------------------");

            // pib len>5 bday <01/01/2000
            q2 = from st in list
                 where st.Lname.Length > 5 && st.Bday < new DateTime(2000, 1, 1)
                 select st;
            Console.WriteLine(string.Join("\n", q2));
            Console.WriteLine("----------------------------------");
            q2 = from st in list
                 where st.Lname.Length > 5
                 where st.Bday < new DateTime(2000, 1, 1)
                 select st;
            Console.WriteLine(string.Join("\n", q2));
            Console.WriteLine("----------------------------------");
            q2 = list.Where(st => st.Lname.Length > 5 &&
                            st.Bday < new DateTime(2000, 1, 1));
            Console.WriteLine(string.Join("\n", q2));
            Console.WriteLine("----------------------------------");


        }
        static void TestSort()
        {
            int[] numb = { 5, 23, 30, 40, 50, -9, 2 };
            //var q1 = from el in numb
            //         orderby el //ascending
            //         select el;
            var q1 = numb.OrderBy(x => x);
            Console.WriteLine(string.Join("\t", q1));
            Console.WriteLine("----------------------------------");
            //q1 = from el in numb
            //         orderby el descending
            //         select el;
            q1 = numb.OrderByDescending(x => x);
            Console.WriteLine(string.Join("\t", q1));
            Console.WriteLine("----------------------------------");
            q1 = from el in numb
                 orderby -el
                 select el;
            q1 = numb.OrderBy(x => -x);
            // Console.WriteLine(string.Join("\t", q1));
            // Console.WriteLine("----------------------------------");
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            var qlist = from st in list
                        orderby st
                        select st;
            qlist = list.OrderBy(x => x);
            Console.WriteLine(string.Join("\n", qlist));
            Console.WriteLine("----------------------------------");
            qlist = from st in list
                    orderby st descending
                    select st;
            qlist = list.OrderByDescending(x => x);
            //Console.WriteLine(string.Join("\n", qlist));
            // Console.WriteLine("----------------------------------");
            qlist = from st in list
                    orderby st.Lname, st.Fname
                    select st;
            qlist = list.OrderBy(x => x.Lname).ThenBy(x => x.Fname);
            Console.WriteLine(string.Join("\n", qlist));
            Console.WriteLine("----------------------------------");

            qlist = from st in list
                    orderby st.Lname descending, st.Fname ascending
                    select st;
            qlist = list.OrderByDescending(x => x.Lname).ThenBy(x => x.Fname);
            Console.WriteLine(string.Join("\n", qlist));
            Console.WriteLine("----------------------------------");

        }
        static void TestTake()
        {
            //50
            int[] numb = { 5, 23, 30, 40, 50, -9, 2 };
            //  Console.WriteLine(string.Join("\t", numb.OrderByDescending(x=>x)));
            var q1 = (from el in numb
                      orderby el descending
                      select el).Take(3);
            // var q1 = numb.OrderByDescending(x => x).Take(3);
            //  Console.WriteLine(string.Join("\t", q1));
            //  Console.WriteLine("----------------------------------");

            q1 = numb.TakeWhile(x => x > 0);
            //  Console.WriteLine(string.Join("\t", q1));
            //  Console.WriteLine("----------------------------------");

            q1 = numb.OrderByDescending(x => x).Skip(3);
            //  Console.WriteLine(string.Join("\t", q1));
            // Console.WriteLine("----------------------------------");

            q1 = numb.SkipWhile(x => x > 0);
            //  Console.WriteLine(string.Join("\t", q1));
            // Console.WriteLine("----------------------------------");
            //знайти 4,5,6 місце
            q1 = numb.OrderByDescending(x => x).Skip(3).Take(3);
            //  Console.WriteLine(string.Join("\t", q1));
            Console.WriteLine("----------------------------------");
            Console.WriteLine(string.Join("\n", list));
            // 1. студенти які отримали сер. бал >=6
            Console.WriteLine("----------------------------------");
            var qq1 = list.Where(x => x.marks.Average() >= 6);//1
            Console.WriteLine(string.Join("\n", qq1));
            Console.WriteLine("----------------------------------");
            // 2. Три перші студенти по рейтингу отримують стипендію
            qq1 = list.Where(x => x.marks.Average() >= 6)
                .OrderByDescending(x => x.marks.Average()).Take(3);
            Console.WriteLine(string.Join("\n", qq1));
            Console.WriteLine("----------------------------------");
            // 3. Студенти які не отримали стипендію
            qq1 = list.Where(x => x.marks.Average() >= 6)
                .OrderByDescending(x => x.marks.Average()).Skip(3);
            Console.WriteLine(string.Join("\n", qq1));
            Console.WriteLine("----------------------------------");

            //  Console.WriteLine(string.Join("\n", qq1));
            //   var qqq1 = list.Average(x=>x.Age);
            //   Console.WriteLine(qqq1);
        }
        static void TestGroup()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            var q1 = from st in list
                     group st by st.Lname?.First() into gr
                     //group st by st.Lname into gr
                     select new { Letter = gr.Key, Student = gr };
            foreach (var item in q1)
            {
                Console.WriteLine(item.Letter);
                Console.WriteLine(string.Join("\n", item.Student));
            }
            Console.WriteLine("----------------------------------");

            q1 = list.GroupBy(st => st.Lname?.First())
                .Select(gr => new { Letter = gr.Key, Student = gr });
            foreach (var item in q1)
            {
                Console.WriteLine(item.Letter);
                Console.WriteLine(string.Join("\n", item.Student));
            }
            Console.WriteLine("----------------------------------");
            // I 3
            // P 2
            var q2 = list.GroupBy(st => st.Lname?.First())
               .Select(gr => new { Letter = gr.Key, CountSt = gr.Count() });
            foreach (var item in q2)
            {
                Console.WriteLine(item.Letter + ": " + item.CountSt);
            }
            Console.WriteLine("----------------------------------");
            var q3 = list.GroupBy(st => st.Lname?.First())
             .Select(gr => new
             {
                 Letter = gr.Key,
                 CountSt = gr.Count(),
                 Student = gr
             });
            foreach (var item in q3)
            {
                Console.WriteLine(item.Letter + ": " + item.CountSt);
                Console.WriteLine(string.Join("\n", item.Student));
            }
            Console.WriteLine("----------------------------------");
        }

        static void TestSet()
        {
            int[] numb = { 5, 20, 30, 2, -9, 23, 30, 40, 50, -9, 2 };
            Console.WriteLine(string.Join("\t", numb));
            var q1 = (from el in numb
                      select el).Distinct();
            q1 = numb.Distinct();
            Console.WriteLine(string.Join("\t", q1));
            Console.WriteLine("----------------------------------");
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            var gr1 = list.Select(st => st.Lname).Distinct();
            Console.WriteLine(string.Join("\n", gr1));
            Console.WriteLine("----------------------------------");
            int[] a = { 1, 2, 3, 4, 5, 6, 7 };
            int[] b = { 5, 6, 7, 8, 9, 10, 11 };
            var un1 = a.Union(b);
            Console.WriteLine(string.Join("\t", un1));
            var inter1 = a.Intersect(b);
            Console.WriteLine(string.Join("\t", inter1));
            var except1 = a.Except(b);
            Console.WriteLine(string.Join("\t", except1));

            var gr2 = list.Where(st => st.Lname.EndsWith("ko"));
            Console.WriteLine(string.Join("\n", gr2));
            Console.WriteLine("----------------------------------");
            var gr3 = list.Where(st => st.Lname.StartsWith("P"));
            Console.WriteLine(string.Join("\n", gr3));
            Console.WriteLine("----------------------------------");

            var ungr = gr2.Union(gr3);
            Console.WriteLine(string.Join("\n", ungr));
            Console.WriteLine("----------------------------------");

            var inter2 = gr2.Intersect(gr3);
            Console.WriteLine(string.Join("\n", inter2));
            Console.WriteLine("----------------------------------");

            var except2 = gr2.Except(gr3);
            Console.WriteLine(string.Join("\n", except2));
            Console.WriteLine("----------------------------------");
        }

        static void TestENumRange()
        {
            var q1 = Enumerable.Range(-5, 11);
            Console.WriteLine(string.Join("\t", q1));
            Console.WriteLine("----------------------------------");
            var q2 = Enumerable.Repeat(-5, 11);
            Console.WriteLine(string.Join("\t", q2));
            Console.WriteLine("----------------------------------");

            var st = Enumerable.Empty<Student>();
            Console.WriteLine(string.Join("\t", st));
            Console.WriteLine("----------------------------------");
        }
        static void TestFirst()
        {
            int[] b = { 5, 6, 7, -8, 9, 10, -11 };
            int el = b.First();
            Console.WriteLine(el);
            int elf = b.First(x => x < 0);
            Console.WriteLine(elf);
            //error
            //  int elz = b.First(x => x == 0);
            //  Console.WriteLine(elz);

            int[] c = { 5, 6, 7, 8, 9, 10, 11 };
            elf = c.FirstOrDefault(x => x < 0);
            Console.WriteLine(elf);

            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            Student st = list.FirstOrDefault(s => s.Lname.StartsWith("Pet"));
            Console.WriteLine(st);
            Console.WriteLine("----------------------------------");
            //Last   LastOrDefault
            int[] d = { 5, 6, 7, 8, -9, 10, 11 };
            int[] one = { 10 };
            elf = one.Single();
            Console.WriteLine(elf);
            elf = d.Single(x => x < 0);
            Console.WriteLine(elf);
            //SingleOrDefault
            Console.WriteLine(d.ElementAt(1));
            Console.WriteLine(d.ElementAtOrDefault(100));
            
            int[] dd = { 5, -6, 7, 8, -9, 10, -11 };
            Console.WriteLine(dd.Count()); //7
            Console.WriteLine(dd.Count(x=>x<0)); //3
            Console.WriteLine(dd.Sum()); //4
            Console.WriteLine(dd.Sum(x => x < 0?1:0)); //3
            Console.WriteLine(dd.Sum(x => x < 0?x:0)); //-26
            Console.WriteLine(dd.Sum(x => x > 0?x:0)); //30
            Console.WriteLine(dd.Sum(x => x == 0?1:0)); //0



        }

        static void Main(string[] args)
        {
            // Test0();
            // TestWhere();
            // TestSelect();
            // Test1();
            // TestSelectMany();
            //TestSort();

            // TestTake();
            // TestGroup();
            // TestSet();
            //    TestENumRange();
            TestFirst();
        }
    }
}
