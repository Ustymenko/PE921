using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
//DOM  - XmlDocument
//SAX XmlTextReader, XmlTextWriter
namespace _12042020
{
    class Program
    {
        static void CreateXML(string file)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(file, Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                {
                    //< !DOCTYPE clients[<!ENTITY hello "Привіт з Ощад! " >] >
                    writer.WriteDocType("students", null, null, "<!ENTITY hello \"Привіт з Ощад! \">");
                    writer.WriteStartElement("students");
                    {
                        writer.WriteStartElement("student");
                        {
                            writer.WriteComment("Тест коментаря");
                            writer.WriteStartElement("fname");
                            {
                                writer.WriteEntityRef("hello");
                                writer.WriteString("Ivan");
                                writer.WriteEndElement();
                            }
                            writer.WriteElementString("lname", "Ivasyk");
                            writer.WriteElementString("suma", "10.59");
                            writer.WriteStartElement("address");
                            {
                                writer.WriteAttributeString("country", "Україна");
                                writer.WriteAttributeString("region", "Житомирська область");
                                writer.WriteString("Житомир");
                                writer.WriteEndElement();
                            }

                            writer.WriteElementString("birthday", "15.05.1978");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("student");
                        {
                            writer.WriteComment("Тест коментаря");
                            writer.WriteStartElement("fname");
                            {
                                writer.WriteEntityRef("hello");
                                writer.WriteString("Petro");
                                writer.WriteEndElement();
                            }
                            writer.WriteElementString("lname", "Petrenko");
                            writer.WriteElementString("suma", "1.59");
                            writer.WriteStartElement("address");
                            {
                                writer.WriteAttributeString("country", "Україна");
                                writer.WriteAttributeString("region", "Київська область");
                                writer.WriteString("Київ");
                                writer.WriteEndElement();
                            }

                            writer.WriteElementString("birthday", "15.05.1978");
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer?.Close();
            }




        }
        static void ReadXML(string file)
        {
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(file);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    // if (!string.IsNullOrWhiteSpace(reader.Value))
                    {
                        Console.WriteLine($"NodeType={reader.NodeType}\t\t" +
                            $"Name={reader.Name}\t\t" +
                            $"Value={reader.Value}");
                    }
                    if (reader.AttributeCount > 0)
                    {

                        while (reader.MoveToNextAttribute())
                            Console.WriteLine($"" +
                                $"NodeType={reader.NodeType}\t\t" +
                                $"Name={reader.Name}\t\t" +
                                $"Value={reader.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader?.Close();
            }


        }
        static void FindInXML(string file, string teg, string val)
        {
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(file);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (reader.Name == teg)
                        if (reader.Read() && reader.Value == val)
                            Console.WriteLine($"find {reader.Name}\t\t{reader.Value}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader?.Close();
            }


        }

        static void PrintNode(XmlNode node)
        {
            Console.WriteLine($"NodeType={node.NodeType}\t\t" +
                               $"Name={node.Name}\t\t" +
                               $"Value={node.Value}");
            if (node.Attributes != null)
            {
                foreach (XmlAttribute item in node.Attributes)
                    Console.WriteLine($"Name={item.Name}\t\tValue={item.Value}");
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    PrintNode(item);
                }
            }

        }

        static void LoadXMl(string file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                PrintNode(doc.DocumentElement);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ChangeXMl(string file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlNode root = doc.DocumentElement;
                // root.RemoveChild(root.FirstChild);
                XmlElement stud = doc.CreateElement("student");
                {
                    XmlComment comment = doc.CreateComment("coment");
                    stud.AppendChild(comment);
                    XmlElement fn = doc.CreateElement("fname");
                    {
                        XmlEntityReference hl = doc.CreateEntityReference("hello");
                        XmlText fntext = doc.CreateTextNode("Anna");
                        fn.AppendChild(hl);
                        fn.AppendChild(fntext);
                    }
                    stud.AppendChild(fn);
                    XmlElement ln = doc.CreateElement("lname");
                    ln.InnerText = "Drozd";
                    stud.AppendChild(ln);

                    XmlElement sum = doc.CreateElement("suma");
                    sum.InnerText = "12.63";
                    stud.AppendChild(sum);

                    // <address country="Україна" region="Житомирська область">Житомир</address>
                    XmlElement address = doc.CreateElement("address");
                    address.InnerText = "Бердичів";
                    {
                        XmlAttribute country= doc.CreateAttribute("country");
                        country.Value = "Україна";
                        address.Attributes.Append(country);

                        XmlAttribute region = doc.CreateAttribute("region");
                        region.Value = "Житомирська область";
                        address.Attributes.Append(region);
                    }
                    stud.AppendChild(address);


                    //    <birthday>15.05.1978</birthday>
                    XmlElement birthday = doc.CreateElement("birthday");
                    birthday.InnerText = "25.07.1996";
                    stud.AppendChild(birthday);


                }
                root.AppendChild(stud);
                doc.Save(file);
                Console.WriteLine(file + "is changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        static void Main(string[] args)
        {
            string filename = "students.xml";
         //   CreateXML(filename);
            //ReadXML(filename);
            //Console.WriteLine("----------------------------------------find");
            //FindInXML(filename, "lname", "Ivasyk");
            //Console.WriteLine("----------------------------------------findend");

            //LoadXMl(filename);
            ChangeXMl(filename);


            //Xpath
        }
    }
}
