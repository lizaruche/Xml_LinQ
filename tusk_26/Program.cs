using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_26\\XMLFile1.xml");
            foreach (var item in d.Descendants())
            {
                item.Attributes().Where(a => a.PreviousAttribute != null).Remove();
            }
            d.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_26\\XMLFileResult.xml");
            Console.ReadLine();
        }
    }
}
