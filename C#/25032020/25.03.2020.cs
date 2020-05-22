using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25032020
{    //MulticastDelegate

    delegate double TypFunc(double a, double b);
    class Calc
    {
        public double Sum(double a, double b)
        {
            Console.WriteLine("+");
            return a + b;
        }
        public double Sub(double a, double b)
        {
            Console.WriteLine("-");
            return a - b;
        }
        public static double Mult(double a, double b)
        {
            Console.WriteLine("*");
            return a * b;
        }
        public double Div(double a, double b)
        {
            Console.WriteLine("/");
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

    }

    enum Sign
    {
        ADD, SUB, MULT, DIV
    }
    class Program
    {
        static void Test1()
        {
            try
            {
                Console.WriteLine("Введіть вираз:  ");
                string formula = Console.ReadLine(); //10 +  60
                string[] str = formula.Split(" +-*/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                double a = Convert.ToDouble(str[0]);
                double b = Convert.ToDouble(str[1]);
                Sign sign;
                if (formula.Contains('+')) sign = Sign.ADD;
                else if (formula.Contains('-')) sign = Sign.SUB;
                else if (formula.Contains('*')) sign = Sign.MULT;
                else sign = Sign.DIV;

                Calc calc = new Calc();
                TypFunc func = null;
                switch (sign)
                {
                    case Sign.ADD:
                        func = calc.Sum;
                        break;
                    case Sign.SUB:
                        func = new TypFunc(calc.Sub);
                        break;
                    case Sign.MULT:
                        func = Calc.Mult;
                        break;
                    case Sign.DIV:
                        func = calc.Div;
                        break;
                }

                Console.WriteLine($"{a} {sign} {b}={func?.Invoke(a, b)}");
                if (func != null)
                {
                    Console.WriteLine($"{a} {sign} {b}={func(a, b)}");
                }
                else
                    Console.WriteLine("Error");
            }
            catch (Exception EX)
            {
                Console.WriteLine("Error" + EX.Message);
            }

        }
        delegate void FuncVoid();

        static void Hello() { Console.WriteLine("Hello"); }
        static void Hi() { Console.WriteLine("Hi"); }
        static void Bye() { Console.WriteLine("Bye"); }
        static void Test2()
        {
            FuncVoid func = Hello;
            func.Invoke();
            func = Bye;
            func();

            func = Hello;
            func += Hi;
            func += Bye;
            func();

        }
        static void Test3()
        {
            Calc calc = new Calc();
            TypFunc func = calc.Sum;
            func+= new TypFunc(calc.Sub);
            func += Calc.Mult;
           // func += new TypFunc(calc.Sub)  + new TypFunc(calc.Sub);
           // func =(TypFunc) Delegate.Combine(func, new TypFunc( calc.Div));

            double a = 10, b = 20;
            Console.WriteLine(func(a,b));
            Console.WriteLine("-----------------------------");
            func += Calc.Mult;
            foreach (TypFunc item in func.GetInvocationList())
            {
                Console.WriteLine(item.Method.Name +"="+ item(a, b));
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine(func(a, b));


        }

        static void Main(string[] args)
        {
            //Test1();
           // Test2();
            Test3();
        }
    }
}
