using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

using System.Xml.Serialization;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace _16042020
{
    [Serializable]
    [DataContract]
    public class Person : ISerializable
    {
        [DataMember]
        int s;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public DateTime Bday { get; set; }
        [NonSerialized]
        const string Planet = "Earth";
        public Person(string name)
        {
            Name = name;
            Bday = DateTime.Now;
            Age = 15;
            s = name.Length * Age;
        }
        public Person() : this(" ")
        {
        }
        public override string ToString()
        {
            return $"{Name,10} {Age,5} {Bday.ToShortDateString(),10} {Planet} {s}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PersonS", s);
            info.AddValue("PersonName", Name.ToUpper());
            info.AddValue("PersonAge", Age);
            info.AddValue("PersonBday", Bday.ToLocalTime());
        }
        private Person(SerializationInfo info, StreamingContext context)
        {
            s = info.GetInt32("PersonS");
            Name = info.GetString("PersonName").ToLower();
            Age = info.GetInt32("PersonAge");
            Bday = info.GetDateTime("PersonBday");
        }
    }
    //bin
    class BinaryForm
    {
        public static void Save(Person person, string file)
        {

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream fsteam = File.Create(file))
                {
                    formatter.Serialize(fsteam, person);
                }
                Console.WriteLine("Binary saved format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Person Load(string file)
        {
            Person person = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream fsteam = File.OpenRead(file))
                {
                    person = formatter.Deserialize(fsteam) as Person;
                }
                Console.WriteLine("Binary loaded format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return person;
        }
    }
    //SOAP
    class SOAPForm
    {
        public static void Save(Person person, string file)
        {
            try
            {
                SoapFormatter formatter = new SoapFormatter();
                using (Stream fsteam = File.Create(file))
                {
                    formatter.Serialize(fsteam, person);
                }
                Console.WriteLine("Soap saved format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Person Load(string file)
        {
            Person person = null;
            try
            {
                SoapFormatter formatter = new SoapFormatter();
                using (Stream fsteam = File.OpenRead(file))
                {
                    person = formatter.Deserialize(fsteam) as Person;
                }
                Console.WriteLine("Soap loaded format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return person;
        }
    }

    //XML
    class XMLForm
    {
        public static void Save(Person person, string file)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Person));
                using (Stream fsteam = File.Create(file))
                {
                    formatter.Serialize(fsteam, person);
                }
                Console.WriteLine("XML saved format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Person Load(string file)
        {
            Person person = null;
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Person));
                using (Stream fsteam = File.OpenRead(file))
                {
                    person = formatter.Deserialize(fsteam) as Person;
                }
                Console.WriteLine("XML loaded format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return person;
        }
    }


    //JSON
    class JSONForm
    {
        public static void Save(Person person, string file)
        {
            try
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Person));
                using (Stream fsteam = File.Create(file))
                {
                    formatter.WriteObject(fsteam, person);
                }
                Console.WriteLine("JSON saved format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Person Load(string file)
        {
            Person person = null;
            try
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Person));
                using (Stream fsteam = File.OpenRead(file))
                {
                    person = formatter.ReadObject(fsteam) as Person;
                }
                Console.WriteLine("JSON loaded format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return person;
        }
    }

    class Program
    {
        static void TestBin()
        {
            Person person = new Person("Пітер Пен")
            {
                // Bday = new DateTime(1986, 10, 25)
                Bday = new DateTime(day: 25, month: 10, year: 1986),
                Age = 45
            };
            Console.WriteLine(person);
            BinaryForm.Save(person, "Petro.bin");

            Person nperson = BinaryForm.Load("Petro.bin");
            Console.WriteLine(nperson);
        }
        static void TestSOAP()
        {
            Person person = new Person("Пітер Пен")
            {
                // Bday = new DateTime(1986, 10, 25)
                Bday = new DateTime(day: 25, month: 10, year: 1986),
                Age = 45
            };
            Console.WriteLine(person);
            SOAPForm.Save(person, "Petro.soap");

            Person nperson = SOAPForm.Load("Petro.soap");
            Console.WriteLine(nperson);
        }
        static void TestXML()
        {
            Person person = new Person("Пітер Пен")
            {
                // Bday = new DateTime(1986, 10, 25)
                Bday = new DateTime(day: 25, month: 10, year: 1986),
                Age = 45
            };
            Console.WriteLine(person);
            XMLForm.Save(person, "Petro.xml");

            Person nperson = XMLForm.Load("Petro.xml");
            Console.WriteLine(nperson);
        }
        static void TestJSON()
        {
            Person person = new Person("Пітер Пен")
            {
                // Bday = new DateTime(1986, 10, 25)
                Bday = new DateTime(day: 25, month: 10, year: 1986),
                Age = 45
            };
            Console.WriteLine(person);
            JSONForm.Save(person, "Petro.json");

            Person nperson = JSONForm.Load("Petro.json");
            Console.WriteLine(nperson);
        }

        static void TestJSON2()
        {
            Person person = new Person("Пітер Пен")
            {
                // Bday = new DateTime(1986, 10, 25)
                Bday = new DateTime(day: 25, month: 10, year: 1986),
                Age = 45
            };
            Console.WriteLine(person);

            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);
            File.WriteAllText("p.json", json);

            string njson = File.ReadAllText("p.json");

            Person nperson = JsonConvert.DeserializeObject<Person>(njson);

            Console.WriteLine(nperson);
        }
        // Створити клас Паспорт і перевірити роботу наших методів

        static void Main(string[] args)
        {
            TestBin();
            TestSOAP();
            TestXML();
            // TestJSON();
            //  TestJSON2();

        }
    }
}
