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

    class Student
    {
        public StudCard card;
        public string[] subject { get; set; }
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
            get { return $"{Lname,15} {Fname,12}"; }
        }
        //public DateTime Bday;
        public DateTime Bday { get; set; } = DateTime.Now;
        public Student(string lname, string fname, DateTime bday, StudCard Card)
        {
            //this.PIB = PIB;
            Lname = lname;
            Fname = fname;
            Bday = bday;
            card = Card;
        }
        public Student(string lname, string fname)
        {
            Lname = lname;
            Fname = fname;
        }
        public Student(Student nst)
        {
            Lname = nst.Lname;
            Fname = nst.Fname;
            Bday = nst.Bday;
            card = new StudCard(nst.card.serial);

        }
        public override string ToString()
        {
            return $"{PIB} {Age,4} {Bday.ToShortDateString(),20} {card}  {string.Join(", ", subject)}";
        }
    }


    class Program
    {
        static List<Student> list = new List<Student> {
             new Student("Ivanenko", "Ivan",new DateTime(2002, 04, 30), new StudCard("BM")) { subject =new [] {"matem","c++","pascal"} },
             new Student("Petrenko", "Petro",new DateTime(1996, 04, 14), new StudCard("BM")){ subject =new [] {"phizik","c++","c--"} },
             new Student("Isack", "Inna",new DateTime(1993, 06, 23), new StudCard("BM")){ subject =new [] {"matem","java","pascal"} },
             new Student("Petruk", "Anna",new DateTime(2010, 09, 18), new StudCard("BM")){ subject =new [] {"matem","php","c"} },
            };


        static void Test1()
        {
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("----------------------------------");
            //>01/01/2000 && c++
            var sql = from st in list
                        from dis in st.subject
                             where dis =="c++"
                      where st.Bday > new DateTime(2000, 1, 1)
                      select st;
            Console.WriteLine(string.Join("\n", sql));
            Console.WriteLine("----------------------------------");
            var sql2 = list.SelectMany(
                st=>st.subject,
                (s,d)=>new  {Stud=s,Sub=d }
                ).Where(ast=>ast.Stud.Bday > new DateTime(2000, 1, 1)
                && ast.Sub=="c++"
                ).Select(stold=>stold.Stud);
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
            int[] b =Enumerable.Range(1,9).ToArray();
            var table = from x in a
                        from y in b
                        select $"{x} x {y} = {x * y,2}";
           // Console.WriteLine(string.Join("\n", table));
            Console.WriteLine("----------------------------------");
            table = a.SelectMany(
                ela => b,
                (x,y)=> $"{x} x {y} = {x * y,2}"
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


        static void Main(string[] args)
        {
            // Test0();
            // TestWhere();
           // TestSelect();
            Test1();
           // TestSelectMany();

        }
    }
}
