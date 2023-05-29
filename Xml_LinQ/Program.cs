using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml_LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до текстового файла");
            string txtPath = "C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\Xml_LinQ\\TextFile1.txt";
            string xmlPath = "C:\\\\Users\\\\arsen\\\\source\\\\repos\\\\Xml_LinQ\\\\Xml_LinQ\\XMLFile1.xml";
            List<int[]> lines = new List<int[]>();

            try 
            {
                string line;
                StreamReader sr = new StreamReader(txtPath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    int[] buf = Array.ConvertAll(line.Split(' '), s => int.Parse(s));
                    Array.Sort(buf);
                    lines.Add(buf);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            XmlDocument d = new XmlDocument();
            d.AppendChild(d.CreateXmlDeclaration("1.0", "windows-1251", null));
            XmlElement root = d.CreateElement("root");
            d.AppendChild(root);
            foreach (int[] item in lines)
            {
                XmlElement line = d.CreateElement("line");
                XmlAttribute attr = d.CreateAttribute("sum");
                attr.InnerText = $"{item.Sum()}";
                line.Attributes.Append(attr);
                foreach (int number in item)
                {
                    XmlElement num = d.CreateElement("number");
                    num.InnerText = number.ToString();
                    line.AppendChild(num);
                }
                root.AppendChild(line);
            }
            d.Save(xmlPath);
        }
    }
}
