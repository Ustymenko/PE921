using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30032020
{
    // event typdel Event
    delegate void SetExamDeleg(string exam, int m);
    class SchoolBoy
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }
        public override string ToString()
        {
            return $"{Name,15} {Bday.ToShortDateString()}";
        }
        public void SetMark(string exam, int m)
        {
            Console.WriteLine($"{Name,15} Subject{exam,10}:{m,3}");

        }
    }
    class Student
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }
        public override string ToString()
        {
            return $"{Name,15} {Bday.ToShortDateString()}";
        }
        public void SetExam(string exam, int m)
        {
            Console.WriteLine($"{Name,15} EXAM{exam,10}:{m,3}");

        }
    }
    class Teacher
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);
        public event SetExamDeleg Exam;
        public void StartExam(string sub)
        {
            // Exam?.Invoke(sub, rnd.Next(2, 6));
            if (Exam is null)
                Console.WriteLine("not student");
            else
                Exam(sub, rnd.Next(2, 6));
        }

    }
    class Professor
    {
        public Professor(int size = 3)
        {
            masdel = new SetExamDeleg[size];
        }
        static Random rnd = new Random(DateTime.Now.Millisecond);
        SetExamDeleg[] masdel;
        public event SetExamDeleg Exam
        {
            add
            {

                for (int i = 0; i < masdel.Length; i++)
                    if (masdel[i] is null)
                    {
                        masdel[i] = value;
                        return;
                    }
                Console.WriteLine("Немає місць для: " + value.Target);
            }
            remove
            {
                for (int i = 0; i < masdel.Length; i++)
                    if (masdel[i] == value)
                    {
                        masdel[i] = null;
                        return;
                    }
                Console.WriteLine("Такого методу немає");
            }
        }
        public void StartExam(string sub)
        {
            for (int i = 0; i < masdel.Length; i++)
                masdel[i]?.Invoke(sub, rnd.Next(2, 6));
        }

    }
    delegate void ADDMoneyDEL(DateTime d);
    class Bank {
        public event ADDMoneyDEL payout;
        public void Run() {
            DateTime date = DateTime.Now;
            for (int i = 0; i < 365; i++)
            {
                if (date.Day == 1)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine(date);
                    Payout(date);
                }
                date =date.AddDays(1);
                System.Threading.Thread.Sleep(50);
            }
        
        }


        void Payout(DateTime d) {
            payout?.Invoke(d);
        }
    }
    class Client
    {
        public string Name { get; set; }

        public double Deposit { get; set; } //1000
        public double Procent { get; set; } //20%
        double money;
        public double Money { get => money; } //

        public DateTime dayDeposit { get; set; }

        public override string ToString()
        {
            return $"{Name,15}  {Deposit,10} {Procent,5} {dayDeposit.ToShortDateString(),10} {Money,10:F2}";
        }
        public void ADDMoney(DateTime d)
        {
            TimeSpan span = d - dayDeposit;
            int days = span.Days;
            money = Deposit * Procent / 100 / 365 * days;
            Console.WriteLine(this);
        }

        public Client(string N, double m, double p, DateTime date)
        {
            Name = N;
            Deposit = m;
            Procent = p;
            dayDeposit = date;
        }

    }



    class Program
    {
        static void Test2()
        {
            Client client = new Client("Ivan",1000,20,
                new DateTime(2020, 1, 1)
            );
            Client client2 = new Client("Piter", 5005, 10,
                new DateTime(2018, 1, 1)
            );
            Console.WriteLine(client);
            client.ADDMoney(new DateTime(2020, 3, 1));
            Console.WriteLine(client);

            Bank PB = new Bank();
            PB.payout += client.ADDMoney;
            PB.payout += client2.ADDMoney;
            PB.Run();
        //    Console.WriteLine(client);






        }
        static void Test1()
        {
            Student[] group = {
                new Student{ Name="Ivan", Bday = new DateTime(2014,10,6) },
                new Student{ Name="Petro", Bday = new DateTime(1999,5,14) },
                new Student{ Name="Stepan", Bday = new DateTime(1963,9,3) },
                new Student{ Name="Ira", Bday = new DateTime(2013,3,30) }
            };
            //foreach (var item in group)
            //{
            //    Console.WriteLine(item);
            //}
            SchoolBoy boy = new SchoolBoy { Name = "Anna", Bday = new DateTime(2011, 11, 30) };

            Teacher teacher1 = new Teacher();
            teacher1.Exam += group[0].SetExam;
            teacher1.Exam += boy.SetMark;
            teacher1.StartExam("C++");
            Console.WriteLine("-----------------------");
            teacher1.Exam -= boy.SetMark;
            teacher1.StartExam("C++");

            Console.WriteLine("-----------------------");
            Teacher teacher2 = new Teacher();
            foreach (var item in group)
                teacher2.Exam += item.SetExam;
            teacher2.StartExam("C++");

            Console.WriteLine("-----------------------");
            Professor professor = new Professor(2);
            professor.StartExam("Java");
            Console.WriteLine("-----------------------");

            foreach (var item in group)
                professor.Exam += item.SetExam;
            professor.StartExam("C++");
            Console.WriteLine("-----------------------");
            professor.Exam -= boy.SetMark;
            professor.Exam -= group[2].SetExam;
            Console.WriteLine("-----------------------");
            professor.StartExam("C--");
            Console.WriteLine("-----------------------");



        }



        static void Main(string[] args)
        {
           // Test1();
            Test2();
        }
    }
}
