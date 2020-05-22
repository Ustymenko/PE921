using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _09042020
{
    class FileStreamTest
    {
        public static void SaveFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create,
                     FileAccess.Write, FileShare.None))
            {
                string str = "Несе Галя воду Hello";
                byte[] arr;
                arr = new byte[] { 0xFF, 0xFE };//BOM
                fs.Write(arr, 0, arr.Length);
                //throw
                arr = Encoding.Unicode.GetBytes(str);
                fs.Write(arr, 0, arr.Length);
                //   fs.Close();
                Console.WriteLine("File saved");
            }
        }
        public static void ReadFile(string file)
        {
            string str;
            using (FileStream fs = new FileStream(file, FileMode.Open,
                     FileAccess.Read, FileShare.Read))
            {
                byte[] arr = new byte[fs.Length - 2];
                //fs.Read(arr, 0, 2);
                fs.Seek(2, SeekOrigin.Begin);
                fs.Read(arr, 0, arr.Length);
                str = Encoding.Unicode.GetString(arr);
            }
            Console.WriteLine("File read");
            Console.WriteLine("File: " + str);
        }
        public static void ReadPosFile(string file)
        {
            string str;
            using (FileStream fs = new FileStream(file, FileMode.Open,
                     FileAccess.Read, FileShare.Read))
            {
                byte[] arr = new byte[8];

                Console.WriteLine($"Position= {fs.Position}");
                //fs.Read(arr, 0, 2);
                fs.Seek(12, SeekOrigin.Begin);
                Console.WriteLine($"Position= {fs.Position}");
                fs.Read(arr, 0, arr.Length);
                Console.WriteLine($"Position= {fs.Position}");
                str = Encoding.Unicode.GetString(arr);
            }
            Console.WriteLine("File read");
            Console.WriteLine("File: " + str);
        }
        public static void Test()
        {
            SaveFile("1.txt");
            ReadFile("1.txt");
            ReadPosFile("1.txt");
        }
    }

    class StreamWriterTest
    {
        public static void SaveFile(string file)
        {
            using (StreamWriter fs = new StreamWriter(file, false, Encoding.Unicode))
            {
                string str = "Несе Галя воду Hello";
                fs.Write(str);
            }
            using (StreamWriter fs = new StreamWriter(file, true, Encoding.Unicode))
            {
                fs.WriteLine(123);
                fs.WriteLine(123.369);
                Console.WriteLine("File saved");
            }
        }
        public static void SaveFile2(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    string str = "Несе Галя воду Hello";
                    sw.Write(str);
                    sw.WriteLine(123);
                    sw.WriteLine(123.369);
                    Console.WriteLine("File saved");
                }
            }
        }

        public static void ReadFile(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.Unicode))
            {
                Console.WriteLine(sr.CurrentEncoding.BodyName);
                Console.WriteLine(sr.EndOfStream);
                Console.WriteLine((char)sr.Read());
                Console.WriteLine((char)sr.Peek());
                char[] arr = new char[3];
                sr.ReadBlock(arr, 0, arr.Length);
                Console.WriteLine("Block=" + string.Join("", arr));
                Console.WriteLine(sr.ReadLine());
                string str = sr.ReadToEnd();
                Console.WriteLine(str);
                Console.WriteLine(sr.EndOfStream);

                //Console.WriteLine("File: " + str);

            }
            Console.WriteLine("File read");
        }

        public static void Test()
        {
            //  SaveFile("2.txt");
            SaveFile2("2.txt");
            ReadFile("2.txt");

        }
    }

    class BinaryTest
    {
        public static void SaveFile(string file)
        {
            //using (FileStream fs = new FileStream(file, FileMode.Create))
            //{
            //    using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
            //    {
            //        string str = "Несе Галя воду Hello";
            //        bw.Write(str);
            //        bw.Write(132);
            //        bw.Write(369.963);
            //        bw.Write(true);
            //    }
            //}
            //Console.WriteLine("File saved");

            using (BinaryWriter bw = new BinaryWriter(
                File.Open(file, FileMode.OpenOrCreate),
                Encoding.Unicode))
            {
                string str = "Hесе Галя воду Hello";
                bw.Write(str);
                bw.Write(132);
                bw.Write(369.963);
                bw.Write(true);
            }
            Console.WriteLine("File saved");
        }
        public static void ReadFile(string file)
        {
            using (BinaryReader br = new BinaryReader(
                File.Open(file, FileMode.Open),
                Encoding.Unicode))
            {
                string str = br.ReadString();
                Console.WriteLine(str);
                int n = br.ReadInt32();
                Console.WriteLine(n);
                double d = br.ReadDouble();
                Console.WriteLine(d);
                bool b = br.ReadBoolean();
                Console.WriteLine(b);
            }
            Console.WriteLine("File read");
        }

        public static void Test()
        {
            SaveFile("3.bin");
            ReadFile("3.bin");


        }
    }

    class Program
    {
        static void TestDir()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Ustymenko\source\repos\PE921\09042020");
            Console.WriteLine($"FullName={di.FullName}");
            Console.WriteLine($"FullName={di.CreationTime}");
            Console.WriteLine($"Directory:");
            foreach (var item in di.GetDirectories())
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"File:");
                foreach (var f in item.GetFiles())
                {
                    Console.WriteLine($"{f.Name}");
                }
                Console.WriteLine($"--------------------------------------");
            }

            //2020-04-12 15:52:36
        }
        static void TestDir2()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Ustymenko\source\repos\PE921\09042020\ttttttttt");
            if (!dir.Exists)
                dir.Create();
            dir.CreateSubdirectory("555555");
        
        }
        static void Main(string[] args)
        {
            //  FileStreamTest.Test();
            //StreamWriterTest.Test();
            //BinaryTest.Test();

            //TestDir();
            TestDir2();
            //Directory
            //Directory
            string str = File.ReadAllText("1.txt");
            Console.WriteLine(str);

           // FileInfo fl = new FileInfo("3.txt");
        }
    }
}
