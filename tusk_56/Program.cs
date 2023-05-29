using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_56\\XMLFile1.xml");
            XNamespace ns = "https://google.com";
            var pref = d.Root.GetPrefixOfNamespace(ns);

            foreach (var item in d.Root.Descendants().Where(el => el.Parent == d.Root))
            {
                item.Name= ns.GetName(item.Name.LocalName);
            }
            d.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_56\\XMLFileResult.xml");
        }
    }
}
