using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace tusk_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_16\\XMLFile1.xml";
            Dictionary<string, int> elemets = new Dictionary<string, int>(); 
            XDocument d = XDocument.Load(path);
            XElement root = d.Root;
            foreach (XElement item1 in root.Elements())
            {
                int counter = 0;
                foreach (XElement item2 in item1.Elements())
                {
                    foreach (XElement item3 in item2.Elements())
                    {
                        counter += item3.Attributes().Count();
                    }
                }
                elemets.Add(item1.Name.ToString(), counter);
            }
            var result = elemets.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " count: " + item.Value);
            }
            Console.ReadLine();
        }
    }
}
