using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_36
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_36\\XMLFile1.xml");
            foreach(var item in d.Root.Descendants().Where(el => el.Parent.Parent == d.Root))
            {
                int count = item.Descendants().Count();
                item.SetAttributeValue("node-count", count); 
            }
            d.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_36\\XMLFileResult.xml");
        }
    }
}
