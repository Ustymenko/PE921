using ClassLibraryTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21042020
{
    class WinApi
    {
        [DllImport("user32.dll")]
        public static extern int MessageBoxA(
            IntPtr ptr, string text, string caption, uint type);

        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int Message(
               IntPtr ptr, string text, string caption, uint type);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "MessageBox")]
        public static extern int Message2(
              IntPtr ptr, string text, string caption, uint type);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, int i, double d);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, int i, string s);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, __arglist);

        [DllImport("advapi32.dll")]
        public static extern bool GetUserName(StringBuilder name, ref int len);

        [DllImport("MyCalc.dll")]
        public static extern double Add(double a, double b);
        [DllImport("MyCalc.dll")]
        public static extern double Sub(double a, double b);
        [DllImport("MyCalc.dll")]
        public static extern double Mult(double a, double b);
        [DllImport("MyCalc.dll")]
        public static extern double Div(double a, double b);

    }

    class Program
    {
        static void TestLib()
        {
            Student st = new Student { Name = "Piter" };
            Console.WriteLine(st);
        }
        static void TestLibWinApi()
        {
            //  WinApi.MessageBoxA(IntPtr.Zero,"Привіт", "Повідомлення",0);
            //   WinApi.Message(IntPtr.Zero,"hello", "Повідомлення",0);
            //  WinApi.Message2(IntPtr.Zero,"hello", "Повідомлення",0);

            //WinApi.printf("a = %i, d = %lf\n",123,69.99);
            //WinApi.printf("a = %i, d = %s\n",123,"text");
            //WinApi.printf(" %i * %i = %i\n",__arglist(5,8,5*8));
            //int len = 20;
            //StringBuilder user = new StringBuilder(len);
            //WinApi.GetUserName(user, ref len);
            //WinApi.printf("user name:  %s \n", __arglist(user.ToString()));
            //Console.WriteLine("user name: " + user);

            double a = 10;
            double b = 0;
            Console.WriteLine($"{a}+{b}={WinApi.Add(a,b)}");
            Console.WriteLine($"{a}-{b}={WinApi.Sub(a,b)}");
            Console.WriteLine($"{a}*{b}={WinApi.Mult(a,b)}");
            Console.WriteLine($"{a}/{b}={WinApi.Div(a,b)}");

        }

        static void Test() {
            string text = "Іван - 10.04.1989\n " +
                    "Петро - 12.04.1989\n " +
                    "Григорій - 09.04.1989";
            string token = @"\d{1,2}(\.|-)\d{1,2}(\.|-)\d{2,4}";
            Regex regex = new Regex(@"\d{1,2}(\.|-)\d{1,2}(\.|-)\d{2,4}",
                RegexOptions.IgnoreCase | RegexOptions.Multiline);

            Match match = regex.Match(text);
            while (match.Success) {
                Console.WriteLine($"{match.Value} {match.Index}");
                match = match.NextMatch();
            }

            MatchCollection ms = regex.Matches(text);
            Console.WriteLine($"Count={ms.Count} ");
            foreach (Match item in ms)
                 Console.WriteLine($"{item.Value} {item.Index}");

            string newtext = regex.Replace(text,"15.04.1989");
            Console.WriteLine(newtext);

           // string newtext2 = Regex.Replace(text, "1989","2000");
            string newtext2 = Regex.Replace(text, token, "15.04.2010");
            Console.WriteLine(newtext2);


            string tok = @"(\d{1,2})\.(\d{1,2})\.(\d{2,4})";
            Regex regex1 = new Regex(tok,
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match match1 = regex1.Match(text);
            string nntext = regex1.Replace(text, "$3-$2-$1");
            Console.WriteLine(nntext);

            MatchCollection ms1 = regex1.Matches(text);
            Console.WriteLine($"Count={ms1.Count} ");
            foreach (Match item in ms1)
            {
                Console.WriteLine($"{item.Value} {item.Index}");
                Console.WriteLine($"Day:  {item.Groups[1].Value,5}");
                Console.WriteLine($"Month:{item.Groups[2].Value,5}");
                Console.WriteLine($"Year: {item.Groups[3].Value,5}");
            }

            string paternphone = @"^(\d{2})-(\d{2})-(\d{2})$";

            string phone = "12-36-59";
            var reg = new Regex(paternphone);
            if (reg.IsMatch(phone))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
           // [a-zA-Z]
         //   [а-яіїє]

        }
        static void Main(string[] args)
        {
            //TestLib();
            //  TestLibWinApi();
            Test();
            Console.ReadKey();
        }
    }
}
