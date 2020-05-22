using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06042020
{

    public delegate void method();
    delegate method methodDo();
    class Program
    {
        public static method Red()  //  функція вертає делегат
        {
            Console.WriteLine("static method Red()");
            return () => Console.ForegroundColor = ConsoleColor.Red;
        }

        // після цього має викликатись функція з делегату method, наприклад оця

        public static void Method1()
        {
          //  Console.Clear();
            Console.WriteLine("static void Method1()");
        }

        // я не знаю як тут написати щоб викликалась лямбда попередня.
        // думала зробити через Action<method> але так теж не виходить
        static void Main(string[] args)
        {
            Run();
        }
        // меню
        public static void Run()
        {
            string[] items = { "Rectangle", "Romb", "Triangle", "Trapesium", "Multirectangle", "Выход" };
            method[] methods = new method[] { Method1 };
            string[] colors = { "Red" };// "Green", "Blue", "White", "Yellow", "Magenta", "Exit" };
            methodDo[] colmethods = new methodDo[] { Red }; //Green, Blue, White, Yellow, Magenta, Exit };

          //  Console.ForegroundColor = ConsoleColor.Red;
        
        // ConsoleMenu menucol = new ConsoleMenu(colors);

            // do
            {
                // menuResultcol = menucol.PrintMenu();
                int menuResultcol = 0;
                var color=colmethods[menuResultcol].Invoke();
                //Оце ви так замутили
                // colmethods[menuResultcol]=>methodDo()=>method();
                color();
                methods[0]();
                //  Console.WriteLine("Для продолжения нажмите любую клавишу");
                //  Console.ReadKey();

                // } while (menuResultcol != colors.Length - 1);

                // Action<method> meth;
                // meth = delegate { del(); };

            }


        }

    }
}
