using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_46
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_46\\XMLFile1.xml");
            foreach (var item in d.Descendants())
            {
                int count = 0;
                var childs = item.Descendants().Where(el => el.Parent == item).ToList();
                if (childs.Count() > 0)
                {
                    foreach (var child in childs)
                    {
                        count += child.Descendants().Where(el => el.Parent == child).Count();
                    }
                    item.SetAttributeValue("odd-node-count", count % 2 != 0);
                }
            }
            d.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_46\\XMLFileResult.xml");
        }
    }
}
